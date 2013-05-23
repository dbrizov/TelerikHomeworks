using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void TestToString_Hand()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades)
            );

            string expected = "10♣J♦Q♥K♠A♠";
            string actual = hand.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
