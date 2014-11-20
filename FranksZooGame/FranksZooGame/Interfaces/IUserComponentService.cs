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

        /// <summary>
        /// Finds the user with the highest score.
        /// </summary>
        /// <param name="currentUsers">The list of current users.</param>
        /// <returns>The user with the highest score.</returns>
        User FindUserWithHighestScore(List<User> currentUsers);

        /// <summary>
        /// Checks to determine if winning scores exist to end the game.
        /// </summary>
        /// <param name="currentUsers">The list of current users.</param>
        /// <param name="scoreToCheck">The score which represents a winning score.</param>
        /// <param name="numberOfPlayers">The number of players who need to have winning scores to end the game.</param>
        /// <returns>True if the specified number of players have the specified score, otherwise false.</returns>
        bool CheckForWinningScores(List<User> currentUsers,int scoreToCheck,int numberOfPlayers);

        /// <summary>
        /// Adds a card to a user's hand.
        /// </summary>
        /// <param name="user">The user who's hand the card is added to.</param>
        /// <param name="card">The card to add to the user's hand.</param>
        void AddCard(User user, Card card);

        /// <summary>
        /// Removes a card from the user's hand.
        /// </summary>
        /// <param name="user">The user whose hand will be updated.</param>
        /// <param name="card">The card to remove.</param>
        void RemoveCard(User user, Card card);

        /// <summary>
        /// Finds the highest hand position in the list of users. Hand position represents the order the user exited the hand.
        /// </summary>
        /// <param name="currentUsers">The list of current users.</param>
        /// <returns>The highest existing hand position.</returns>
        int FindHighestHandPosition(List<User> currentUsers);

        /// <summary>
        /// Adds points to the user's current score.
        /// </summary>
        /// <param name="user">The user to add the points for.</param>
        /// <param name="score">The number of points to add.</param>
        void AddToCurrentScore(User user, int score);

        /// <summary>
        /// Resets a user.
        /// </summary>
        /// <param name="user">The user to reset.</param>
        void ResetUser(User user);

        /// <summary>
        /// Gets the number of cards in a user's hand.
        /// </summary>
        /// <param name="user">The user to get the number of cards for.</param>
        /// <returns>The number of cards in the users hand.</returns>
        int GetNumberOfCards(User user);

        /// <summary>
        /// Adds a trick to the user's list of tricks.
        /// </summary>
        /// <param name="user">The user to add the trick to.</param>
        /// <param name="trick">The trick to add.</param>
        void AddTrick(User user, Trick trick);

        /// <summary>
        /// Resets the user's list of tricks.
        /// </summary>
        /// <param name="user">The user to reset tricks for.</param>
        void ResetTricks(User user);
    }
}
