using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;
using FranksZooGame.Interfaces;

namespace FranksZooGame.Implementations
{
    public class GameComponentServiceImpl : IGameComponentService
    {
        public Deck CreateDeck()
        {
            Deck temp = new Deck();
            return temp;
        }

        public Deck ShuffleDeck(Deck deck)
        {
            List<Card> list = new List<Card>(deck.Cards);
            deck.Cards = new Queue<Card>();

            var random = new Random();
            while (list.Count > 0)
            {
                Int32 index = random.Next(list.Count);
                Card card = list[index];
                list.RemoveAt(index);
                deck.Cards.Enqueue(card);
            }
            return deck;
        }

        public Card DealHand(Deck deck)
        {
            if (deck.Cards.Count == 0)
            {
                return null;
            }
            else
            {
                Card card = deck.Cards.Dequeue();

                return card;
            }
        }

        public List<User> StartHand(Deck deck, List<User> Users, Game game)
        {
            Users = StartRound(Users, game);
            Users.Add(Users.First());
            Users.Remove(Users.First());
            while (deck.Cards.Count != 0)
            {
                foreach (User user in Users)
                {
                    user.UserHand.Add(DealHand(deck));
                }
            }
            return Users;
        }

        public List<User> StartRound(List<User> Users, Game game)
        {
            int max = 0;
            try
            {
                max = Users.Max(str => str.PreviousScore);
            }
            catch (ArgumentNullException e)
            {
                
            }
            catch (Exception e)
            {
                
            }
            List<User> users = new List<User>();
            foreach (User user in Users)
            {
                if (user.PreviousScore == max)
                {
                    users.Add(user);
                }
                if (users.Count > 0)
                {
                    users.Add(user);
                }
            }
            foreach (User user in Users)
            {
                if(!users.Contains(user))
                {
                    users.Add(user);
                }
            }
            return users;
        }

        public Play GetActivePlay(Game game)
        {
            return game.activePlay;
        }

