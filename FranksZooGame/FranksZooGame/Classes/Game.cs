using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FranksZooGame.Classes
{
    public class Game
    {
        public Play _activePlay { get; set; }
        private List<Card> _helpSet;
        private List<Play> _PlayHistory;
        private List<Trick> _tricks;
        private List<Winner> _winners;

        public List<Card> getHelpSet()
        {
            return _helpSet;
        }
        public void setHelpset(List<Card> list)
        {
            _helpSet = list;
        }
        public List<Play> getPlayHistory()
        {
            return _PlayHistory;
        }
        public void setHelpset(List<Play> list)
        {
            _PlayHistory = list;
        }
        public List<Trick> getTricks()
        {
            return _tricks;
        }
        public void setTricks(List<Trick> list)
        {
            _tricks = list;
        }
        public List<Winner> getWinners()
        {
            return _winners;
        }
        public void setWinners(List<Winner> list)
        {
            _winners = list;
        }
    }
}
