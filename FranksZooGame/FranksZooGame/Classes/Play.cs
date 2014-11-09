using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FranksZooGame.Classes
{
    public class Play
    {
        private List<Card> _cards;
        private User _user { get; set; }

        public Play()
        {
            _cards = new List<Card>();
            _user = null;
        }
        public Play(List<Card> card, User user)
        {
            _cards.AddRange(card);
            _user = user;
        }
        public List<Card> getCards()
        {
            return _cards;
        }
        public void setCards(List<Card> list)
        {
            _cards = list;
        }
    }
}
