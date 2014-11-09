using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FranksZooGame.Classes
{
    public class Winner
    {
        public User _winner { get; set; }
        public int _exitOrder { get; set; }

        public Winner()
        {
            _winner = null;
            _exitOrder = 0;
        }
        public Winner(User winner, int exitOrder)
        {
            _winner = winner;
            _exitOrder = exitOrder;
        }
    }
}
