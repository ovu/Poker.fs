namespace Poker.Tests

open Xunit

module Tests =
    let When_a_hand_has_no_combination_the_score_is_the_highest_card() = 
        // Arrange
        let hand = [
                   {Number =2; Suit = Diamond; }
                   {Number =3; Suit = Diamond; }
                   {Number =6; Suit = Diamond; }
                   {Number =7; Suit = Diamond; }
                   {Number =9; Suit = Diamond; }
                   ]
        // Act
        let result = GetHandCombination hand

        // Assert
        Xunit.Assert.Equal(HighCard, result)