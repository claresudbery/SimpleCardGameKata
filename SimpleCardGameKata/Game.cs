using System;
using System.Collections.Generic;

namespace SimpleCardGameKata
{
    public class Game
    {
        private readonly List<List<int>> _dealtCards = new List<List<int>>();
        private readonly List<int> _kittyCards;

        public Game(List<List<int>> dealtCards)
        {
            foreach (var hand in dealtCards)
            {
                List<int> newHand = new List<int>();
                foreach (var card in hand)
                {
                    newHand.Add(card);
                }
                _dealtCards.Add(newHand);
            }
            _kittyCards = _dealtCards[0];
        }

        public int PlayKittyCard()
        {
            int cardPlayed = 0;

            try
            {
                cardPlayed = _kittyCards[_kittyCards.Count - 1];
                _kittyCards.RemoveAt(_kittyCards.Count - 1);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new EmptyHandException();
            }

            return cardPlayed;
        }
    }
}