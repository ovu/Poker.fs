namespace Schulung.Poker

module Poker = 
    type Suit = 
        | Hearts
        | Diamonds
        | Spades
        | Clubs
    
    type CardValue = 
        | Number2
        | Number3
        | Number4
        | Number5
        | Number6
        | Number7
        | Number8
        | Number9
        | Number10
        | Jack
        | Queen
        | King
        | Ace
    
    type Card = 
        { Value : CardValue
          Suit : Suit }
    
    type HandCombination = 
        | HighCard
        | OnePair
        | TwoPair
        | ThreeOfAKind
        | Straight
        | Flush
        | FullHouse
        | FourOfAKind
        | StraightFlush
        | RoyalFlush
    
    type Hand = Card list
    
    type HandClassifier = Hand -> HandCombination
    
    type SameOfAKindCheck = Hand -> int -> int -> bool
    
    type StraightCheck = Hand -> bool

    let (|ValueRank|) card = 
        Microsoft.FSharp.Reflection.FSharpValue.PreComputeUnionTagReader (typeof<CardValue>) (box card.Value)
         
    let hasStraight : StraightCheck = 
        fun hand -> hand |> Seq.sort |> Seq.pairwise |> Seq.forall (fun (ValueRank a, ValueRank b) -> b - a = 1)

    let handHasSameOfAKind : SameOfAKindCheck = 
        fun hand groupCount groupLength -> 
            (hand
             |> Seq.groupBy (fun card -> card.Value)
             |> Seq.where (fun g -> Seq.length (snd g) = groupLength) |> Seq.length) = groupCount
    
    let GetHandCombination : HandClassifier = 
        fun hand -> 
            match hand with
            | x when handHasSameOfAKind x 1 2 -> OnePair
            | x when handHasSameOfAKind x 2 2 -> TwoPair
            | x when handHasSameOfAKind x 1 3 -> ThreeOfAKind
            | x when hasStraight x -> Straight
            | _ -> HighCard

    type GetWinnerClassifier = Hand -> Hand -> Hand list

    let GetWinners : GetWinnerClassifier =
        fun hand1 hand2 -> 
            let firstHandCombination = GetHandCombination hand1 
            let secondHandCombination = GetHandCombination hand2
            if firstHandCombination > secondHandCombination
            then
                [hand1]
            elif firstHandCombination = secondHandCombination then
                [hand1;hand2] 
            else 
                [hand2]