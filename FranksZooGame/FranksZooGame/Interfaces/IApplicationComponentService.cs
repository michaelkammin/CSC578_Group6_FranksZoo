using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;

namespace FranksZooGame.Interfaces
{
    public interface IApplicationComponentService
    {
        /// <summary>
        /// Determines if a user name is valid.
        /// </summary>
        /// <param name="userName">The user name to validate.</param>
        /// <returns>True if user name is valid, otherwise false.</returns>
        bool IsUserNameValid(string userName);

        /// <summary>
        /// Checks if the max number of users are already set for the game.
        /// </summary>
        /// <param name="currentUsers">A list of the current users.</param>
        /// <returns>True if the max number of users has not been reached, otherwise false.</returns>
        bool CheckMaxUserCount(List<User> currentUsers);

        /// <summary>
        /// Determines if user can be added by verifying user name and user count.
        /// </summary>
        /// <param name="userName">The user name for the user to be added.</param>
        /// <param name="currentUsers">The list of current users.</param>
        /// <returns>True if the user can be added, otherwise false.</returns>
        bool CanUserBeAdded(string userName, List<User> currentUsers);

        /// <summary>
        /// Adds user to the current list of users.
        /// </summary>
        /// <param name="userName">The user to add.</param>
        /// <param name="currentUsers">The list to add the user to.</param>
        /// <returns>An updated list with the new user added.</returns>
        List<User> AddUser(string userName, List<User> currentUsers);

        /// <summary>
        /// Adds a user with a hand of cards.
        /// </summary>
        /// <param name="userName">The user name of the user to add.</param>
        /// <param name="hand">The hand to add for the user.</param>
        /// <param name="currentUsers">The list to add the user to.</param>
        /// <returns>An updated list with the new user added.</returns>
        List<User> AddUser(string userName, List<Card> hand, List<User> currentUsers);

        /// <summary>
        /// Removes a user from the list of current users.
        /// </summary>
        /// <param name="userName">The user name of the user to remove.</param>
        /// <param name="currentUsers">The list of users to remove the user from.</param>
        /// <returns>The list of users with the user removed.</returns>
        List<User> RemoveUser(string userName, List<User> currentUsers);

        /// <summary>
        /// Gets a list of the current users.
        /// </summary>
        /// <returns>The list of current users.</returns>
        List<User> GetCurrentUsers();

        /// <summary>
        /// Starts a game.
        /// </summary>
        /// <returns>The game which was started.</returns>
        Game StartGame();

        /// <summary>
        /// Creates a deck.
        /// </summary>
        /// <returns>The deck which was created.</returns>
        Deck CreateDeck();

        /// <summary>
        /// Shuffles a deck.
        /// </summary>
        /// <param name="deck">The deck to shuffle.</param>
        /// <returns>A shuffled deck.</returns>
        Deck ShuffleDeck(Deck deck);

        /// <summary>
        /// Selects a random dealer from a list of users.
        /// </summary>
        /// <param name="currentUsers">The list of current users.</param>
        /// <returns>The user representing the dealer.</returns>
        User SelectRandomDealer(List<User> currentUsers);

        /// <summary>
        /// Deals cards to players.
        /// </summary>
        /// <param name="players">The players to deal cards to.</param>
        /// <param name="deck">The deck to deal cards from.</param>
        void DealCards(List<User> players, Deck deck);

        /// <summary>
        /// Determines the next player from the list of players based on the current player.
        /// </summary>
        /// <param name="currentPlayers">The list of players.</param>
        /// <param name="currentPlayer">The current player.</param>
        /// <returns>The next player to take a turn.</returns>
        User DetermineNextPlayer(List<User> currentPlayers, User currentPlayer);

        /// <summary>
        /// Starts a hand.
        /// </summary>
        /// <param name="currentGame">The game to start the hand in.</param>
        /// <param name="currentPlayer">The first player in the hand.</param>
        void StartHand(Game currentGame, User currentPlayer);

        /// <summary>
        /// Starts a round.
        /// </summary>
        /// <param name="currentGame">The current game to start the round in.</param>
        /// <param name="currentPlayer">The first player in the hand.</param>
        void StartRound(Game currentGame, User currentPlayer);

        /// <summary>
        /// Takes a turn for the current player.
        /// </summary>
        /// <param name="currentGame">The game the turn occurs in.</param>
        /// <param name="currentPlayer">The player taking the turn.</param>
        /// <returns>The next player to take a turn.</returns>
        User TakeTurn(Game currentGame, User currentPlayer);

        /// <summary>
        /// Allows the player to pass.
        /// </summary>
        /// <param name="currentGame">The game the player takes a pass in.</param>
        /// <param name="currentPlayer">The player taking the pass.</param>
        /// <returns>The next player to take a turn.</returns>
        User PlayerPass(Game currentGame, User currentPlayer);

        /// <summary>
        /// Ends a round.
        /// </summary>
        /// <param name="currentGame">The game the round ends in.</param>
        /// <returns>A trick.</returns>
        Trick EndRound(Game currentGame);

        /// <summary>
        /// Adds a trick to a player's collection of tricks.
        /// </summary>
        /// <param name="trick">The trick to add.</param>
        /// <param name="player">The player who won the trick.</param>
        void AddTrick(Trick trick, User player);

        /// <summary>
        /// Ends a hand.
        /// </summary>
        /// <param name="currentGame">The game to end the hand in.</param>
        void EndHand(Game currentGame);

        /// <summary>
        /// Calculates the next dealer.
        /// </summary>
        /// <param name="currentPlayers">The list of current players.</param>
        /// <param name="winner">The winner of the last hand.</param>
        /// <returns>A user representing the next dealer.</returns>
        User CalculateNextDealer(List<User> currentPlayers, User winner);

        /// <summary>
        /// Ends the game.
        /// </summary>
        /// <param name="currentGame">The game to add.</param>
        void EndGame(Game currentGame);

        /// <summary>
        /// Runs the game.
        /// </summary>
        void RunGame();
    }
}
