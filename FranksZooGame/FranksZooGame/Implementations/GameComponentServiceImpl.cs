using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;
using FranksZooGame.Interfaces;

namespace FranksZooGame.Implementations
{
    public class GameComponentServiceImpl : IGameComponentService
    {
        public Deck CreateDeck()
        {
            throw new NotImplementedException();
        }

        public Deck ShuffleDeck(Deck deck)
        {
            throw new NotImplementedException();
        }

        public void StartRound(Game game)
        {
            throw new NotImplementedException();
        }

        public Play GetActivePlay(Game game)
        {
            throw new NotImplementedException();
        }

        public bool IsValidPlay(Card[] activePlay, Card[] play)
        {
            throw new NotImplementedException();
        }

        public void SetActivePlay(Card[] play, Game game)
        {
            throw new NotImplementedException();
        }

        public Card[] CheckPlayerHand(Card[] activePlay, Card[] play)
        {
            throw new NotImplementedException();
        }

        public Trick EndRound(Game game)
        {
            throw new NotImplementedException();
        }

        public User EndHand(Game game)
        {
            throw new NotImplementedException();
        }

        public void EndGame(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
