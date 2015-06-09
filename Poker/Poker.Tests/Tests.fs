namespace Poker.Tests

open Xunit
open Schulung.Poker
open Schulung.Poker.Poker

module Tests =
    let When_a_hand_has_no_combination_the_score_is_the_highest_card() = 
        // Arrange
        let hand = [
                   {Value = CardValue.Number 2; Suit = Diamonds; }
                   {Value = CardValue.Number 3; Suit = Diamonds; }
                   {Value = CardValue.Number 6; Suit = Diamonds; }
                   {Value = CardValue.Number 7; Suit = Diamonds; }
                   {Value = CardValue.Number 9; Suit = Diamonds; }
                   ]
        // Act
        let result = Poker.GetHandCombination hand

        // Assert
        Xunit.Assert.Equal(HighCard, result)