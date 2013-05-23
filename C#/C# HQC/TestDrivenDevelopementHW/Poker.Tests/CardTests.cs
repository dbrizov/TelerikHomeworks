using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void TestToString_TwoOfSpades()
        {
            Card card = new Card(CardFace.Two, CardSuit.Spades);
            string expected = "2♠";
            string actual = card.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToString_TenOfHearts()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Hearts);
            string expected = "10♥";
            string actual = card.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToString_JackOfDiamonds()
        {
            Card card = new Card(CardFace.Jack, CardSuit.Diamonds);
            string expected = "J♦";
            string actual = card.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToString_AceOfClubs()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Clubs);
            string expected = "A♣";
            string actual = card.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEquals_AreEqual()
        {
            Card card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card card2 = new Card(CardFace.Ace, CardSuit.Clubs);

            Assert.AreEqual(true, card1.Equals(card2));
        }

        [TestMethod]
        public void TestEquals_HaveDifferentFaces()
        {
            Card card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card card2 = new Card(CardFace.Ten, CardSuit.Clubs);

            Assert.AreEqual(false, card1.Equals(card2));
        }

        [TestMethod]
        public void TestEquals_HaveDifferentSuits()
        {
            Card card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card card2 = new Card(CardFace.Ace, CardSuit.Diamonds);

            Assert.AreEqual(false, card1.Equals(card2));
        }

        [TestMethod]
        public void TestEquals_GivenArgumentIsNotACard()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Clubs);
            object someObj = 5;

            Assert.AreEqual(false, card.Equals(someObj));
        }

        [TestMethod]
        public void TestCompareFaceTo_LessFace()
        {
            Card card1 = new Card(CardFace.King, CardSuit.Clubs);
            Card card2 = new Card(CardFace.Ace, CardSuit.Hearts);
            int expected = -1;
            int actual = card1.CompareFaceTo(card2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareFaceTo_EqualFace()
        {
            Card card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card card2 = new Card(CardFace.Ace, CardSuit.Hearts);
            int expected = 0;
            int actual = card1.CompareFaceTo(card2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareFaceTo_BiggerFace()
        {
            Card card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card card2 = new Card(CardFace.King, CardSuit.Hearts);
            int expected = 1;
            int actual = card1.CompareFaceTo(card2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareSuitTo_LessSuit()
        {
            Card card1 = new Card(CardFace.King, CardSuit.Clubs);
            Card card2 = new Card(CardFace.Ace, CardSuit.Hearts);
            int expected = -1;
            int actual = card1.CompareSuitTo(card2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareSuitTo_EqualSuit()
        {
            Card card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card card2 = new Card(CardFace.Ace, CardSuit.Clubs);
            int expected = 0;
            int actual = card1.CompareSuitTo(card2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCompareSuitTo_BiggerSuit()
        {
            Card card1 = new Card(CardFace.Ace, CardSuit.Spades);
            Card card2 = new Card(CardFace.King, CardSuit.Hearts);
            int expected = 1;
            int actual = card1.CompareSuitTo(card2);

            Assert.AreEqual(expected, actual);
        }
    }
}
