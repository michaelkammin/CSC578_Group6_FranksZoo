using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;

namespace FranksZooGame.Interfaces
{
    interface IApplicationComponentService
    {
        User[] AddUser(string userName, User[] currentUsers);
        User[] RemoveUser(string userName, User[] currentUsers);
        User[] GetCurrentUsers();
        Game StartGame();
        Deck CreateDeck();
        Deck ShuffleDeck(Deck deck);
        User SelectRandomDealer(User[] currentUsers);
        void DealCards(User[] players, Deck deck);
        User DetermineNextPlayer(User[] currentPlayers, User currentPlayer);
        void StartHand(Game currentGame, User currentPlayer);
        void StartRound(Game currentGame, User currentPlayer);
        User TakeTurn(Game currentGame, User currentPlayer);
        User PlayerPass(Game currentGame, User currentPlayer);
        Trick EndRound(Game currentGame);
        void AddTrick(Trick trick, User player);
        void EndHand(Game currentGame, User player);
        User CalculateNextDealer(User[] currentPlayers, User winner);
        void EndGame(Game currentGame);
        void RunGame();
    }
}
