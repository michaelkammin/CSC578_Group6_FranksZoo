using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;
using FranksZooGame.Interfaces;

namespace FranksZooGame.Implementations
{
    public class UserComponentServiceImpl : IUserComponentService
    {
        public List<User> AddUser(string userName, List<User> currentUsers)
        {
            currentUsers.Add(new User(userName));

            return currentUsers;
        }

        public List<User> AddUser(string userName, List<Card> hand, List<User> currentUsers)
        {
            currentUsers.Add(new User(userName, hand));

            return currentUsers;
        }

        public List<User> RemoveUser(string userName, List<User> currentUsers)
        {
            currentUsers.Remove(currentUsers.First(x => x.UserName == userName));

            return currentUsers;
        }

        public bool IsUserNameValid(string userName)
        {
            // This method only checks the 15 character limit
            if (userName.Length < 15)
                return true;
            else
                return false;
        }

        public bool CheckMaxUserCount(List<User> currentUsers, int maxUserCount)
        {
            return currentUsers.Count < maxUserCount;
        }

        public bool CheckMinUserCount(List<User> currentUsers, int minUserCount)
        {
            return currentUsers.Count > minUserCount;
        }

        public User FindUser(string userName, List<User> currrentUsers)
        {
            return currrentUsers.First(x => x.UserName == userName);
        }

        public void AddCard(User user, Card card)
        {
            user.UserHand.Add(card);
        }

        public void AddToCurrentScore(User user, int score)
        {
            user.PreviousScore = user.CurrentScore;
            user.CurrentScore += score;
        }

        public int GetNumberOfCards(User user)
        {
            return user.UserHand.Count();
        }

        public void AddTrick(User user, Trick trick)
        {
            user.Tricks.Add(trick);
        }

        public void ResetTricks(User user)
        {
            user.Tricks.Clear();
        }

        public User FindUserWithHighestScore(List<User> currentUsers)
        {
            int highestScore = 0;
            List<User> usersWithHighestCore = new List<User>();

            User userWithHighestScore = currentUsers.First();

            foreach (User user in currentUsers)
            {
                if (user.CurrentScore == highestScore)
                {
                    usersWithHighestCore.Add(user);
                }
                else if (user.CurrentScore > highestScore)
                {
                    usersWithHighestCore.Clear();
                    usersWithHighestCore.Add(user);
                }
            }

            if (usersWithHighestCore.Count == 1) return usersWithHighestCore[0];

            if (usersWithHighestCore.Count > 1)
            {
                User userWithLowestPreviousScore = usersWithHighestCore[1];

                foreach (User user in usersWithHighestCore)
                {
                    if (user.PreviousScore < userWithLowestPreviousScore.PreviousScore)
                    {
                        userWithLowestPreviousScore = user;
                    }
                }

                return userWithLowestPreviousScore;
            }

            // nothing worked, pick someone at random
            Random random = new Random();

            int randomIndex = random.Next(0, currentUsers.Count);

            return currentUsers[randomIndex];
        }

        public void RemoveCard(User user, Card card)
        {
            user.UserHand.Remove(user.UserHand.First(x => x.CardName == card.CardName));
        }

        public int FindHighestHandPosition(List<User> currentUsers)
        {
            int highestHandPosition = 1;

            foreach(User user in currentUsers)
            {
                if (user.HandPosition > highestHandPosition)
                {
                    highestHandPosition = user.HandPosition;
                }
            }

            return highestHandPosition;
        }

        public void ResetUser(User user)
        {
            user.HandPosition = 0;
            user.UserHand.Clear();
        }

        public bool CheckForWinningScores(List<User> currentUsers, int scoreToCheck, int numberOfPlayers)
        {
            return currentUsers.FindAll(x => x.CurrentScore >= scoreToCheck).ToList().Count >= numberOfPlayers;
        }
    }
}
