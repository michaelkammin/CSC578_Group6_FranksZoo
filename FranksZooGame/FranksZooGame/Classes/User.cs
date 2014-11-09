using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FranksZooGame.Classes
{
    public class User
    {
        public string UserName { get; set; }

        public List<Card> UserHand;

        public int CurrentScore { get; set; }

        public int PreviousScore { get; set; }

        public User()
        {
            UserName = "";
            UserHand = new List<Card>();
        }
        public User(string name, List<Card> cards)
        {
            UserName = name;
            UserHand = cards;
        }

        public override string ToString()
        {
            StringBuilder userString = new StringBuilder(UserName);

            userString.Append("\n\n");
            userString.Append("Hand: ");

            userString.Append("\n\n");

            return userString.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is User)
            {
                User otherUser = (User)obj;

                return otherUser.UserName == this.UserName;
            }

            return false;
        }
    }
}