        public bool IsValidPlay(List<Card> activePlay, List<Card> play)
        {
            int activeWins = 0;
            int playWins = 0;
            bool isValidPlay = false;
            foreach (Card a in activePlay)
            {
                foreach (Card p in play)
                {
                    if (a == p)
                    {
                        activePlay.Remove(a);
                        play.Remove(p);
                    }
                }
            }
            #region Whales
            if (activePlay.Contains(new Card("Whale")) && play.Contains(new Card("Polar Bear")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Whale"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Polar Bear"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Whale")) && play.Contains(new Card("Seal")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Whale"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Seal"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Whale")) && play.Contains(new Card("Perch")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Whale"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Perch"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Whale")) && play.Contains(new Card("Fish")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Whale"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Fish"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Polar Bear")) && play.Contains(new Card("Whale")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Polar Bear"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Whale"));
                playWins++;
            }
            if (activePlay.Contains(new Card("Seal")) && play.Contains(new Card("Whale")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Seal"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Whale"));
                playWins++;
            }
            if (activePlay.Contains(new Card("Perch")) && play.Contains(new Card("Whale")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Perch"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Whale"));
                playWins++;
            }
            if (activePlay.Contains(new Card("Fish")) && play.Contains(new Card("Whale")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Fish"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Whale"));
                activeWins++;
            }
            #endregion
            #region Elephant
            if (activePlay.Contains(new Card("Mouse")) && play.Contains(new Card("Elephant")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Mouse"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Elephant"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Elephant")) && play.Contains(new Card("Mouse")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Elephant"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Mouse"));
                playWins++;
            }
            if (activePlay.Contains(new Card("Elephant")) && play.Contains(new Card("Crocodile")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Elephant"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Crocodile"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Elephant")) && play.Contains(new Card("Polar Bear")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Elephant"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Polar Bear"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Elephant")) && play.Contains(new Card("Lion")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Elephant"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Lion"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Elephant")) && play.Contains(new Card("Fox")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Elephant"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Fox"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Crocodile")) && play.Contains(new Card("Elephant")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Crocodile"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Elephant"));
                playWins++;
            }
            if (activePlay.Contains(new Card("Polar Bear")) && play.Contains(new Card("Elephant")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Polar Bear"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Elephant"));
                playWins++;
            }
            if (activePlay.Contains(new Card("Lion")) && play.Contains(new Card("Elephant")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Lion"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Elephant"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Fox")) && play.Contains(new Card("Elephant")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Fox"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Elephant"));
                activeWins++;
            }
            #endregion
            #region Crocodile
            if (activePlay.Contains(new Card("Crocodile")) && play.Contains(new Card("Fox")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Crocodile"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Fox"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Crocodile")) && play.Contains(new Card("Perch")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Crocodile"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Perch"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Crocodile")) && play.Contains(new Card("Fish")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Crocodile"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Fish"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Crocodile")) && play.Contains(new Card("Mouse")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Crocodile"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Mouse"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Fox")) && play.Contains(new Card("Crocodile")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Fox"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Crocodile"));
                playWins++;
            }
            if (activePlay.Contains(new Card("Perch")) && play.Contains(new Card("Crocodile")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Perch"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Crocodile"));
                playWins++;
            }
            if (activePlay.Contains(new Card("Fish")) && play.Contains(new Card("Crocodile")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Fish"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Crocodile"));
                playWins++;
            }
            if (activePlay.Contains(new Card("Mouse")) && play.Contains(new Card("Crocodile")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Mouse"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Crocodile"));
                playWins++;
            }
            #endregion
            #region Polar Bear
            if (activePlay.Contains(new Card("Polar Bear")) && play.Contains(new Card("Seal")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Polar Bear"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Seal"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Polar Bear")) && play.Contains(new Card("Fox")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Polar Bear"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Fox"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Polar Bear")) && play.Contains(new Card("Perch")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Polar Bear"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Perch"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Polar Bear")) && play.Contains(new Card("Mouse")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Polar Bear"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Mouse"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Seal")) && play.Contains(new Card("Polar Bear")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Seal"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Polar Bear"));
                playWins++;
            }
            if (activePlay.Contains(new Card("Fox")) && play.Contains(new Card("Polar Bear")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Fox"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Polar Bear"));
                playWins++;
            }
            if (activePlay.Contains(new Card("Perch")) && play.Contains(new Card("Polar Bear")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Perch"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Polar Bear"));
                playWins++;
            }
            if (activePlay.Contains(new Card("Mouse")) && play.Contains(new Card("Polar Bear")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Mouse"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Polar Bear"));
                playWins++;
            }
            #endregion
            #region Lion
            if (activePlay.Contains(new Card("Lion")) && play.Contains(new Card("Fox")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Lion"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Fox"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Lion")) && play.Contains(new Card("Mouse")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Lion"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Mouse"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Fox")) && play.Contains(new Card("Lion")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Fox"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Lion"));
                playWins++;
            }
            if (activePlay.Contains(new Card("Mouse")) && play.Contains(new Card("Lion")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Mouse"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Lion"));
                playWins++;
            }
            #endregion
            #region Seal
            if (activePlay.Contains(new Card("Seal")) && play.Contains(new Card("Perch")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Seal"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Perch"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Seal")) && play.Contains(new Card("Fish")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Seal"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Fish"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Seal")) && play.Contains(new Card("Mouse")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Seal"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Mouse"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Perch")) && play.Contains(new Card("Seal")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Perch"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Seal"));
                playWins++;
            }
            if (activePlay.Contains(new Card("Fish")) && play.Contains(new Card("Seal")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Fish"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Seal"));
                playWins++;
            }
            if (activePlay.Contains(new Card("Mouse")) && play.Contains(new Card("Seal")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Mouse"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Seal"));
                playWins++;
            }
            #endregion
            #region Fox
            if (activePlay.Contains(new Card("Fox")) && play.Contains(new Card("Hedgehog")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Fox"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Hedgehog"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Fox")) && play.Contains(new Card("Mouse")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Fox"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Mouse"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Hedgehog")) && play.Contains(new Card("Fox")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Hedgehog"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Fox"));
                playWins++;
            }
            if (activePlay.Contains(new Card("Mouse")) && play.Contains(new Card("Fox")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Mouse"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Fox"));
                playWins++;
            }
            #endregion
            #region Perch
            if (activePlay.Contains(new Card("Perch")) && play.Contains(new Card("Fish")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Perch"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Fish"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Fish")) && play.Contains(new Card("Perch")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Fish"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Perch"));
                playWins++;
            }
            #endregion
            #region Hedgehog
            if (activePlay.Contains(new Card("Hedgehog")) && play.Contains(new Card("Mouse")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Hedgehog"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Mouse"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Hedgehog")) && play.Contains(new Card("Mosquito")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Hedgehog"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Mosquito"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Mouse")) && play.Contains(new Card("Hedgehog")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Mouse"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Hedgehog"));
                playWins++;
            }
            if (activePlay.Contains(new Card("Mosquito")) && play.Contains(new Card("Hedgehog")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Mosquito"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Hedgehog"));
                playWins++;
            }
            #endregion
            #region Fish
            if (activePlay.Contains(new Card("Fish")) && play.Contains(new Card("Mosquito")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Fish"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Mosquito"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Mosquito")) && play.Contains(new Card("Fish")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Mosquito"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Fish"));
                playWins++;
            }
            #endregion
            #region Mouse
            if (activePlay.Contains(new Card("Mouse")) && play.Contains(new Card("Mosquito")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Mouse"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Mosquito"));
                activeWins++;
            }
            if (activePlay.Contains(new Card("Mosquito")) && play.Contains(new Card("Mouse")))
            {
                activePlay.Remove(activePlay.FirstOrDefault(str => str.CardName == "Mosquito"));
                play.Remove(play.FirstOrDefault(str => str.CardName == "Mouse"));
                playWins++;
            }
            #endregion
            while (activePlay.Count != play.Count)
            {
                if (activePlay.Count > play.Count)
                {
                    activePlay.RemoveAt(0);
                    activeWins++;
                }
                else
                {
                    play.RemoveAt(0);
                    playWins++;
                }
            }
            if (activeWins >= playWins)
            {
                isValidPlay = false;
            }
            else
            {
                isValidPlay = true;
            }
            return isValidPlay;
        }

        public void SetActivePlay(Card[] play, User user, Game game)
        {
            Play currentPlay = new Play(play.ToList(), user);
            game.activePlay = currentPlay;
        }

        public Card[] CheckPlayerHand(Card[] activePlay, Card[] play)
        {
            if(IsValidPlay(activePlay.ToList(), play.ToList()))
            {
                return play;
            }
            else
            {
                return activePlay;
            }
        }

        public Trick EndRound(Game game)
        {
            return game.getTricks().Last();
        }

        public User EndHand(Game game)
        {
            int max = 0;
            User user = new User();
            List<User> temp = new List<User>();
            foreach (Winner winner in game.getWinners())
            {
                temp.Add(winner._winner);
            }
            max = temp.Max(str => str.CurrentScore);
            foreach (User temp2 in temp)
            {
                if (temp2.CurrentScore == max)
                {
                    user = temp2;
                }
            }
            return user;
        }

        public void EndGame(Game game)
        {
            string command = "";
            do
            {
                Console.WriteLine("Would You Like To Start A New Game Yes or No");
                command = Console.ReadLine();
                if (command.ToUpper() == "YES" || command.ToUpper() == "Y")
                {
                    IApplicationComponentService applicationComponent = new ApplicationComponentServiceImpl(new ApplicationSessionServiceImpl(), new UserComponentServiceImpl(), new GameComponentServiceImpl());

                    applicationComponent.StartGame();

                    User[] currentUsers = applicationComponent.GetCurrentUsers();

                    foreach (User user in currentUsers)
                    {
                        Console.WriteLine(user.ToString());
                    }
                }
                else if (command.ToUpper() == "NO" || command.ToUpper() == "N")
                {
                    Console.WriteLine("Thank You So Much For Playing");
                }
            } while (command.ToUpper() != "NO" || command.ToUpper() != "N" || command.ToUpper() == "YES" || command.ToUpper() == "Y");
        }
    }
}
