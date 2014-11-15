using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FranksZooGame.Classes
{
    public class Deck
    {
        public Queue<Card> Cards { get; set; }

        public Deck()
        {
            this.Cards = new Queue<Card>();

            for (int c = 0; c < 5; c++)
            {
                Cards.Enqueue(new Card("Elephant"));
                Cards.Enqueue(new Card("Whale"));
                Cards.Enqueue(new Card("Mouse"));
                Cards.Enqueue(new Card("Fish"));
                Cards.Enqueue(new Card("Hedgehog"));
                Cards.Enqueue(new Card("Perch"));
                Cards.Enqueue(new Card("Fox"));
                Cards.Enqueue(new Card("Seal"));
                Cards.Enqueue(new Card("Lion"));
                Cards.Enqueue(new Card("Polar Bear"));
                Cards.Enqueue(new Card("Crocodile"));
            }
            for (int c = 0; c < 4; c++)
            {
                Cards.Enqueue(new Card("Mosquitoes"));
            }
            Cards.Enqueue(new Card("Joker"));
        }
    }
}
