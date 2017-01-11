using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCardGameKata;

namespace CardGame.Tests
{
    [TestClass]
    public class DeckOfCardTests
    {
        [TestMethod]
        public void ShuffleChangesTheOrderOfTheCards()
        {
            // Arrange
            var cardsBeforeShuffle = Enumerable.Range(1, 10).ToList();
            DeckOfCards deckOfCards = new DeckOfCards(cardsBeforeShuffle);

            // Act
            deckOfCards.Shuffle();

            // Assert
            Assert.IsFalse(cardsBeforeShuffle.TrueForAll(x => x == deckOfCards.Cards[cardsBeforeShuffle.IndexOf(x)]));
        }

        [TestMethod]
        public void CardsAreDealtInAlternateOrder()
        {
            // Arrange
            DeckOfCards deckOfCards = new DeckOfCards(Enumerable.Range(1, 10));

            // Act
            List<List<int>> dealtCards = deckOfCards.Deal(2);

            // Assert
            Assert.AreEqual(1, dealtCards[0][0]);
            Assert.AreEqual(3, dealtCards[0][1]);
            Assert.AreEqual(5, dealtCards[0][2]);
            Assert.AreEqual(7, dealtCards[0][3]);
            Assert.AreEqual(9, dealtCards[0][4]);

            Assert.AreEqual(2, dealtCards[1][0]);
            Assert.AreEqual(4, dealtCards[1][1]);
            Assert.AreEqual(6, dealtCards[1][2]);
            Assert.AreEqual(8, dealtCards[1][3]);
            Assert.AreEqual(10, dealtCards[1][4]);
        }
    }
}