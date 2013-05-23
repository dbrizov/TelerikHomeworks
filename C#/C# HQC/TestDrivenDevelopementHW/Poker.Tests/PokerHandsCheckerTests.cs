using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class PokerHandsCheckerTests
    {
        [TestMethod]
        public void TestIsValidHand_TwoEqualCards2()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestIsValidHand_NoEqualCards()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestIsValidHand_TwoEqualCards()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestIsValidHand_ThreeEqualCards()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestIsValidHand_FourEqualCards()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestIsValidHand_FiveEqualCards()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestIsFlush_HandIsStraightFlush()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsFlush(hand));
        }

        [TestMethod]
        public void TestIsFlush_Hearts()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.IsFlush(hand));
        }

        [TestMethod]
        public void TestIsFlush_Spades()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.IsFlush(hand));
        }

        [TestMethod]
        public void TestIsFlush_Clubs()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.IsFlush(hand));
        }

        [TestMethod]
        public void TestIsFlush_Diamonds()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.IsFlush(hand));
        }

        [TestMethod]
        public void TestIsFlush_HandIsNotFlush()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsFlush(hand));
        }

        [TestMethod]
        public void TestIsFlush_HandIsNotValid()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsFlush(hand));
        }

        [TestMethod]
        public void TestIsStraight_HandIsNotValid()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsStraight(hand));
        }

        [TestMethod]
        public void TestIsStraight_HandIsStraightFlush()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsStraight(hand));
        }

        [TestMethod]
        public void TestIsStraight_HandIsFlush()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsStraight(hand));
        }

        [TestMethod]
        public void TestIsStraight_HandIsStraight()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.IsStraight(hand));
        }

        [TestMethod]
        public void TestIsStraightFlush_HandIsNotValid()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void TestIsStraightFlush_HandIsFlushOnly()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void TestIsStraightFlush_HandIsStraightOnly()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void TestIsStraightFlush_HandIsStraightFlush()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void TestIsFourOfAKind_HandIsFourOfAKind()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestIsFourOfAKind_HandIsNotValid()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestIsFourOfAKind_HandIsNotFourOfAKind()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestIsFullHouse_IsFullHouse1()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.IsFullHouse(hand));
        }

        [TestMethod]
        public void TestIsFullHouse_IsFullHouse2()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.IsFullHouse(hand));
        }

        [TestMethod]
        public void TestIsFullHouse_HandIsNotFullHouse()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsFullHouse(hand));
        }

        [TestMethod]
        public void TestIsFullHouse_HandIsNotValid()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsFullHouse(hand));
        }

        [TestMethod]
        public void TestIsThreeOfAKind_HandIsNotValid()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void TestIsThreeOfAKind_HandIsFullHouse()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void TestIsThreeOfAKind_HandIsFourOfAkind()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void TestIsThreeOfAKind_HandIsThreeOfAKind()
        {
            Hand hand = new Hand(
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void TestIsOnePair_HandIsThreeOfAKind()
        {
            Hand hand = new Hand(
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestIsOnePair_HandIsTwoPair()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestIsOnePair_HandIsFourOfAKind()
        {
            Hand hand = new Hand(
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestIsOnePair_HandIsNotValid()
        {
            Hand hand = new Hand(
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestIsOnePair_HandIsHighCard()
        {
            Hand hand = new Hand(
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestIsOnePair_HandIsOnePair()
        {
            Hand hand = new Hand(
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestIsHighCard_HandIsOnePair()
        {
            Hand hand = new Hand(
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsHighCard(hand));
        }

        [TestMethod]
        public void TestIsHighCard_HandIsStraight()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsHighCard(hand));
        }

        [TestMethod]
        public void TestIsHighCard_HandIsStraightFlush()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsHighCard(hand));
        }

        [TestMethod]
        public void TestIsHighCard_HandIsFlush()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsHighCard(hand));
        }

        [TestMethod]
        public void TestIsHighCard_HandIsNotValid()
        {
            Hand hand = new Hand(
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsHighCard(hand));
        }

        [TestMethod]
        public void TestIsHighCard_HandIsHighCard()
        {
            Hand hand = new Hand(
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.IsHighCard(hand));
        }

        [TestMethod]
        public void TestIsTwoPair_TheSingleCardIsFirstWhenHandIsOrdered()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.IsTwoPair(hand));
        }

        [TestMethod]
        public void TestIsTwoPair_TheSingleCardIsInTheMiddleWhenHandIsOrdered()
        {
            Hand hand = new Hand(
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.IsTwoPair(hand));
        }

        [TestMethod]
        public void TestIsTwoPair_TheSingleCardIsLastWhenHandIsOrdered()
        {
            Hand hand = new Hand(
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.IsTwoPair(hand));
        }

        [TestMethod]
        public void TestIsTwoPair_HandIsNotValid()
        {
            Hand hand = new Hand(
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsTwoPair(hand));
        }

        [TestMethod]
        public void TestIsTwoPair_HandIsThreeOfAKind()
        {
            Hand hand = new Hand(
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsTwoPair(hand));
        }

        [TestMethod]
        public void TestIsTwoPair_HandIsFullHouse1()
        {
            Hand hand = new Hand(
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsTwoPair(hand));
        }

        [TestMethod]
        public void TestIsTwoPair_HandIsFullHouse2()
        {
            Hand hand = new Hand(
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsTwoPair(hand));
        }

        [TestMethod]
        public void TestCheckHandTypeHighCard_HandIsHighCard()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            HandType expected = HandType.HighCard;
            HandType actual = handsChecker.CheckHandType(hand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCheckHandTypeOnePair_HandIsOnePair()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            HandType expected = HandType.OnePair;
            HandType actual = handsChecker.CheckHandType(hand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCheckHandTypeTwoPair_HandIsTwoPair()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            HandType expected = HandType.TwoPair;
            HandType actual = handsChecker.CheckHandType(hand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCheckHandTypeThreeOfAKind_HandIsThreeOfAKind()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            HandType expected = HandType.ThreeOfAKind;
            HandType actual = handsChecker.CheckHandType(hand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCheckHandTypeStraight_HandIsStraight()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            HandType expected = HandType.Straight;
            HandType actual = handsChecker.CheckHandType(hand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCheckHandTypeStraight_HandIsStraightFlush()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            HandType expected = HandType.Straight;
            HandType actual = handsChecker.CheckHandType(hand);

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void TestCheckHandTypeFlush_HandIsFlush()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            HandType expected = HandType.Flush;
            HandType actual = handsChecker.CheckHandType(hand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCheckHandTypeFlush_HandIsStraightFlush()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            HandType expected = HandType.Flush;
            HandType actual = handsChecker.CheckHandType(hand);

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void TestCheckHandTypeFullHouse_HandIsFullHouse()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Clubs)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            HandType expected = HandType.FullHouse;
            HandType actual = handsChecker.CheckHandType(hand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCheckHandTypeFullHouse_HandIsThreeOfAKind()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Clubs)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            HandType expected = HandType.FullHouse;
            HandType actual = handsChecker.CheckHandType(hand);

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void TestCheckHandTypeFourOfAKind_HandIsFourOfAKind()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Clubs)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            HandType expected = HandType.FourOfAKind;
            HandType actual = handsChecker.CheckHandType(hand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCheckHandTypeStraightFlush_HandIsStraightFlush()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            HandType expected = HandType.StraightFlush;
            HandType actual = handsChecker.CheckHandType(hand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCheckHandTypeStraightFlush_HandIsStraightOnly()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            HandType expected = HandType.StraightFlush;
            HandType actual = handsChecker.CheckHandType(hand);

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void TestCheckHandTypeStraightFlush_HandIsFlushOnly()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            HandType expected = HandType.StraightFlush;
            HandType actual = handsChecker.CheckHandType(hand);

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestCheckHandType_HandIsNotValid()
        {
            Hand hand = new Hand(
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            HandType handType = handsChecker.CheckHandType(hand);
        }

        [TestMethod]
        public void TestCompareHands_EqualHighCardHands()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = 0;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_HighCardFirstIsBigger()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = 1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_HighCardSecondIsBigger()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = -1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_EqualOnePairHands()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = 0;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_OnePairSecondIsBigger()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = -1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_OnePairFirstIsBigger()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = 1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_EqualTwoPairHands()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = 0;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_TwoPairFirstIsBigger()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = 1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_TwoPairSecondIsBigger()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = -1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_EqualThreeOfAKindHands()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = 0;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_ThreeOfAKindSecondIsBigger()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = -1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_ThreeOfAKindFirstIsBigger()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = 1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_EqualStraightHands()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = 0;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_StraightFirstIsBigger()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Clubs)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = 1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_StraightSecondIsBigger()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Clubs)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = -1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_EqualFlushHands()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = 0;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_FlushFirstIsBigger()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = 1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_FlushSecondIsBigger()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = -1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_EqualFullHouseHands()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = 0;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_FullHouseFirstIsBigger()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = 1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_FullHouseSecondIsBigger()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = -1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_EqualFourOfAKindHands()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = 0;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_FourOfAKindFirstIsBigger()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = 1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_FourOfAKindSecondIsBigger()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Spades)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = -1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_EqualStraighFlushtHands()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = 0;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_StraightFlushFirstIsBigger()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = 1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_StraightFlushSecondIsBigger()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = -1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_HighCardVsOnePair()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = -1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_OnePairVsHighCard()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Diamonds)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = 1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_OnePairVsTwoPair()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = -1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_TwoPairVsTreeOfAKind()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = -1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_ThreeOfAKindVsStraight()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = -1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_StraightVsFlush()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = -1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_FlushVsFullHouse()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Clubs)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = 1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_FullHouseVsFourOfAKind()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = -1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareHands_FourOfAKindVsStraightFlush()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            int expected = -1;
            int actual = handsChecker.CompareHands(firstHand, secondHand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestCompareHands_AtLeastOneHandIsNotValid()
        {
            Hand firstHand = new Hand(
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs)
            );

            Hand secondHand = new Hand(
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts)
            );

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            handsChecker.CompareHands(firstHand, secondHand);
        }
    }
}