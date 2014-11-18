using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;

namespace FranksZooGame.Interfaces
{
    public interface IApplicationSessionService
    {
        /// <summary>
        /// Set the current users for the game.
        /// </summary>
        /// <param name="currentUsers">The list of current users for the game.</param>
        void SetCurrentUsers(List<User> currentUsers);

        /// <summary>
        /// Gets the current users for the game.
        /// </summary>
        /// <returns>The list of current users for the game.</returns>
        List<User> GetCurrentUsers();

        /// <summary>
        /// Sets the current game in progress.
        /// </summary>
        /// <param name="game">The current game.</param>
        void SetCurrentGame(Game game);

        /// <summary>
        /// Gets the current game in progress.
        /// </summary>
        /// <returns>The current game.</returns>
        Game GetCurrentGame();

        /// <summary>
        /// Sets the initial dealer for the game.
        /// </summary>
        /// <param name="dealer">The initial dealer for the game.</param>
        void SetDealer(User dealer);

        /// <summary>
        /// Gets the current dealer for the game.
        /// </summary>
        /// <returns>The current dealer for the game.</returns>
        User GetDealer();
    }
}
