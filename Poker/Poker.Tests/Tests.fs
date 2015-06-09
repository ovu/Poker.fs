namespace Poker.Tests

open Xunit
open Schulung.Poker
open Schulung.Poker.Poker

module Tests =
    [<Fact>]
    let When_a_hand_has_no_combination_the_score_is_the_highest_card() = 
        // Arrange
        let hand = [
                   {Value = CardValue.Number2; Suit = Diamonds; }
                   {Value = CardValue.Number3; Suit = Diamonds; }
                   {Value = CardValue.Number6; Suit = Diamonds; }
                   {Value = CardValue.Number7; Suit = Diamonds; }
                   {Value = CardValue.Number9; Suit = Diamonds; }
                   ]
        // Act
        let result = Poker.GetHandCombination hand

        // Assert
        Xunit.Assert.Equal(HandCombination.HighCard, result)

    [<Fact>]
    let When_a_hand_has_one_pair_the_score_is_OnePair() = 
        // Arrange
        let hand = [
                   {Value = CardValue.Number2; Suit = Diamonds; }
                   {Value = CardValue.Number2; Suit = Diamonds; }
                   {Value = CardValue.Number6; Suit = Diamonds; }
                   {Value = CardValue.Number7; Suit = Diamonds; }
                   {Value = CardValue.Number9; Suit = Diamonds; }
                   ]
        // Act
        let result = Poker.GetHandCombination hand

        // Assert
        Xunit.Assert.Equal(HandCombination.OnePair, result)