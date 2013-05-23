using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (this.ContainsEqualCards(hand))
            {
                return false;
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (this.IsValidHand(hand) == false)
            {
                return false;
            }

            bool isFlush = this.IsFlushPrivate(hand);
            bool isStraight = this.IsStraightPrivate(hand);

            return (isFlush && isStraight);
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (this.IsValidHand(hand) == false)
            {
                return false;
            }

            int mostOftenCardCount = this.GetMostOftenCardCount(hand);
            bool isFourOfAKind = (mostOftenCardCount == 4);

            return isFourOfAKind;
        }

        public bool IsFullHouse(IHand hand)
        {
            if (this.IsValidHand(hand) == false)
            {
                return false;
            }

            List<ICard> cards = this.GetSortedCards(hand);

            if (cards[0].Face == cards[1].Face &&
                cards[1].Face == cards[2].Face &&
                cards[2].Face != cards[3].Face &&
                cards[3].Face == cards[4].Face)
            {
                return true;
            }
            else if (cards[0].Face == cards[1].Face &&
                     cards[1].Face != cards[2].Face &&
                     cards[2].Face == cards[3].Face &&
                     cards[3].Face == cards[4].Face)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFlush(IHand hand)
        {
            if (this.IsValidHand(hand) == false)
            {
                return false;
            }

            bool isFlush = this.IsFlushPrivate(hand);
            bool isStraight = this.IsStraightPrivate(hand);

            return (isFlush && !isStraight);
        }

        public bool IsStraight(IHand hand)
        {
            if (this.IsValidHand(hand) == false)
            {
                return false;
            }

            bool isFlush = this.IsFlushPrivate(hand);
            bool isStraight = this.IsStraightPrivate(hand);

            return (isStraight && !isFlush);
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (this.IsValidHand(hand) == false)
            {
                return false;
            }

            int mostOftenCardCount = this.GetMostOftenCardCount(hand);
            bool isFullHouse = this.IsFullHouse(hand);

            if (mostOftenCardCount == 3 && !isFullHouse)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsTwoPair(IHand hand)
        {
            if (this.IsValidHand(hand) == false)
            {
                return false;
            }

            List<ICard> cards = this.GetSortedCards(hand);

            // The single card is last
            if (cards[0].Face == cards[1].Face &&
                cards[1].Face != cards[2].Face &&
                cards[2].Face == cards[3].Face &&
                cards[3].Face != cards[4].Face)
            {
                return true;
            }
            
            // The single card is in the middle
            if (cards[0].Face == cards[1].Face &&
                cards[1].Face != cards[2].Face &&
                cards[2].Face != cards[3].Face &&
                cards[3].Face == cards[4].Face)
            {
                return true;
            }
            
            // The single card is first
            if (cards[0].Face != cards[1].Face &&
                cards[1].Face == cards[2].Face &&
                cards[2].Face != cards[3].Face &&
                cards[3].Face == cards[4].Face)
            {
                return true;
            }

            // else there is no single card => the hand is not 2 pair
            return false;
        }

        public bool IsOnePair(IHand hand)
        {
            if (this.IsValidHand(hand) == false)
            {
                return false;
            }

            int mostOftenCardCount = this.GetMostOftenCardCount(hand);
            bool isTwoPair = this.IsTwoPair(hand);
            bool isOnePair = (mostOftenCardCount == 2 && !isTwoPair);

            return isOnePair;
        }

        public bool IsHighCard(IHand hand)
        {
            if (this.IsValidHand(hand) == false)
            {
                return false;
            }

            int mostOftenCardCount = this.GetMostOftenCardCount(hand);
            bool isStraight = this.IsStraight(hand);
            bool isFlush = this.IsFlush(hand);
            bool isStraightFlush = this.IsStraightFlush(hand);

            bool isHighCard =
                mostOftenCardCount == 1 &&
                !isStraight &&
                !isFlush &&
                !isStraightFlush;

            return isHighCard;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            if (this.IsValidHand(firstHand) == false ||
                this.IsValidHand(secondHand) == false)
            {
                throw new InvalidOperationException("Invalid hand given as argument");
            }

            int result = 0;
            HandType firstHandType = this.CheckHandType(firstHand);
            HandType secondHandType = this.CheckHandType(secondHand);

            if (firstHandType > secondHandType)
            {
                result = 1;
            }
            else if (firstHandType < secondHandType)
            {
                result = -1;
            }
            else
            {
                if (firstHandType == HandType.HighCard)
                {
                    result = this.CompareHighCardHands(firstHand, secondHand);
                }
                else if (firstHandType == HandType.OnePair)
                {
                    result = this.CompareOnePairHands(firstHand, secondHand);
                }
                else if (firstHandType == HandType.TwoPair)
                {
                    result = this.CompareTwoPairHands(firstHand, secondHand);
                }
                else if (firstHandType == HandType.ThreeOfAKind)
                {
                    result = this.CompareThreeOfAKindHands(firstHand, secondHand);
                }
                else if (firstHandType == HandType.Straight)
                {
                    result = this.CompareStraightHands(firstHand, secondHand);
                }
                else if (firstHandType == HandType.Flush)
                {
                    result = this.CompareFlushHands(firstHand, secondHand);
                }
                else if (firstHandType == HandType.FullHouse)
                {
                    result = this.CompareFullHouseHands(firstHand, secondHand);
                }
                else if (firstHandType == HandType.FourOfAKind)
                {
                    result = this.CompareFourOfAKindHands(firstHand, secondHand);
                }
                else if (firstHandType == HandType.StraightFlush)
                {
                    result = this.CompareStraightFlushHands(firstHand, secondHand);
                }
            }

            return result;
        }

        public HandType CheckHandType(IHand hand)
        {
            if (this.IsValidHand(hand) == false)
            {
                throw new InvalidOperationException("Invalid hand: " + hand.ToString());
            }

            if (this.IsHighCard(hand))
            {
                return HandType.HighCard;
            }
            else if (this.IsOnePair(hand))
            {
                return HandType.OnePair;
            }
            else if (this.IsTwoPair(hand))
            {
                return HandType.TwoPair;
            }
            else if (this.IsThreeOfAKind(hand))
            {
                return HandType.ThreeOfAKind;
            }
            else if (this.IsStraight(hand))
            {
                return HandType.Straight;
            }
            else if (this.IsFlush(hand))
            {
                return HandType.Flush;
            }
            else if (this.IsFullHouse(hand))
            {
                return HandType.FullHouse;
            }
            else if (this.IsFourOfAKind(hand))
            {
                return HandType.FourOfAKind;
            }
            else
            {
                return HandType.StraightFlush;
            }
        }

        private bool ContainsEqualCards(IHand hand)
        {
            List<ICard> cards = this.GetSortedCards(hand);

            for (int i = 0; i < cards.Count - 1; i++)
            {
                if (cards[i].Equals(cards[i + 1]))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsFlushPrivate(IHand hand)
        {
            List<ICard> cards = new List<ICard>(hand.Cards);

            int count = 1;
            CardSuit firstCardSuit = cards[0].Suit;
            for (int i = 1; i < cards.Count; i++)
            {
                if (cards[i].Suit == firstCardSuit)
                {
                    count++;
                }
            }

            return count == 5;
        }

        private bool IsStraightPrivate(IHand hand)
        {
            List<ICard> cards = this.GetSortedCards(hand);

            for (int i = 0; i < cards.Count - 1; i++)
            {
                if (cards[i + 1].Face - cards[i].Face != 1)
                {
                    return false;
                }
            }

            return true;
        }

        private int GetMostOftenCardCount(IHand hand)
        {
            List<ICard> cards = this.GetSortedCards(hand);

            int count = 1;
            int maxCount = 1;
            CardFace previousCardFace = cards[0].Face;

            for (int i = 1; i < cards.Count; i++)
            {
                if (cards[i].Face == previousCardFace)
                {
                    count++;
                }
                else
                {
                    count = 1;
                }

                if (maxCount < count)
                {
                    maxCount = count;
                }

                previousCardFace = cards[i].Face;
            }

            return maxCount;
        }

        private List<ICard> GetSortedCards(IHand hand)
        {
            var orderedCards = hand.Cards.OrderBy(x => x.Face).ThenBy(x => x.Suit);
            return new List<ICard>(orderedCards);
        }

        private int GetMaxCardFace(IHand hand)
        {
            int maxCardFace = int.MinValue;
            IList<ICard> cards = hand.Cards;

            foreach (var card in cards)
            {
                if (maxCardFace < (int)card.Face)
                {
                    maxCardFace = (int)card.Face;
                }
            }

            return maxCardFace;
        }

        private int GetCardsFacesSum(IHand hand)
        {
            int sum = 0;
            foreach (var card in hand.Cards)
            {
                sum += (int)card.Face;
            }

            return sum;
        }

        private int CompareHighCardHands(IHand firstHand, IHand secondHand)
        {
            int firstHandMaxCardFace = this.GetMaxCardFace(firstHand);
            int secondHandMaxCardFace = this.GetMaxCardFace(secondHand);

            if (firstHandMaxCardFace > secondHandMaxCardFace)
            {
                return 1;
            }
            else if (firstHandMaxCardFace < secondHandMaxCardFace)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int CompareOnePairHands(IHand firstHand, IHand secondHand)
        {
            List<ICard> firstHandCards = this.GetSortedCards(firstHand);
            List<ICard> secondHandCards = this.GetSortedCards(secondHand);

            CardFace firstHandOnePairCardFace = CardFace.Undefined;
            CardFace secondHandOnePairCardFace = CardFace.Undefined;

            CardFace previousCardFace = firstHandCards[0].Face;
            for (int i = 1; i < firstHandCards.Count; i++)
            {
                if (previousCardFace == firstHandCards[i].Face)
                {
                    firstHandOnePairCardFace = previousCardFace;
                    break;
                }

                previousCardFace = firstHandCards[i].Face;
            }

            previousCardFace = secondHandCards[0].Face;
            for (int i = 1; i < secondHandCards.Count; i++)
            {
                if (previousCardFace == secondHandCards[i].Face)
                {
                    secondHandOnePairCardFace = previousCardFace;
                    break;
                }

                previousCardFace = secondHandCards[i].Face;
            }

            if (firstHandOnePairCardFace > secondHandOnePairCardFace)
            {
                return 1;
            }
            else if (firstHandOnePairCardFace < secondHandOnePairCardFace)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int CompareTwoPairHands(IHand firstHand, IHand secondHand)
        {
            List<ICard> firstHandCards = this.GetSortedCards(firstHand);
            List<ICard> secondHandCards = this.GetSortedCards(secondHand);

            CardFace firstHandFirstPairCardFace = CardFace.Undefined;
            CardFace secondHandFirstPairCardFace = CardFace.Undefined;
            CardFace firstHandSecondPairCardFace = CardFace.Undefined;
            CardFace secondHandSecondPairCardFace = CardFace.Undefined;

            bool firstPairWasFound = false;
            CardFace previousCardFace = firstHandCards[0].Face;
            for (int i = 1; i < firstHandCards.Count; i++)
            {
                if (previousCardFace == firstHandCards[i].Face && !firstPairWasFound)
                {
                    firstPairWasFound = true;
                    firstHandFirstPairCardFace = previousCardFace;
                }

                if (previousCardFace == firstHandCards[i].Face && firstPairWasFound)
                {
                    firstHandSecondPairCardFace = previousCardFace;
                }

                previousCardFace = firstHandCards[i].Face;
            }

            firstPairWasFound = false;
            previousCardFace = secondHandCards[0].Face;
            for (int i = 1; i < secondHandCards.Count; i++)
            {
                if (previousCardFace == secondHandCards[i].Face && !firstPairWasFound)
                {
                    firstPairWasFound = true;
                    secondHandFirstPairCardFace = previousCardFace;
                }

                if (previousCardFace == secondHandCards[i].Face && firstPairWasFound)
                {
                    secondHandSecondPairCardFace = previousCardFace;
                }

                previousCardFace = firstHandCards[i].Face;
            }

            int firstTwoPairsFacesSum =
                (int)firstHandFirstPairCardFace + (int)firstHandSecondPairCardFace;
            int secondTwoPairsFacesSum =
                (int)secondHandFirstPairCardFace + (int)secondHandSecondPairCardFace;

            if (firstTwoPairsFacesSum > secondTwoPairsFacesSum)
            {
                return 1;
            }
            else if (firstTwoPairsFacesSum < secondTwoPairsFacesSum)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int CompareThreeOfAKindHands(IHand firstHand, IHand secondHand)
        {
            List<ICard> firstHandCards = this.GetSortedCards(firstHand);
            List<ICard> secondHandCards = this.GetSortedCards(secondHand);

            CardFace firstThreeOfAKindCardFace = CardFace.Undefined;
            CardFace secondThreeOfAKindCardFace = CardFace.Undefined;
            int firstCount = 1;
            int secondCount = 1;

            CardFace previousCardFace = firstHandCards[0].Face;
            for (int i = 1; i < firstHandCards.Count; i++)
            {
                if (previousCardFace == firstHandCards[i].Face)
                {
                    firstCount++;
                }
                else
                {
                    firstCount = 1;
                }

                if (firstCount == 3)
                {
                    firstThreeOfAKindCardFace = previousCardFace;
                    break;
                }

                previousCardFace = firstHandCards[i].Face;
            }

            previousCardFace = secondHandCards[0].Face;
            for (int i = 1; i < secondHandCards.Count; i++)
            {
                if (previousCardFace == secondHandCards[i].Face)
                {
                    secondCount++;
                }
                else
                {
                    secondCount = 1;
                }

                if (secondCount == 3)
                {
                    secondThreeOfAKindCardFace = previousCardFace;
                    break;
                }

                previousCardFace = secondHandCards[i].Face;
            }

            if (firstThreeOfAKindCardFace > secondThreeOfAKindCardFace)
            {
                return 1;
            }
            else if (firstThreeOfAKindCardFace < secondThreeOfAKindCardFace)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int CompareStraightHands(IHand firstHand, IHand secondHand)
        {
            List<ICard> firstHandCards = this.GetSortedCards(firstHand);
            List<ICard> secondHandCards = this.GetSortedCards(secondHand);

            if (firstHandCards[0].Face > secondHandCards[0].Face)
            {
                return 1;
            }
            else if (firstHandCards[0].Face < secondHandCards[0].Face)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int CompareFlushHands(IHand firstHand, IHand secondHand)
        {
            List<ICard> firstHandCards = this.GetSortedCards(firstHand);
            List<ICard> secondHandCards = this.GetSortedCards(secondHand);

            int firstHandCardsFacesSum = this.GetCardsFacesSum(firstHand);
            int secondHandCardsFacesSum = this.GetCardsFacesSum(secondHand);

            if (firstHandCardsFacesSum > secondHandCardsFacesSum)
            {
                return 1;
            }
            else if (firstHandCardsFacesSum < secondHandCardsFacesSum)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int CompareFullHouseHands(IHand firstHand, IHand secondHand)
        {
            List<ICard> firstHandCards = this.GetSortedCards(firstHand);
            List<ICard> secondHandCards = this.GetSortedCards(secondHand);

            int firstHandCardsFacesSum = this.GetCardsFacesSum(firstHand);
            int secondHandCardsFacesSum = this.GetCardsFacesSum(secondHand);

            if (firstHandCardsFacesSum > secondHandCardsFacesSum)
            {
                return 1;
            }
            else if (firstHandCardsFacesSum < secondHandCardsFacesSum)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int CompareFourOfAKindHands(IHand firstHand, IHand secondHand)
        {
            List<ICard> firstHandCards = this.GetSortedCards(firstHand);
            List<ICard> secondHandCards = this.GetSortedCards(secondHand);

            CardFace firstHandFourOfAKindCardFace = CardFace.Undefined;
            CardFace secondHandFourOfAKindCardFace = CardFace.Undefined;

            if (firstHandCards[0].Face == firstHandCards[1].Face)
            {
                firstHandFourOfAKindCardFace = firstHandCards[0].Face;
            }
            else
            {
                firstHandFourOfAKindCardFace = firstHandCards[1].Face;
            }

            if (secondHandCards[0].Face == secondHandCards[1].Face)
            {
                secondHandFourOfAKindCardFace = secondHandCards[0].Face;
            }
            else
            {
                secondHandFourOfAKindCardFace = secondHandCards[1].Face;
            }

            if (firstHandFourOfAKindCardFace > secondHandFourOfAKindCardFace)
            {
                return 1;
            }
            else if (firstHandFourOfAKindCardFace < secondHandFourOfAKindCardFace)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int CompareStraightFlushHands(IHand firstHand, IHand secondHand)
        {
            List<ICard> firstHandCards = this.GetSortedCards(firstHand);
            List<ICard> secondHandCards = this.GetSortedCards(secondHand);

            if (firstHandCards[0].Face > secondHandCards[0].Face)
            {
                return 1;
            }
            else if (firstHandCards[0].Face < secondHandCards[0].Face)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
