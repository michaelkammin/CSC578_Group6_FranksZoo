using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FranksZooGame.Classes
{
    public class Card
    {
        public string CardName { get; set; }

        public Card() { }

        public Card(string name)
        {
            CardName = name;
        }
    }
}
