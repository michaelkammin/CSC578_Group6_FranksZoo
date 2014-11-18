using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;
using FranksZooGame.Interfaces;

namespace FranksZooGame.Implementations
{
    public class GameComponentService : IGameComponentService
    {
        public Deck CreateDeck()
        {
            return new Deck();
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

        public Card DealHand(Deck deck)
        {
            if (deck.Cards.Count == 0) return null;

            return deck.Cards.Dequeue();
        }

        public List<User> StartHand(Deck deck, List<User> users, Game game)
        {
            throw new NotImplementedException();
        }

        public List<User> StartRound(List<User> Users, Game game)
        {
            game.ActivePlay = null;

            return Users;
        }

        public Play GetActivePlay(Game game)
        {
            return game.ActivePlay;
        }

        public bool IsValidPlay(List<Card> activePlay, List<Card> play)
        {
            // if the activePlay is null, then this is the first play, so any play is valid
            if (activePlay == null) return true;

            // there are fewer cards in the attempted play
            if (play.Count < activePlay.Count) return false;

            Card rankingActiveCard = FindRankingCard(activePlay);
            Card rankingPlayedCard = FindRankingCard(play);

            // the same ranking card is played, so the play is valid if the user is playing more cards.
            if (rankingActiveCard.CardName == rankingPlayedCard.CardName) return play.Count > activePlay.Count;

            // the cards are different, so compare the cards
            CardComparer cardComparer = new CardComparer();

            return cardComparer.DoesCardOutrank(rankingActiveCard, rankingPlayedCard);
        }

        private Card FindRankingCard(List<Card> cards)
        {
            if (AllJokers(cards)) return cards.First();
            if (AllMosquitos(cards)) return cards.First(x => x.CardName == "Mosquito");

            return cards.First(x => x.CardName != "Mosquito" && x.CardName != "Joker");
        }

        private bool AllMosquitos(List<Card> cards)
        {
            foreach (Card card in cards)
            {
                if (card.CardName != "Joker")
                {
                    if (card.CardName != "Mosquito")
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool AllJokers(List<Card> cards)
        {
            foreach (Card card in cards)
            {
                if (card.CardName != "Joker") return false;
            }

            return true;
        }

        public void SetActivePlay(List<Card> play, User user, Game game)
        {
            Play currentPlay = new Play(play.ToList(), user);
            game.ActivePlay = currentPlay;
        }

        public List<Card> CheckPlayerHand(List<Card> activePlay, List<Card> playerHand)
        {
            var cardGroupings = playerHand.GroupBy(x => x.CardName);

            // the active play is null, so this is the first play of the round
            // find the play from the player's hands which allows them to get rid of the most cards.
            if (activePlay == null)
            {
                int largestGroupingCount = 0;
                string largestGrouping = "";

                foreach (var grouping in cardGroupings)
                {
                    if (grouping.Key != "Joker")
                    {
                        if (grouping.Count() > largestGroupingCount)
                        {
                            largestGroupingCount = grouping.Count();
                            largestGrouping = grouping.Key;
                        }
                    }
                }

                return playerHand.FindAll(x => x.CardName == largestGrouping).ToList();
            }

            int jokerCount = cardGroupings.Where(x => x.Key == "Joker").Count();
            int mosquitoCount = cardGroupings.Where(x => x.Key == "Mosquito").Count();

            foreach (var grouping in cardGroupings)
            {
                List<Card> cardGrouping = playerHand.FindAll(x => x.CardName == grouping.Key).ToList();

                if (cardGrouping.Count >= activePlay.Count)
                {
                    if (IsValidPlay(activePlay, cardGrouping))
                    {
                        return cardGrouping;
                    }
                }

                // this is an elephant grouping, so try adding one mosquito
                if (grouping.Key == "Elephant" && mosquitoCount > 0)
                {
                    cardGrouping.Add(new Card("Mosquito"));

                    if (cardGrouping.Count >= activePlay.Count)
                    {
                        if (IsValidPlay(activePlay, cardGrouping)) return cardGrouping;
                    }
                }

                // none of the groupings are valid, so try adding Jokers one by one
                if (jokerCount > 0)
                {
                    for (int i = 0;i < jokerCount;i++)
                    {
                        cardGrouping.Add(new Card("Joker"));

                        if (cardGrouping.Count >= activePlay.Count)
                        {
                            if (IsValidPlay(activePlay, cardGrouping))
                            {
                                return cardGrouping;
                            }
                        }
                    }
                }
            }

            // could not find an cards to play
            return null;
        }

        public Trick EndRound(Game game)
        {
            Trick trick = new Trick();

            foreach (Card card in game.ActivePlay.Cards) trick.TrickList.Add(new Card(card.CardName));

            game.ActivePlay = null;

            return trick;
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
