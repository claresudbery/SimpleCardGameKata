﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using SimpleCardGameKata;
using Assert = NUnit.Framework.Assert;

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

        //      numHands,   numCardsPerPlayer,  kittyCardIndex, expectedKittyCard
        [TestCase(2,        5,                  1,              9)]
        [TestCase(2,        5,                  2,              7)]
        [TestCase(2,        5,                  3,              5)]
        [TestCase(2,        5,                  4,              3)]
        [TestCase(2,        5,                  5,              1)]
        [TestCase(6,        5,                  1,              25)]
        [TestCase(6,        5,                  2,              19)]
        [TestCase(6,        5,                  3,              13)]
        [TestCase(6,        5,                  4,              7)]
        [TestCase(6,        5,                  5,              1)]
        public void KittyCardsArePlayedInReverseOrder(int numHands, int numCardsPerPlayer, int kittyCardIndex, int expectedKittyCard)
        {
            // Arrange
            int numCards = numHands * numCardsPerPlayer;
            DeckOfCards deckOfCards = new DeckOfCards(Enumerable.Range(1, numCards));
            List<List<int>> dealtCards = deckOfCards.Deal(numHands).ToList();
            Game game = new Game(dealtCards);

            // Act
            int kittyCardPlayed = 0;
            for (int kittyCardCount = 1; kittyCardCount <= kittyCardIndex; kittyCardCount++)
            {
                kittyCardPlayed = game.PlayKittyCard();
            }

            // Assert
            var kittyCards = dealtCards[0];
            Assert.AreEqual(kittyCards[numCardsPerPlayer - kittyCardIndex], kittyCardPlayed);
        }

        [Test]
        public void WhenKittyHandIsEmptyExceptionIsThrown()
        {
            // Arrange
            const int numHands = 2;
            const int numCards = numHands * 1;
            DeckOfCards deckOfCards = new DeckOfCards(Enumerable.Range(1, numCards));
            List<List<int>> dealtCards = deckOfCards.Deal(numHands).ToList();
            Game game = new Game(dealtCards);

            // Act & Assert
            game.PlayKittyCard();
            Assert.Throws<EmptyHandException>(() => game.PlayKittyCard());
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        public void Given1PlayerGame_AllBidsWin(int bid)
        {
            // Arrange
            const int numHands = 2;
            const int numCards = numHands * 1;
            DeckOfCards deckOfCards = new DeckOfCards(Enumerable.Range(1, numCards));
            List<List<int>> dealtCards = deckOfCards.Deal(numHands).ToList();
            Game game = new Game(dealtCards);

            // Act & Assert
            int kittyCard = game.PlayKittyCard();
            Winner winner = game.MakeBids(new List<int>{bid});

            // Assert
            Assert.AreEqual(1, winner.PlayerNumber);
            Assert.AreEqual(kittyCard, winner.Score);
        }

        [TestCase(2, 1)]
        [TestCase(2, 2)]
        [TestCase(5, 1)]
        [TestCase(5, 3)]
        public void GivenMultiPlayerGame_HighestBidWins(int numPlayers, int winningPlayer)
        {
            // Arrange
            const int numHands = 2;
            const int numCards = numHands * 1;
            DeckOfCards deckOfCards = new DeckOfCards(Enumerable.Range(1, numCards));
            List<List<int>> dealtCards = deckOfCards.Deal(numHands).ToList();
            Game game = new Game(dealtCards);
            var bids = new List<int>();
            for (int count = 1; count <= numPlayers; count++)
            {
                bids.Add(1);
            }
            bids[winningPlayer - 1] = 10;

            // Act & Assert
            int kittyCard = game.PlayKittyCard();
            Winner winner = game.MakeBids(bids);

            // Assert
            Assert.AreEqual(winningPlayer, winner.PlayerNumber);
            Assert.AreEqual(kittyCard, winner.Score);
        }
    }
}