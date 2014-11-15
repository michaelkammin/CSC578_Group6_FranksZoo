using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;
using FranksZooGame.Interfaces;

namespace FranksZooGame.Implementations
{
    public class UserComponentServiceImpl : IUserComponentService
    {
        public User[] AddUser(string userName, User[] currentUsers)
        {
            User user = new User(userName);

            int index = AvailableIndex(currentUsers);

            currentUsers[index] = user;

            return currentUsers;

        }

        public User[] AddUser(string userName, Card[] hand, User[] currentUsers)
        {
            User user = new User(userName, hand.ToList());

            int index = AvailableIndex(currentUsers);

            currentUsers[index] = user;

            return currentUsers;
        }

        public User[] RemoveUser(string userName, User[] currentUsers)
        {
            for (int i = 0; i< currentUsers.Length;i++)
            {
                if (currentUsers[i].UserName.Equals(userName))
                {
                    Array.Clear(currentUsers,i,1);
                    return currentUsers;
                }
            }
            // The userName was not in the array. Might want to throw an Exception here instead of null
            return null;
        }

        public bool IsUserNameValid(string userName)
        {
            // This method only checks the 15 character limit
            if (userName.Length < -15)
                return true;
            else
                return false;
        }

        public bool CheckMaxUserCount(User[] currentUsers, int maxUserCount)
        {
            if (currentUsers.Length <= maxUserCount)
                return true;
            else
                return false;
        }

        public bool CheckMinUserCount(User[] currentUsers, int minUserCount)
        {
            if (currentUsers.Length >=minUserCount)
                return true;
            else
                return false;
        }


        public int AvailableIndex(User[] currentUsers)
        {
            for (int i = 0; i < currentUsers.Length; i++)
            {
                if (currentUsers[i] == null) return i;
            }

            return -1;
        }
    }
}
