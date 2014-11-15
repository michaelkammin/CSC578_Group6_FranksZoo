using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FranksZooGame.Classes
{
    public class Card : IComparable
    {
        public string CardName { get; set; }
        public int CardRank { get; set; }

        public Card() { }

        public Card(string name)
        {
            CardName = name;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
