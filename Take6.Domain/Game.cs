using System;
using System.Collections.Generic;
using System.Linq;

namespace Take6.Domain
{
    public record Player(string Name) {
        public int Score { get; private set; } = 0;

        internal void Loose(Row correspondingRow)
        {
            Score++;
        }

        public void TakesRowCards(List<Card> lists)
        {
            Score += lists.Sum(card => card.CattleHeads);
        }
    }

    public class Game
    {
        readonly List<Row> rows;
        readonly Player player1;

        public Game(Player player, Card firstCard, Card secondCard, Card thirdCard, Card fourthCard)
        {
            player1 = player;
            rows = new()
            {
                new(firstCard),
                new(secondCard),
                new(thirdCard),
                new(fourthCard)
            };
        }

        public void PlayCard(Card card)
        {
            var correspondingRow = GetCorrespondingRow(card);

            if (correspondingRow.HasFiveCards())
            {
                player1.Loose(correspondingRow);
                correspondingRow.Reset(card);
            }
            else correspondingRow.AddCard(card);
        }

        private Row GetCorrespondingRow(Card card)
        {
            var indexToSelect = rows.Select((row, index) => new { rowIndex = index, diffBtwCard = (card - row.GetLastCard()).Value })
                                   .Where(c => c.diffBtwCard > 0)
                                   .OrderBy(c => c.diffBtwCard).First();

            return rows[indexToSelect.rowIndex];
        }

        public Card GetCard(RowNumber rowNumber, int v1)
        {
            return rows[(int)rowNumber - 1].GetCard(v1);
        }

        public int GetScore(Player player)
        {
            return player1.Score;
        }
    }
}