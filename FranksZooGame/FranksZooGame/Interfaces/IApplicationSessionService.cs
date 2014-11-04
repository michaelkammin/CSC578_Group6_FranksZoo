using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;

namespace FranksZooGame.Interfaces
{
    interface IApplicationSessionService
    {
        void SetCurrentUsers(User[] currentUsers);
        User[] GetCurrentUsers();
        void SetCurrentGame(Game game);
        Game GetCurrentGame();
    }
}
