using System;
using System.Collections.Generic;

namespace SimpleCardGameKata
{
    public class Game
    {
        private readonly List<List<int>> _dealtCards = new List<List<int>>();
        private readonly List<int> _kittyCards;
        private int _lastPlayedKittyCard;

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
            try
            {
                _lastPlayedKittyCard = _kittyCards[_kittyCards.Count - 1];
                _kittyCards.RemoveAt(_kittyCards.Count - 1);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new EmptyHandException();
            }

            return _lastPlayedKittyCard;
        }

        public Winner MakeBids(int bid)
        {
            return new Winner
            {
                PlayerNumber = 1,
                Score = _lastPlayedKittyCard
            };
        }
    }
}