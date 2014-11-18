using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FranksZooGame.Classes
{
    public class Play
    {
        public List<Card> Cards { get; set; }
        public User ActiveUser { get; set; }

        public Play()
        {
            Cards = new List<Card>();
            ActiveUser = null;
        }

        public Play(List<Card> cards, User user)
        {
            Cards = new List<Card>();
            Cards.AddRange(cards);

            ActiveUser = user;
        }
    }
}
