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

    type Card = {
        Value : CardValue
        Suit : Suit
    }

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

    let GetHandCombination hand = HighCard