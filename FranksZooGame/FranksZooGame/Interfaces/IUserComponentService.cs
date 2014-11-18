using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;

namespace FranksZooGame.Interfaces
{
    public interface IUserComponentService
    {
        /// <summary>
        /// Adds a user to the list of current users.
        /// </summary>
        /// <param name="userName">The user name of the user to add.</param>
        /// <param name="currentUsers">The list of current users.</param>
        /// <returns>The list of current users with the new user added.</returns>
        List<User> AddUser(string userName, List<User> currentUsers);

        /// <summary>
        /// Adds a user to the list of current users and populates the user's hand.
        /// </summary>
        /// <param name="userName">The user name of the users to add.</param>
        /// <param name="hand">The user's hand.</param>
        /// <param name="currentUsers">The list of current users.</param>
        /// <returns>The list of current users with the new user added.</returns>
        List<User> AddUser(string userName, List<Card> hand, List<User> currentUsers);

        /// <summary>
        /// Removes a user from the list of current users.
        /// </summary>
        /// <param name="userName">The user name of the user to remove.</param>
        /// <param name="currentUsers">The list of current users.</param>
        /// <returns>The list of current users with the user removed.</returns>
        List<User> RemoveUser(string userName, List<User> currentUsers);

        /// <summary>
        /// Finds a user based on user name.
        /// </summary>
        /// <param name="userName">The user name of the user to find.</param>
        /// <param name="currrentUsers">The list of current users to search.</param>
        /// <returns>The user with a matching user name.</returns>
        User FindUser(string userName, List<User> currrentUsers);

        /// <summary>
        /// Verifies user name is valid.
        /// </summary>
        /// <param name="userName">The user name to verify.</param>
        /// <returns>True if the user name is valid, otherwise false.</returns>
        bool IsUserNameValid(string userName);

        /// <summary>
        /// Checks the count of the user list is below a maximum limit.
        /// </summary>
        /// <param name="currentUsers">The list of users to count.</param>
        /// <param name="maxUserCount">The max user count.</param>
        /// <returns>True if the number of users is less than or equal to the max user count, otherwise false.</returns>
        bool CheckMaxUserCount(List<User> currentUsers, int maxUserCount);

        /// <summary>
        /// Checks the count of the user list is above a minimum limit.
        /// </summary>
        /// <param name="currentUsers">The list of users to count.</param>
        /// <param name="minUserCount">The min user count.</param>
        /// <returns>True if the number of users is greater than or equal to the min user count, otherwise false.</returns>
        bool CheckMinUserCount(List<User> currentUsers, int minUserCount);

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
