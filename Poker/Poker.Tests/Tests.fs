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

    [<Fact>]
    let When_both_hands_have_OnePair_it_returns_the_two_hands() =
        // Arrange
        let hand = [
                   {Value = CardValue.Number2; Suit = Diamonds; }
                   {Value = CardValue.Number2; Suit = Diamonds; }
                   {Value = CardValue.Number6; Suit = Diamonds; }
                   {Value = CardValue.Number7; Suit = Diamonds; }
                   {Value = CardValue.Number9; Suit = Diamonds; }
                   ]

        let secondHand = [
                   {Value = CardValue.Number2; Suit = Diamonds; }
                   {Value = CardValue.Number2; Suit = Diamonds; }
                   {Value = CardValue.Number6; Suit = Diamonds; }
                   {Value = CardValue.Number7; Suit = Diamonds; }
                   {Value = CardValue.Number9; Suit = Diamonds; }
                   ]
        // Act
        let result = GetWinners hand secondHand

        // Assert
        Xunit.Assert.True ([hand; secondHand] = result)
        
    [<Fact>]
    let When_one_hand_has_OnePair_and_the_other_has_HighCard_the_winner_is_the_hand_with_OnePair() =
        // Arrange
        let hand = [
                   {Value = CardValue.Number2; Suit = Diamonds; }
                   {Value = CardValue.Number2; Suit = Diamonds; }
                   {Value = CardValue.Number6; Suit = Diamonds; }
                   {Value = CardValue.Number7; Suit = Diamonds; }
                   {Value = CardValue.Number9; Suit = Diamonds; }
                   ]

        let secondHand = [
                   {Value = CardValue.Number2; Suit = Diamonds; }
                   {Value = CardValue.Number3; Suit = Diamonds; }
                   {Value = CardValue.Number6; Suit = Diamonds; }
                   {Value = CardValue.Number7; Suit = Diamonds; }
                   {Value = CardValue.Number9; Suit = Diamonds; }
                   ]
        // Act
        let result = GetWinners hand secondHand

        // Assert
        Xunit.Assert.True ([hand] = result)
        
    [<Fact>]
    let When_second_hand_has_OnePair_and_the_other_has_HighCard_the_winner_is_the_hand_with_OnePair() =
        // Arrange
        let hand = [
                   {Value = CardValue.Number2; Suit = Diamonds; }
                   {Value = CardValue.Number3; Suit = Diamonds; }
                   {Value = CardValue.Number6; Suit = Diamonds; }
                   {Value = CardValue.Number7; Suit = Diamonds; }
                   {Value = CardValue.Number9; Suit = Diamonds; }
                   ]

        let secondHand = [
                   {Value = CardValue.Number2; Suit = Diamonds; }
                   {Value = CardValue.Number2; Suit = Diamonds; }
                   {Value = CardValue.Number6; Suit = Diamonds; }
                   {Value = CardValue.Number7; Suit = Diamonds; }
                   {Value = CardValue.Number9; Suit = Diamonds; }
                   ]
        // Act
        let result = GetWinners hand secondHand

        // Assert
        Xunit.Assert.True ([secondHand] = result)

    [<Fact>]
    let When_first_hand_has_TwoPair_and_the_other_has_OnePair_the_winner_is_the_hand_with_TwoPair() =
        // Arrange
        let hand = [
                   {Value = CardValue.Number2; Suit = Diamonds; }
                   {Value = CardValue.Number2; Suit = Diamonds; }
                   {Value = CardValue.Number6; Suit = Diamonds; }
                   {Value = CardValue.Number6; Suit = Diamonds; }
                   {Value = CardValue.Number9; Suit = Diamonds; }
                   ]

        let secondHand = [
                   {Value = CardValue.Number2; Suit = Diamonds; }
                   {Value = CardValue.Number2; Suit = Diamonds; }
                   {Value = CardValue.Number6; Suit = Diamonds; }
                   {Value = CardValue.Number7; Suit = Diamonds; }
                   {Value = CardValue.Number9; Suit = Diamonds; }
                   ]
        // Act
        let result = GetWinners hand secondHand

        // Assert
        Xunit.Assert.True ([hand] = result)

    [<Fact>]
    let When_one_hand_has_OnePair_and_the_other_has_ThreeOfAKind_then_the_winner_is_three_of_a_kind() =
        // Arrange
        let hand = [
                   {Value = CardValue.Number2; Suit = Diamonds; }
                   {Value = CardValue.Number2; Suit = Diamonds; }
                   {Value = CardValue.Number2; Suit = Diamonds; }
                   {Value = CardValue.Number6; Suit = Diamonds; }
                   {Value = CardValue.Number9; Suit = Diamonds; }
                   ]

        let secondHand = [
                   {Value = CardValue.Number2; Suit = Diamonds; }
                   {Value = CardValue.Number2; Suit = Diamonds; }
                   {Value = CardValue.Number6; Suit = Diamonds; }
                   {Value = CardValue.Number7; Suit = Diamonds; }
                   {Value = CardValue.Number9; Suit = Diamonds; }
                   ]
        // Act
        let result = GetWinners hand secondHand

        // Assert
        Xunit.Assert.True ([hand] = result)
