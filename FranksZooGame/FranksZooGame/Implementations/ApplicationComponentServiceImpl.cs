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
        private const string START_FILE_PATH = @"C:\Courses\CSC578\Group Project\FranksZoo\CSC578_Group6_FranksZoo\FranksZooGame\FranksZooGame\Implementations\PlayerData.txt";
        private const string LOG_FILE_PATH = @"C:\Courses\CSC578\Group Project\FranksZoo\CSC578_Group6_FranksZoo\FranksZooGame\FranksZooGame\Implementations\\GameLog.txt";

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

        public bool CheckMaxUserCount(List<User> currentUsers)
        {
            return _userComponentService.CheckMaxUserCount(currentUsers, MAX_USER_COUNT);
        }

        public bool CanUserBeAdded(string userName, List<User> currentUsers)
        {
            return this.IsUserNameValid(userName) && this.CheckMaxUserCount(currentUsers);
        }

        public List<User> AddUser(string userName, List<User> currentUsers)
        {
            if (CanUserBeAdded(userName,currentUsers))
            {
                _applicationSessionService.SetCurrentUsers(_userComponentService.AddUser(userName, currentUsers));
            }
            else throw new Exception("User cannot be added.");

            return _applicationSessionService.GetCurrentUsers();
        }

        public List<User> AddUser(string userName, List<Card> hand, List<User> currentUsers)
        {
            if (CanUserBeAdded(userName,currentUsers))
            {
                _applicationSessionService.SetCurrentUsers(_userComponentService.AddUser(userName, hand, currentUsers));
            }
            else throw new Exception("User cannot be added.");

            return _applicationSessionService.GetCurrentUsers();
        }

        public List<User> RemoveUser(string userName, List<User> currentUsers)
        {
            return _userComponentService.RemoveUser(userName, currentUsers);
        }

        public List<User> GetCurrentUsers()
        {
            return _applicationSessionService.GetCurrentUsers();
        }

        public Game StartGame()
        {
            throw new NotImplementedException();
        }

        public Game StartGameFromFile()
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
            List<User> currentUsers = new List<User>();

            //string filePath = @"C:\Courses\CSC578\Group Project\FranksZoo\CSC578_Group6_FranksZoo\FranksZooGame\FranksZooGame\Implementations\PlayerData.txt";

            StreamReader file = new StreamReader(START_FILE_PATH);

            string line;
            int counter = 0;

            User dealer = null;

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
                        //Card[] playerCards = new Card[15];

                        List<Card> playerCards = new List<Card>();

                        for (int i = 0; i < cards.Length;i++)
                        {
                            playerCards.Add(new Card(cards[i]));
                        }

                        AddUser(playerName, playerCards, currentUsers);

                        counter++;
                    }
                    else
                    {
                        // dealer setting
                        dealer = _userComponentService.FindUser(info[1], _applicationSessionService.GetCurrentUsers());
                    }
                }
            }

            _applicationSessionService.SetCurrentGame(currentGame);
            _applicationSessionService.SetCurrentUsers(currentUsers);
            _applicationSessionService.SetDealer(dealer);

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

        public User SelectRandomDealer(List<User> currentUsers)
        {
            Random random = new Random();
            int randomNumber = random.Next(0,currentUsers.Count());

            return currentUsers[randomNumber];
        }

        public void DealCards(List<User> players, Deck deck)
        {
            while (deck.Cards.Count > 0)
            {
                foreach(User player in players)
                {
                    _userComponentService.AddCard(player, _gameComponentService.DealHand(deck));
                }
            }
        }

        public User DetermineNextPlayer(List<User> currentPlayers, User currentPlayer)
        {
            // if there is only one or zero players with cards in their hand, return null
            if (currentPlayers.Where(x => x.UserHand.Count > 0).Count() <= 1) return null;

            // get the index of the current player
            int currentPlayerIndex = currentPlayers.IndexOf(currentPlayers.First(x => x.UserName == currentPlayer.UserName));

            // set the index of the next player
            int nextPlayerIndex = currentPlayerIndex + 1;

            // if equal to the end of the list, set back to zero
            if (nextPlayerIndex == MAX_USER_COUNT) nextPlayerIndex = 0;

            return currentPlayers[nextPlayerIndex];
        }

        public void StartHand(Game currentGame, User currentPlayer)
        {
            LogAndWriteToConsole("Starting hand...\n\n");

            // bypass the shuffling if the player's hands are populated from the file.
            if (currentPlayer.UserHand.Count == 0)
            {
                LogAndWriteToConsole("Shuffling cards...\n\n");
                Deck deck = ShuffleDeck(CreateDeck());
                LogAndWriteToConsole("Dealing cards...\n\n");
                DealCards(_applicationSessionService.GetCurrentUsers(), deck);
            }

            StartRound(currentGame, currentPlayer);
        }

        public void StartRound(Game currentGame, User currentPlayer)
        {
            LogAndWriteToConsole("Starting round...\n\n");

            while (currentPlayer != null)
            {
                currentPlayer = TakeTurn(currentGame,currentPlayer);
            }

            Play activePlay = _gameComponentService.GetActivePlay(currentGame);
            
            // check to see if there are any active players left
            User nextUser = DetermineNextPlayer(_applicationSessionService.GetCurrentUsers(), activePlay.ActiveUser);

            EndRound(currentGame);

            if (nextUser == null)
                EndHand(currentGame);
            else
                StartRound(currentGame, activePlay.ActiveUser);
        }

        public User TakeTurn(Game currentGame, User currentPlayer)
        {
            if (currentPlayer == null) return null;

            Play activePlay = _gameComponentService.GetActivePlay(currentGame);

            if (activePlay != null)
            {
                if (activePlay.ActiveUser.UserName == currentPlayer.UserName)
                {
                    LogAndWriteToConsole(activePlay.ActiveUser.UserName + " wins a trick!\n\n");

                    return null;
                }
            }

            if (currentPlayer.UserHand.Count == 0) return TakeTurn(currentGame, DetermineNextPlayer(_applicationSessionService.GetCurrentUsers(), currentPlayer));

            List<Card> play = _gameComponentService.CheckPlayerHand(activePlay == null ? null : activePlay.Cards, currentPlayer.UserHand);

            if (play != null)
            {
                _gameComponentService.SetActivePlay(play, currentPlayer, currentGame);

                LogAndWriteToConsole(currentPlayer.UserName + " makes a play:\n\n");

                foreach (Card card in play)
                {
                    LogAndWriteToConsole(card.CardName);
                    _userComponentService.RemoveCard(currentPlayer, card);
                }

                LogAndWriteToConsole("\n");

                if (currentPlayer.UserHand.Count == 0)
                {
                    int highestHandPosition = _userComponentService.FindHighestHandPosition(_applicationSessionService.GetCurrentUsers());
                    currentPlayer.HandPosition = highestHandPosition + 1;
                }

                return TakeTurn(currentGame, DetermineNextPlayer(_applicationSessionService.GetCurrentUsers(), currentPlayer));
            }
            else
            {
                return TakeTurn(currentGame, PlayerPass(currentGame, currentPlayer));
            }
        }

        public User PlayerPass(Game currentGame, User currentPlayer)
        {
            LogAndWriteToConsole(currentPlayer.UserName + " passes...\n\n");
            return DetermineNextPlayer(_applicationSessionService.GetCurrentUsers(), currentPlayer);
        }

        public Trick EndRound(Game currentGame)
        {
            LogAndWriteToConsole("Round ends.\n\n");
            return _gameComponentService.EndRound(currentGame);
        }

        public void AddTrick(Trick trick, User player)
        {
            _userComponentService.AddTrick(player, trick);
        }

        public void EndHand(Game currentGame)
        {
            LogAndWriteToConsole("Hand ends...\n\n");

            foreach(User user in _applicationSessionService.GetCurrentUsers())
            {
                if (user.UserHand.Count == 0 && user.HandPosition > 0)
                {
                    int score = _applicationSessionService.GetCurrentUsers().Count - (user.HandPosition - 1);

                    _userComponentService.AddToCurrentScore(user, score);
                }

                _userComponentService.ResetUser(user);
            }
        }

        public User CalculateNextDealer(List<User> currentPlayers, User winner)
        {
            return _userComponentService.FindUserWithHighestScore(currentPlayers);
        }

        public void EndGame(Game currentGame)
        {
            LogAndWriteToConsole("Game over!\n\nResults:\n\n");

            foreach (User player in _applicationSessionService.GetCurrentUsers())
            {
                LogAndWriteToConsole(player.UserName + " score is " + player.CurrentScore.ToString() + ".\n");
            }
        }

        public void RunGame()
        {
            Game game = this.StartGameFromFile();

            // create a game results log file, close the file so writes can occur
            FileStream fileStream = File.Create(LOG_FILE_PATH);
            fileStream.Close();

            LogAndWriteToConsole("Game started at: " + DateTime.Now.ToString() + "\n\n");

            LogAndWriteToConsole("Start game from file...\n\n");
            LogAndWriteToConsole("Players are:\n\n");

            foreach (User player in _applicationSessionService.GetCurrentUsers())
            {
                LogAndWriteToConsole(player.UserName + "\n");
            }

            LogAndWriteToConsole("\n");

            LogAndWriteToConsole("Dealer is: " + _applicationSessionService.GetDealer().UserName + "\n\n");

            User firstPlayer = this.DetermineNextPlayer(_applicationSessionService.GetCurrentUsers(), _applicationSessionService.GetDealer());

            while (!_userComponentService.CheckForWinningScores(_applicationSessionService.GetCurrentUsers(),19,2))
            {
                StartHand(game, firstPlayer);
            }

            EndGame(game);
        }
    
        public void LogAndWriteToConsole(string line)
        {
            using (StreamWriter file = new StreamWriter(LOG_FILE_PATH,true))
            {
                file.WriteLine(line);
            }

            Console.WriteLine(line);
        }
    }
}
