using NFluent;
using Take6.Domain;
using Xunit;

namespace Take6.Test
{
    public class InitAGame
    {
        Card firstCard = new(1);
        Card secondCard = new(10);
        Card thirdCard = new(20);
        Card fourthCard = new(30);

        [Fact]
        public void CardOneShouldBeCorrectlyPlaced()
        {
            Game game = new(new Player("Anne"), firstCard, secondCard, thirdCard, fourthCard);

           Check.That(game.GetCard(RowNumber.One, 1)).IsEqualTo(new Card(1));
           Check.That(game.GetCard(RowNumber.Two, 1)).IsEqualTo(new Card(10));
           Check.That(game.GetCard(RowNumber.Three, 1)).IsEqualTo(new Card(20));
           Check.That(game.GetCard(RowNumber.Four, 1)).IsEqualTo(new Card(30));
        }

        [Fact]
        public void CardShouldBePlacedOnCorrespondingRow()
        {
            Game game = new(new Player("Samuel"), firstCard, secondCard, thirdCard, fourthCard);
            game.PlayCard(new(9));
            game.PlayCard(new(11));
            game.PlayCard(new(15));
            game.PlayCard(new(29));
            game.PlayCard(new(31));
            game.PlayCard(new(40));
            game.PlayCard(new(100));

            Check.That(game.GetCard(RowNumber.One, 2)).IsEqualTo(new(9));

            Check.That(game.GetCard(RowNumber.Two, 2)).IsEqualTo(new(11));
            Check.That(game.GetCard(RowNumber.Two, 3)).IsEqualTo(new(15));

            Check.That(game.GetCard(RowNumber.Three, 2)).IsEqualTo(new(29));

            Check.That(game.GetCard(RowNumber.Four, 2)).IsEqualTo(new(31));
            Check.That(game.GetCard(RowNumber.Four, 3)).IsEqualTo(new(40));
            Check.That(game.GetCard(RowNumber.Four, 4)).IsEqualTo(new(100));
        }

        [Fact]
        public void LineIsResetAfterTake6()
        {
            Game game = new(new Player("Morgan"), new(1), new(98), new(99), new(100));
            game.PlayCard(new(2));
            game.PlayCard(new(40));
            game.PlayCard(new(50));
            game.PlayCard(new(60));

            // Take6!
            game.PlayCard(new(97));

            Check.That(game.GetCard(RowNumber.One, 1)).IsEqualTo(new(97));
        }

        [Fact]
        public void PlayerShouldStartWith0Point()
        {
            Game game = new(new Player("Morgan"), firstCard, secondCard, thirdCard, fourthCard);
            var score = game.GetScore(new Player("Morgan"));
            Check.That(score).IsZero();
        }

        [Fact]
        public void IsPlayerLooseScoreShouldBeComputed()
        {
            Game game = new(new Player("Morgan"), new(1), new(98), new(99), new(100));
            game.PlayCard(new(2));
            game.PlayCard(new(40));
            game.PlayCard(new(50));
            game.PlayCard(new(60));

            // Take6!
            game.PlayCard(new(97));

            var score = game.GetScore(new Player("Morgan"));
            Check.That(score).IsStrictlyGreaterThan(0);
        }
    }
}
