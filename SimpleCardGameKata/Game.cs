using System.Collections.Generic;

namespace SimpleCardGameKata
{
    public class Game
    {
        private readonly List<List<int>> _dealtCards;
        private readonly List<int> _kittyCards;

        public Game(List<List<int>> dealtCards)
        {
            _dealtCards = dealtCards;
            _kittyCards = _dealtCards[0];
        }

        public int PlayKittyCard()
        {
            return _kittyCards[_kittyCards.Count - 1];
        }
    }
}