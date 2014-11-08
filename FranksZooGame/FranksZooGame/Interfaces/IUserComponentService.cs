using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;

namespace FranksZooGame.Interfaces
{
    interface IUserComponentService
    {
        User[] AddUser(string userName, User[] currentUsers);
        User[] RemoveUser(string userName, User[] currentUsers);
        bool IsUserNameValid(string userName);
        bool CheckMaxUserCount(User[] currentUsers, int maxUserCount);
        bool CheckMinUserCount(User[] currentUsers, int minUserCount);
    }
}
