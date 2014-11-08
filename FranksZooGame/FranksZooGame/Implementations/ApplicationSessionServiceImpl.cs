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

        public void SetCurrentUsers(User[] currentUsers)
        {
            _currentUsers = currentUsers;
        }

        public User[] GetCurrentUsers()
        {
            return _currentUsers;
        }

        public void SetCurrentGame(Game game)
        {
            _currentGame = game;
        }

        public Game GetCurrentGame()
        {
            return _currentGame;
        }
    }
}
