using System;
using System.Collections.Generic;
using System.Linq;

namespace Take6.Domain
{
    public class Row
    {
        readonly List<Card> cards;

        public Row(Card firstCard)
        {
            cards = new()
            {
                firstCard
            };
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public Card GetLastCard()
        {
            return cards.LastOrDefault();
        }

        public Card GetCard(int number)
        {
            if (cards.Count >= number)
            {
                return cards[number - 1];

            }
            return null;
        }

        internal void Reset(Card card)
        {
            cards.RemoveAll(c => c is not null);
            cards.Add(card);
        }

        internal bool HasFiveCards()
        {
            return cards.Count == 5;
        }
    }
}