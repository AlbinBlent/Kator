using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Poker;

namespace Tests
{
    [TestFixture]
    public class CardDeckTests
    {
        private CardDeck _deck;
        [SetUp]
        public void Setup()
        {
            _deck = new CardDeck();
        }
        [Test]
        public void Can_create_CardDeck()
        {
            _deck.Should().NotBeNull();
        }

        [Test]
        public void CardDeck_should_contain_52_cards()
        {
            _deck.Should().HaveCount(52);
        }
    }

    [TestFixture]
    public class PlayingCardTests
    {
        private PlayingCard _card;

        [SetUp]
        public void Setup()
        {
            _card = new PlayingCard("Clubs",2);
        }

        [Test]
        public void Can_create_PlayingCard()
        {
            
            _card.Should().NotBeNull();
        }

        [Test]
        public void PlayingCard_should_have_suit_and_number()
        {
            _card.Suit.Should().NotBeNull();
            _card.Number.Should().BeGreaterOrEqualTo(1).And.BeLessOrEqualTo(13);
        }
    }

    [TestFixture]
    public class DealerTests
    {
        private Dealer _dealer; 
        [SetUp]
        public void Setup()
        {
            _dealer = new Dealer(new CardDeck());
        }
        
        [Test]
        public void Can_create_a_dealer()
        {
            _dealer.Should().NotBeNull();
        }

        [Test]
        public void Dealer_has_a_deck_of_cards()
        {
            _dealer.Deck.Should().NotBeNull();
        }

        [Test]
        public void Dealer_can_shuffle_deck()
        {
            _dealer.ShuffleDeck();
            _dealer.Deck.First().Should().NotBe(new PlayingCard("Spade", 1));
            _dealer.Deck[2].Should().NotBe(new PlayingCard("Spade", 2));
            _dealer.Deck[14].Should().NotBe(new PlayingCard("Heart", 1));

            foreach (var card in _dealer.Deck)
            {
                Console.WriteLine(card.Suit + " : " + card.Number);
            }
        }

        [Test]
        public void Dealer_can_draw_five_cards()
        {
            var fiveCards = _dealer.DrawCards();
            fiveCards.Count.Should().Be(5);
        }

        [Test]
        public void Can_get_four_of_a_kind()
        {
            var fiveCards = new List<PlayingCard>
            {
                new PlayingCard("Spade", 1),
                new PlayingCard("Spade", 1),
                new PlayingCard("Spade", 1),
                new PlayingCard("Spade", 1),
                new PlayingCard("Spade", 2)
            };

            var fourOfAKind = _dealer.FourOfAKind(fiveCards);

            fourOfAKind.Should().Be(true);
        }

        [Test]
        public void Can_get_four_of_a_kind_of_a_certain_number()
        {
            var fiveCards = new List<PlayingCard>
            {
                new PlayingCard("Spade", 1),
                new PlayingCard("Spade", 1),
                new PlayingCard("Spade", 1),
                new PlayingCard("Spade", 1),
                new PlayingCard("Spade", 2)
            };

            var fourOfAKind = _dealer.FourOfAKindOfNumber(fiveCards, 1);

            fourOfAKind.Should().Be(true);
        }
    }
}
