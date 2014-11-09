using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FranksZooGame.Classes
{
    public class Trick
    {
        public List<Card> TrickList;

        public Trick()
        {
            TrickList = new List<Card>();
        }
        public List<Card> getTrickList()
        {
            return TrickList;
        }
        public void setTrickList(List<Card> list)
        {
            TrickList = list;
        }
    }
}
