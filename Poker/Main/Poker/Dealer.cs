using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Dealer
    {
        public CardDeck Deck { get; set; }

        public Dealer(CardDeck deck)
        {
            Deck = deck;
        }

        public void ShuffleDeck()
        {
            var rnd = new Random();
            var rndDeck = new CardDeck();
            rndDeck.Clear();
            while (Deck.Count > 0)
            {
                var rndThis = rnd.Next(Deck.Count);
                rndDeck.Add(Deck[rndThis]);
                Deck.Remove(Deck[rndThis]);
            }
            Deck = rndDeck;
        }

        public List<PlayingCard> DrawCards()
        {
            var hand = new List<PlayingCard>();
            for (int i = 0; i < 5; i++)
            {
                hand.Add(Deck[i]);
            }
            return hand;
        }

        public bool FourOfAKind(List<PlayingCard> hand)
        {
            int[] array = new int[14] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            foreach (var card in hand)
            {
                array[card.Number]++;
            }
            return array.Any(i => i == 4);
        }

        public bool FourOfAKindOfNumber(List<PlayingCard> hand, int number)
        {
            int[] array = new int[14] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            foreach (var card in hand)
            {
                array[card.Number]++;
            }
            return array.Any(i => i == 4 && i == number);
        }
    }
}
