using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;

namespace FranksZooGame.Interfaces
{
    public interface IUserComponentService
    {
        List<User> AddUser(string userName, List<User> currentUsers);
        List<User> AddUser(string userName, List<Card> hand, List<User> currentUsers);
        int AvailableIndex(User[] currentUsers);
        List<User> RemoveUser(string userName, List<User> currentUsers);
        User FindUser(string userName, List<User> currrentUsers);
        bool IsUserNameValid(string userName);
        bool CheckMaxUserCount(List<User> currentUsers, int maxUserCount);
        bool CheckMinUserCount(List<User> currentUsers, int minUserCount);
        int FindHighestScore(List<User> currentUsers);
        int FindSecondHighestScore(List<User> currentUsers, int highestScore);
        User FindUserWithHighestScore(List<User> currentUsers);

        bool CheckForWinningScores(List<User> currentUsers,int scoreToCheck,int numberOfPlayers);

        /// <summary>
        /// Adds a card to a user's hand.
        /// </summary>
        /// <param name="user">The user who's hand the card is added to.</param>
        /// <param name="card">The card to add to the user's hand.</param>
        void AddCard(User user, Card card);

        void RemoveCard(User user, Card card);

        int FindHighestHandPosition(List<User> currentUsers);

        void AddToCurrentScore(User user, int score);
        void ResetUser(User user);
        int GetNumberOfCards(User user);
        void AddTrick(User user, Trick trick);
        void ResetTricks(User user);
    }
}
