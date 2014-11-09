using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;

namespace FranksZooGame.Interfaces
{
    public interface IGameComponentService
    {
        Deck CreateDeck();
        Deck ShuffleDeck(Deck deck);
        Card Draw(Deck deck);
        void StartRound(Game game);
        Play GetActivePlay(Game game);
        bool IsValidPlay(Card[] activePlay, Card[] play);
        void SetActivePlay(Card[] play, User user, Game game);
        Card[] CheckPlayerHand(Card[] activePlay, Card[] play);
        Trick EndRound(Game game);
        User EndHand(Game game);
        void EndGame(Game game);
    }
}
