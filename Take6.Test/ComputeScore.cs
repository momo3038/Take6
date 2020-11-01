using System.Collections.Generic;
using NFluent;
using Take6.Domain;
using Xunit;

namespace Take6.Test
{
    public class ComputeScore
    {
        [Fact]
        public void FifthyFiveisScoring7()
        {
            var card = new Card(55);
            Check.That(card.CattleHeads).IsEqualTo(7);
        }

        [Fact]
        public void MultipleOf11Scores5()
        {
            Check.That(new Card(11).CattleHeads).IsEqualTo(5);
            Check.That(new Card(22).CattleHeads).IsEqualTo(5);
            Check.That(new Card(33).CattleHeads).IsEqualTo(5);
            Check.That(new Card(44).CattleHeads).IsEqualTo(5);
            Check.That(new Card(99).CattleHeads).IsEqualTo(5);
        }

        [Fact]
        public void MultipleOf10Scores3()
        {
            Check.That(new Card(10).CattleHeads).IsEqualTo(3);
            Check.That(new Card(20).CattleHeads).IsEqualTo(3);
            Check.That(new Card(30).CattleHeads).IsEqualTo(3);
            Check.That(new Card(40).CattleHeads).IsEqualTo(3);
            Check.That(new Card(50).CattleHeads).IsEqualTo(3);
            Check.That(new Card(100).CattleHeads).IsEqualTo(3);
        }

        [Fact]
        public void MultipleOf5NotMultipleOf10Scores2()
        {
            Check.That(new Card(5).CattleHeads).IsEqualTo(2);
            Check.That(new Card(15).CattleHeads).IsEqualTo(2);
            Check.That(new Card(25).CattleHeads).IsEqualTo(2);
            Check.That(new Card(35).CattleHeads).IsEqualTo(2);
            Check.That(new Card(45).CattleHeads).IsEqualTo(2);
            Check.That(new Card(95).CattleHeads).IsEqualTo(2);
        }

        [Fact]
        public void AllOtherValuesScores1()
        {
            Check.That(new Card(1).CattleHeads).IsEqualTo(1);
            Check.That(new Card(98).CattleHeads).IsEqualTo(1);
            Check.That(new Card(104).CattleHeads).IsEqualTo(1);         
        }

        [Fact]
        public void PlayerShouldStartWith0Point()
        {
            Check.That(new Player("Morgan").Score).IsZero();
        }

        [Fact]
        public void ShouldComputeScoreWhenTake6OnARow()
        {
            var player = new Player("Anne");
            player.TakesRowCards(new List<Card>() { new(1), new(5), new(10), new(11), new(55) });

            Check.That(player.Score).IsEqualTo(1 + 2 + 3 + 5 + 7);
        }
    }
}
