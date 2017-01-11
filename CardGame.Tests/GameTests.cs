using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCardGameKata;

namespace CardGame.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void FirstKittyCardPlayedIsLastCardDealtToKitty()
        {
            // Arrange
            const int numHands = 2;
            const int numCards = numHands * 5;
            DeckOfCards deckOfCards = new DeckOfCards(Enumerable.Range(1, numCards));
            List<List<int>> dealtCards = deckOfCards.Deal(numHands).ToList();
            Game game = new Game(dealtCards);

            // Act
            int firstKittyCard = game.PlayKittyCard();

            // Assert
            var kittyCards = dealtCards[0];
            var numCardsPerPlayer = numCards/numHands;
            Assert.AreEqual(kittyCards[numCardsPerPlayer - 1], firstKittyCard);
        }
    }
}