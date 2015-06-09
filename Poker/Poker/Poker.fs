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
        Value : CardValue
        Suit : Suit
    }


    let GetHandCombination hand = ()