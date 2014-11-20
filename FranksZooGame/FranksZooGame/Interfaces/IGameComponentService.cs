using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;

namespace FranksZooGame.Interfaces
{
    public interface IGameComponentService
    {
        /// <summary>
        /// Creates a deck.
        /// </summary>
        /// <returns>The deck created.</returns>
        Deck CreateDeck();

        /// <summary>
        /// Shuffles a deck.
        /// </summary>
        /// <param name="deck">The deck to shuffle.</param>
        /// <returns>The shuffled deck.</returns>
        Deck ShuffleDeck(Deck deck);

        /// <summary>
        /// Deals a card.
        /// </summary>
        /// <param name="deck">The deck to deal the card from.</param>
        /// <returns>The card dealt.</returns>
        Card DealHand(Deck deck);

        /// <summary>
        /// Starts a hand.
        /// </summary>
        /// <param name="deck">The deck to start a hand with.</param>
        /// <param name="users">The users to start a hand for.</param>
        /// <param name="game">The current game.</param>
        /// <returns>A list of users.</returns>
        List<User> StartHand(Deck deck, List<User> users, Game game);

        /// <summary>
        /// Starts a round.
        /// </summary>
        /// <param name="Users">The list of current users.</param>
        /// <param name="game">The current game.</param>
        /// <returns>The list of current users.</returns>
        List<User> StartRound(List<User> Users, Game game);

        /// <summary>
        /// Gets the active play for the game.
        /// </summary>
        /// <param name="game">The current game.</param>
        /// <returns>The active play for the game.</returns>
        Play GetActivePlay(Game game);

        /// <summary>
        /// Determines if a play is a valid play.
        /// </summary>
        /// <param name="activePlay">The current active play.</param>
        /// <param name="play">The play the user is attempting to play.</param>
        /// <returns>True if the user's play is valid, otherwise false.</returns>
        bool IsValidPlay(List<Card> activePlay, List<Card> play);

        /// <summary>
        /// Sets the active play.
        /// </summary>
        /// <param name="play">The list of cards in the play.</param>
        /// <param name="user">The user making the play.</param>
        /// <param name="game">The current game.</param>
        void SetActivePlay(List<Card> play, User user, Game game);

        /// <summary>
        /// Determines the best set of cards to play from the player's hand.
        /// </summary>
        /// <param name="activePlay">The active play in the game.</param>
        /// <param name="playerHand">The player's hand to evaluate.</param>
        /// <returns>The best set of cards from the players hand to play.</returns>
        List<Card> CheckPlayerHand(List<Card> activePlay, List<Card> playerHand);

        /// <summary>
        /// Ends a round.
        /// </summary>
        /// <param name="game">The game to end the round in.</param>
        /// <returns>A trick representing the active play.</returns>
        Trick EndRound(Game game);

        /// <summary>
        /// Ends a hand.
        /// </summary>
        /// <param name="game">The game to end the hand in.</param>
        /// <returns>A user.</returns>
        User EndHand(Game game);

        /// <summary>
        /// Ends a game.
        /// </summary>
        /// <param name="game">The game to end.</param>
        void EndGame(Game game);
    }
}
