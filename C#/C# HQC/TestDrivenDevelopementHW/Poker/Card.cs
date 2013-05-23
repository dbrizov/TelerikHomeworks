using System;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Card))
            {
                return false;
            }

            Card objAsCard = obj as Card;
            if (this.Face == objAsCard.Face &&
                this.Suit == objAsCard.Suit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public int CompareFaceTo(ICard card)
        {
            if (this.Face < card.Face)
            {
                return -1;
            }
            else if (this.Face > card.Face)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int CompareSuitTo(ICard card)
        {
            if (this.Suit < card.Suit)
            {
                return -1;
            }
            else if (this.Suit > card.Suit)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            string cardFace = this.GetFaceAsString();
            string cardSuit = this.GetSuitAsString();
            string result = cardFace + cardSuit;

            return result;
        }

        private string GetFaceAsString()
        {
            string faceAsString = string.Empty;
            if ((int)this.Face <= 10)
            {
                faceAsString += (int)this.Face;
            }
            else
            {
                char faceFirstLetter = this.Face.ToString()[0];
                faceAsString += faceFirstLetter;
            }

            return faceAsString;
        }

        private string GetSuitAsString()
        {
            string suitAsString = string.Empty;
            switch (this.Suit)
            {
                case CardSuit.Clubs:
                    suitAsString += '♣';
                    break;
                case CardSuit.Diamonds:
                    suitAsString += '♦';
                    break;
                case CardSuit.Hearts:
                    suitAsString += '♥';
                    break;
                case CardSuit.Spades:
                    suitAsString += '♠';
                    break;
                default:
                    throw new InvalidOperationException("Invalid suit: " + this.Suit);
            }

            return suitAsString;
        }
    }
}
