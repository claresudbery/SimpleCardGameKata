using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCardGameKata
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPlayers = 1;
            int numHands = numPlayers + 1;
            int numCards = numHands * 5;
            var deckOfCards = new DeckOfCards(Enumerable.Range(1, numCards));
            Console.WriteLine("Hello and welcome!");
            Console.WriteLine("");
            Console.WriteLine("Here is the start deck: " + CardsAsString(deckOfCards.Cards));

            deckOfCards.Shuffle();
            Console.WriteLine("Here is the shuffled deck: " + CardsAsString(deckOfCards.Cards));
            Console.WriteLine("");

            List<List<int>> allCards = deckOfCards.Deal(numHands);
            List<int> playerCards = allCards[1];
            Console.WriteLine("This is a one-player game. You are the player.");
            Console.WriteLine("Here are the cards you have been dealt: " + CardsAsString(playerCards));
            Console.WriteLine("");

            Game game = new Game(allCards);
            int kittyCard = game.PlayKittyCard();
            Console.WriteLine("First kitty card played: " + kittyCard);
            Console.WriteLine("");

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        private static object CardsAsString(IEnumerable<int> deckOfCards)
        {
            return String.Join(",", deckOfCards.Select(x => x.ToString()));
        }
    }
}
