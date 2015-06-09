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
    
    type PairsCheck = Hand -> int -> bool
    
    let handHasPairs : PairsCheck = 
        fun hand n -> 
            (hand
             |> Seq.groupBy (fun card -> card.Value)
             |> Seq.where (fun g -> Seq.length (snd g) = 2) |> Seq.length) = n
    
    let GetHandCombination : HandClassifier = 
        fun hand -> 
            match hand with
            | x when handHasPairs x 1 -> OnePair
            | x when handHasPairs x 2 -> TwoPair
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