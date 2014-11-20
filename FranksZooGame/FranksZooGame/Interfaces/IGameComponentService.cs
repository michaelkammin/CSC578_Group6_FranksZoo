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

        Card DealHand(Deck deck);
        List<User> StartHand(Deck deck, List<User> users, Game game);
        List<User> StartRound(List<User> Users, Game game);
        Play GetActivePlay(Game game);
        bool IsValidPlay(List<Card> activePlay, List<Card> play);

        void SetActivePlay(List<Card> play, User user, Game game);

        /// <summary>
        /// Determines the best set of cards to play from the player's hand.
        /// </summary>
        /// <param name="activePlay">The active play in the game.</param>
        /// <param name="playerHand">The player's hand to evaluate.</param>
        /// <returns>The best set of cards from the players hand to play.</returns>
        List<Card> CheckPlayerHand(List<Card> activePlay, List<Card> playerHand);

        Trick EndRound(Game game);
        User EndHand(Game game);
        void EndGame(Game game);
    }
}
