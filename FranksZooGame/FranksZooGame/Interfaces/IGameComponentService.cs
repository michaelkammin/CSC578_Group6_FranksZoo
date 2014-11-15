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
        List<User> StartHand(Deck deck, List<User> users, Game game);
        List<User> StartRound(List<User> Users, Game game);
        Play GetActivePlay(Game game);
        bool IsValidPlay(List<Card> activePlay, List<Card> play);
        //bool IsValidPlay(Card[] activePlay, Card[] play);
        void SetActivePlay(Card[] play, User user, Game game);
        Card[] CheckPlayerHand(Card[] activePlay, Card[] play);
        Trick EndRound(Game game);
        User EndHand(Game game);
        void EndGame(Game game);
    }
}
