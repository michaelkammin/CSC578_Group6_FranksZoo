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
            throw new NotImplementedException();
        }

        public User[] AddUser(string userName, Card[] hand, User[] currentUsers)
        {
            User user = new User
                {
                    UserName = userName
                };

            // set up the user's hand

            int index = AvailableIndex(currentUsers);

            currentUsers[index] = user;

            return currentUsers;
        }

        public User[] RemoveUser(string userName, User[] currentUsers)
        {
            throw new NotImplementedException();
        }

        public bool IsUserNameValid(string userName)
        {
            // TODO: implement this to actually work correctly
            return true;
        }

        public bool CheckMaxUserCount(User[] currentUsers, int maxUserCount)
        {
            // TODO: implement this to work correctly
            return true;
        }

        public bool CheckMinUserCount(User[] currentUsers, int minUserCount)
        {
            throw new NotImplementedException();
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
