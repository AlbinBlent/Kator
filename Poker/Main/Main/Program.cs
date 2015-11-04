using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker;

namespace Main
{
    class Program
    {
        private static void Main(string[] args)
        {
            var deck = new CardDeck();
            var dealer = new Dealer(deck);

            List<PlayingCard> hand;
            int numberOfShuffles = 0;
            do
            {
                numberOfShuffles++;
                dealer.ShuffleDeck();
                hand = dealer.DrawCards();
            } while (Dealer.FourOfAKindOfNumber(hand, 3) == false);
            Console.WriteLine("Done after: " + numberOfShuffles);
            Console.ReadLine();
        }
    }
}
