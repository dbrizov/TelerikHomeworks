using System;

namespace Poker
{
    public interface ICard
    {
        CardFace Face { get; }
        CardSuit Suit { get; }
        string ToString();
        int CompareFaceTo(ICard card);
        int CompareSuitTo(ICard card);
    }
}
