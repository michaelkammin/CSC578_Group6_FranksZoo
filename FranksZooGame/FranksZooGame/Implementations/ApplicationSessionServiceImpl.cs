using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;
using FranksZooGame.Interfaces;

namespace FranksZooGame.Implementations
{
    public class ApplicationSessionServiceImpl : IApplicationSessionService
    {
        private User[] _currentUsers;
        private Game _currentGame;

        public void SetCurrentUsers(Classes.User[] currentUsers)
        {
            throw new NotImplementedException();
        }

        public Classes.User[] GetCurrentUsers()
        {
            throw new NotImplementedException();
        }

        public void SetCurrentGame(Classes.Game game)
        {
            throw new NotImplementedException();
        }

        public Classes.Game GetCurrentGame()
        {
            throw new NotImplementedException();
        }
    }
}
