using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{

    public class PlayingCard
    {
        public string Suit { get; set; }
        public int Number { get; set; } 

        public PlayingCard(string suit, int number)
        {
            this.Suit = suit;
            this.Number = number;
        }
    }
}
