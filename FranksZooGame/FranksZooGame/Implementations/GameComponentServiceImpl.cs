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
            Deck temp = new Deck();
            return temp;
        }

        public Deck ShuffleDeck(Deck deck)
        {
            List<Card> list = new List<Card>(deck.Cards);
            deck.Cards = new Queue<Card>();

            var random = new Random();
            while (list.Count > 0)
            {
                Int32 index = random.Next(list.Count);
                Card card = list[index];
                list.RemoveAt(index);
                deck.Cards.Enqueue(card);
            }
            return deck;
        }

        public Card Draw(Deck deck)
        {
            if (deck.Cards.Count == 0)
            {
                return null;
            }
            else
            {
                Card card = deck.Cards.Dequeue();

                return card;
            }
        }

        public void StartRound(Game game)
        {
            throw new NotImplementedException();
        }

        public Play GetActivePlay(Game game)
        {
            return game._activePlay;
        }

        public bool IsValidPlay(Card[] activePlay, Card[] play)
        {
            throw new NotImplementedException();
        }

        public void SetActivePlay(Card[] play, User user, Game game)
        {
            Play currentPlay = new Play(play.ToList(), user);
            game._activePlay = currentPlay;
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
