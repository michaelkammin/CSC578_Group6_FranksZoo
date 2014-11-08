using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;

namespace FranksZooGame.Interfaces
{
    public interface IUserComponentService
    {
        User[] AddUser(string userName, User[] currentUsers);
        User[] AddUser(string userName, Card[] hand, User[] currentUsers);
        int AvailableIndex(User[] currentUsers);
        User[] RemoveUser(string userName, User[] currentUsers);
        bool IsUserNameValid(string userName);
        bool CheckMaxUserCount(User[] currentUsers, int maxUserCount);
        bool CheckMinUserCount(User[] currentUsers, int minUserCount);
    }
}
