using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FranksZooGame.Classes
{
    public class User
    {
        public string UserName { get; set; }

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
