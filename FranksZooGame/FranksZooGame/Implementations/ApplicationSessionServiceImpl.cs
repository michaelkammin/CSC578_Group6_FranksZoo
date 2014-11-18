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
        private List<User> _currentUsers;
        private Game _currentGame;
        private User _firstDealer;

        public void SetCurrentUsers(List<User> currentUsers)
        {
            _currentUsers = currentUsers;
        }

        public List<User> GetCurrentUsers()
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

        public void SetDealer(User dealer)
        {
            _firstDealer = dealer;
        }

        public User GetDealer()
        {
            return _firstDealer;
        }
    }
}
