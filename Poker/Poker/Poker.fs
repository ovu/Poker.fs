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
    
    type CombinationCheck = Hand -> bool
    
    let handHasOnePair : CombinationCheck = 
        fun hand -> 
            (hand
             |> Seq.groupBy (fun card -> card.Value)
             |> Seq.exists (fun g -> Seq.length (snd g) = 2))
    
    let GetHandCombination : HandClassifier = 
        fun hand -> 
            match hand with
            | x when handHasOnePair x -> OnePair
            | _ -> HighCard
