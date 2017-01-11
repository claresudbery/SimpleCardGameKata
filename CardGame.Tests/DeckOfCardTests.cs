using System.Collections.Generic;
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
            var cardsBeforeShuffle = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            DeckOfCards deckOfCards = new DeckOfCards(cardsBeforeShuffle);

            deckOfCards.Shuffle();

            Assert.IsFalse(cardsBeforeShuffle.TrueForAll(x => x == deckOfCards.Cards[cardsBeforeShuffle.IndexOf(x)]));
        }

        [TestMethod]
        public void CardsAreDealtInAlternateOrder()
        {
            DeckOfCards deckOfCards = new DeckOfCards(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            List<List<int>> dealtCards = deckOfCards.Deal(2);

            Assert.AreEqual(dealtCards[0][0], 1);
            Assert.AreEqual(dealtCards[0][1], 3);
            Assert.AreEqual(dealtCards[0][2], 5);
            Assert.AreEqual(dealtCards[0][3], 7);
            Assert.AreEqual(dealtCards[0][4], 9);

            Assert.AreEqual(dealtCards[1][0], 2);
            Assert.AreEqual(dealtCards[1][1], 4);
            Assert.AreEqual(dealtCards[1][2], 6);
            Assert.AreEqual(dealtCards[1][3], 8);
            Assert.AreEqual(dealtCards[1][4], 10);
        }
    }
}