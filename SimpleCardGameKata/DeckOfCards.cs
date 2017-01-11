using System;
using System.Collections.Generic;

namespace SimpleCardGameKata
{
    public class DeckOfCards
    {
        public List<int> Cards = new List<int>();

        public DeckOfCards(List<int> initialDeck)
        {
            foreach (var card in initialDeck)
            {
                Cards.Add(card);
            }
        }

        public void Shuffle()
        {
            int index = Cards.Count;
            while (index > 1)
            {
                index--;
                Random randomNumberGenerator = new Random();
                int randomSwapIndex = randomNumberGenerator.Next(index + 1);

                int value = Cards[randomSwapIndex];
                Cards[randomSwapIndex] = Cards[index];
                Cards[index] = value;
            }
        }

        public List<List<int>> Deal(int numberOfHands)
        {
            var dealtCards = new List<List<int>>();

            for (int playerCount = 1; playerCount <= numberOfHands; playerCount++)
            {
                dealtCards.Add(new List<int>());
            }

            int playerIndex = 0;
            foreach (var card in Cards)
            {
                dealtCards[playerIndex].Add(card);
                playerIndex = (playerIndex + 1) % numberOfHands;
            }

            return dealtCards;
        }
    }
}
