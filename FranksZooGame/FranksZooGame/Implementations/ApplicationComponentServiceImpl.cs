using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;
using FranksZooGame.Interfaces;

namespace FranksZooGame.Implementations
{
    public class ApplicationComponentServiceImpl : IApplicationComponentService
    {
        private const int MIN_USER_COUNT = 4;
        private const int MAX_USER_COUNT = 4;

        private IApplicationSessionService _applicationSessionService;
        private IUserComponentService _userComponentService;
        private IGameComponentService _gameComponentService;

        public User[] AddUser(string userName, User[] currentUsers)
        {
            if (_userComponentService.IsUserNameValid(userName))
            {
                if (_userComponentService.CheckMaxUserCount(_applicationSessionService.GetCurrentUsers(), MAX_USER_COUNT))
                {
                    _applicationSessionService.SetCurrentUsers(_userComponentService.AddUser(userName, _applicationSessionService.GetCurrentUsers()));
                }
                else throw new Exception("Too many users.");
            }
            else throw new Exception("Invalid user name.");

            return _applicationSessionService.GetCurrentUsers();
        }

        public User[] RemoveUser(string userName, User[] currentUsers)
        {
            return _userComponentService.RemoveUser(userName, _applicationSessionService.GetCurrentUsers());
        }

        public User[] GetCurrentUsers()
        {
            return _applicationSessionService.GetCurrentUsers();
        }

        public Game StartGame()
        {
            throw new NotImplementedException();
        }

        public Deck CreateDeck()
        {
            return _gameComponentService.CreateDeck();
        }

        public Deck ShuffleDeck(Deck deck)
        {
            return _gameComponentService.ShuffleDeck(deck);
        }

        public User SelectRandomDealer(User[] currentUsers)
        {
            Random random = new Random();
            int randomNumber = random.Next(0,currentUsers.Count());

            return currentUsers[randomNumber];
        }

        public void DealCards(User[] players, Deck deck)
        {
            throw new NotImplementedException();
        }

        public User DetermineNextPlayer(User[] currentPlayers, User currentPlayer)
        {
            throw new NotImplementedException();
        }

        public void StartHand(Game currentGame, User currentPlayer)
        {
            throw new NotImplementedException();
        }

        public void StartRound(Game currentGame, User currentPlayer)
        {
            throw new NotImplementedException();
        }

        public User TakeTurn(Game currentGame, User currentPlayer)
        {
            throw new NotImplementedException();
        }

        public User PlayerPass(Game currentGame, User currentPlayer)
        {
            throw new NotImplementedException();
        }

        public Trick EndRound(Game currentGame)
        {
            throw new NotImplementedException();
        }

        public void AddTrick(Trick trick, User player)
        {
            throw new NotImplementedException();
        }

        public void EndHand(Game currentGame, User player)
        {
            throw new NotImplementedException();
        }

        public User CalculateNextDealer(User[] currentPlayers, User winner)
        {
            throw new NotImplementedException();
        }

        public void EndGame(Game currentGame)
        {
            throw new NotImplementedException();
        }

        public void RunGame()
        {
            throw new NotImplementedException();
        }
    }
}
