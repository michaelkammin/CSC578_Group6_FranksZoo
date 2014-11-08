using System;
using System.Collections.Generic;
using System.IO;
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

        public ApplicationComponentServiceImpl(IApplicationSessionService applicationSessionService, IUserComponentService userComponentService, IGameComponentService gameComponentService)
        {
            _applicationSessionService = applicationSessionService;
            _userComponentService = userComponentService;
            _gameComponentService = gameComponentService;
        }

        public bool IsUserNameValid(string userName)
        {
            return _userComponentService.IsUserNameValid(userName);
        }

        public bool CheckMaxUserCount(User[] currentUsers)
        {
            return _userComponentService.CheckMaxUserCount(currentUsers, MAX_USER_COUNT);
        }

        public bool CanUserBeAdded(string userName,User[] currentUsers)
        {
            return this.IsUserNameValid(userName) && this.CheckMaxUserCount(currentUsers);
        }

        public User[] AddUser(string userName, User[] currentUsers)
        {
            if (CanUserBeAdded(userName,currentUsers))
            {
                _applicationSessionService.SetCurrentUsers(_userComponentService.AddUser(userName, currentUsers));
            }
            else throw new Exception("User cannot be added.");

            return _applicationSessionService.GetCurrentUsers();
        }

        public User[] AddUser(string userName, Card[] hand, User[] currentUsers)
        {
            if (CanUserBeAdded(userName,currentUsers))
            {
                _applicationSessionService.SetCurrentUsers(_userComponentService.AddUser(userName, hand, currentUsers));
            }
            else throw new Exception("User cannot be added.");

            return _applicationSessionService.GetCurrentUsers();
        }

        public User[] RemoveUser(string userName, User[] currentUsers)
        {
            return _userComponentService.RemoveUser(userName, currentUsers);
        }

        public User[] GetCurrentUsers()
        {
            return _applicationSessionService.GetCurrentUsers();
        }

        public Game StartGame()
        {
            /*
             * Steps to start game:
             * 
             * 1. Accept user names from the UI and add to player list
             * 2. Choose a dealer from player list.
             * 3. Create and Shuffle Deck
             * 4. Deal cards to players
             * 5. Determine first player
             * 
             * Alternative:
             * 
             * 1. Statically create 4 players from data file
             * 2. Determine dealer from data file
             * 3. Set up players' hands from data file
             * */

            Game currentGame = new Game();
            User[] currentUsers = new User[MAX_USER_COUNT];

            string filePath = @"C:\Courses\CSC578\Group Project\FranksZoo\CSC578_Group6_FranksZoo\FranksZooGame\FranksZooGame\Implementations\PlayerData.txt";

            StreamReader file = new StreamReader(filePath);

            string line;
            int counter = 0;

            while ((line = file.ReadLine()) != null)
            {
                string[] info = line.Split(':');

                if (info.Length == 2)
                {
                    if (info[0].Contains("Player"))
                    {
                        // create a name starting from the second character to the second to last character
                        // to eliminate the brackets []
                        string playerName = info[0].Substring(1, info[0].Length - 2);

                        // these are are the player's cards
                        string[] cards = info[1].Split(',');
                        Card[] playerCards = new Card[15];

                        for (int i = 0; i < cards.Length;i++)
                        {
                            Card card = new Card();
                            card.CardName = cards[i];

                            playerCards[i] = card;
                        }

                        AddUser(playerName, playerCards, currentUsers);

                        counter++;
                    }
                    else
                    {
                        // dealer setting
                    }
                }
            }

            _applicationSessionService.SetCurrentGame(currentGame);
            _applicationSessionService.SetCurrentUsers(currentUsers);

            return currentGame;
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
