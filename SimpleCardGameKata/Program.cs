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
            Console.WriteLine("Hello and welcome!");

            Console.WriteLine("Please enter the number of players.");
            int numPlayers = 2;
            try
            {
                numPlayers = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("That's not a number! Using default of " + numPlayers);
            }
            int numHands = numPlayers + 1;

            Console.WriteLine("");
            Console.WriteLine("Please enter the number of cards per player.");
            int numCardsPerPlayer = 5;
            try
            {
                numCardsPerPlayer = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("That's not a number! Using default of " + numCardsPerPlayer);
            }
            int numCards = numHands * numCardsPerPlayer;
            var deckOfCards = new DeckOfCards(Enumerable.Range(1, numCards));

            Console.WriteLine("");
            Console.WriteLine("Here is the start deck: " + CardsAsString(deckOfCards.Cards));

            deckOfCards.Shuffle();
            Console.WriteLine("Here is the shuffled deck: " + CardsAsString(deckOfCards.Cards));
            Console.WriteLine("");

            List<List<int>> allCards = deckOfCards.Deal(numHands);
            List<int> playerCards = allCards[1];
            Console.WriteLine("You are player number 1.");
            Console.WriteLine("Here are the cards you have been dealt: " + CardsAsString(playerCards));
            Console.WriteLine("");

            Console.WriteLine("Enter 'k' to play a kitty card.");
            Console.WriteLine("Enter 'exit' to exit.");

            string userInput = Console.ReadLine();
            Game game = new Game(allCards);
            while (userInput.ToUpper() != "EXIT")
            {
                try
                {
                    int kittyCard = game.PlayKittyCard();
                    Console.WriteLine("Next kitty card: " + kittyCard);
                    Console.WriteLine("");

                    Console.WriteLine("Please enter all bids for all players, separated by commas.");
                    try
                    {
                        IEnumerable<int> bids = Console.ReadLine().Split(',').Select(x => int.Parse(x));
                        var winner = game.MakeBids(bids.ToList());
                        Console.WriteLine("The winner is player " + winner.PlayerNumber);
                        Console.WriteLine("The winner's score is " + winner.Score);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    
                    Console.WriteLine("");
                    Console.WriteLine("Enter 'k' to play another kitty card.");
                    Console.WriteLine("Enter 'exit' to exit.");
                }
                catch (EmptyHandException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("No cards left in kitty.");
                    Console.WriteLine("Enter 'exit' to exit.");
                }
                userInput = Console.ReadLine();
            }
        }

        private static object CardsAsString(IEnumerable<int> deckOfCards)
        {
            return String.Join(",", deckOfCards.Select(x => x.ToString()));
        }
    }
}
