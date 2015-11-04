using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class CardDeck : List<PlayingCard>
    {
        public CardDeck()
        {
            AddCardsToDeck();
        }

        private void AddCardsToDeck()
        {
            for (int i = 0; i < 52; i++)
            {
                int suitValue = i/13;
                if (suitValue == 0)
                {
                    this.Add(new PlayingCard("Spade", i+1));
                } else if (suitValue == 1)
                {
                    this.Add(new PlayingCard("Heart", (i%13)+1));
                } else if (suitValue == 2)
                {
                    this.Add(new PlayingCard("Dimond", (i % 13)+1));
                } else if (suitValue == 3)
                {
                    this.Add(new PlayingCard("Club", (i%13)+1));
                }
            }
        }
    }
}
