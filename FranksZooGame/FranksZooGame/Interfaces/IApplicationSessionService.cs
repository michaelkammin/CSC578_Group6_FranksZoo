using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;

namespace FranksZooGame.Interfaces
{
    public interface IApplicationSessionService
    {
        void SetCurrentUsers(List<User> currentUsers);
        List<User> GetCurrentUsers();
        void SetCurrentGame(Game game);
        Game GetCurrentGame();
        void SetDealer(User dealer);
        User GetDealer();
    }
}
