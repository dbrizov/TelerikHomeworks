using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(params ICard[] cards)
        {
            this.Cards = new List<ICard>(cards);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < this.Cards.Count; i++)
            {
                result.Append(this.Cards[i].ToString());
            }

            return result.ToString();
        }
    }
}
