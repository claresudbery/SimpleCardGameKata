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
            var deckOfCards = new DeckOfCards(new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            Console.WriteLine("Hello and welcome!");
            Console.WriteLine("Here is the start deck: " + CardsAsString(deckOfCards.Cards));

            deckOfCards.Shuffle();
            Console.WriteLine("Here is the shuffled deck: " + CardsAsString(deckOfCards.Cards));

            List<int> playerCards = deckOfCards.Deal(numHands)[1];
            Console.WriteLine("This is a one-player game. You are the player. Here are the cards you have been dealt: " + CardsAsString(playerCards));

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        private static object CardsAsString(IEnumerable<int> deckOfCards)
        {
            return String.Join(",", deckOfCards.Select(x => x.ToString()));
        }
    }
}
