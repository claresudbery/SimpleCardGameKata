using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SimpleCardGameKata;

namespace CardGame.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
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