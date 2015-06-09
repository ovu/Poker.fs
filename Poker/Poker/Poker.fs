namespace Schulung.Poker

module Poker =
    type Suit = 
    | Hearts
    | Diamonds
    | Spades
    | Clubs

    type CardValue =
    | Ace
    | King
    | Queen
    | Jack
    | Number of int

    type Card = {
        Suit : Suit
        Value : CardValue
    }

    let GetHandCombination hand = ()