using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;
using FranksZooGame.Interfaces;

namespace FranksZooGame.Implementations
{
    public class CardComparer : ICardComparer
    {
        private Dictionary<string, ICardComparer> _cardComparers;

        public CardComparer()
        {
            _cardComparers = new Dictionary<string, ICardComparer>();

            _cardComparers.Add("whale", new WhaleComparer());
            _cardComparers.Add("elephant", new ElephantComparer());
            _cardComparers.Add("crocodile", new CrocodileComparer());
            _cardComparers.Add("polar bear", new PolarBearComparer());
            _cardComparers.Add("lion", new LionComparer());
            _cardComparers.Add("seal", new SealComparer());
            _cardComparers.Add("fox", new FoxComparer());
            _cardComparers.Add("perch", new PerchComparer());
            _cardComparers.Add("hedgehog", new HedgehogComparer());
            _cardComparers.Add("fish", new FishComparer());
            _cardComparers.Add("mouse", new MouseComparer());
            _cardComparers.Add("mosquito", new MosquitoComparer());
        }

        public bool DoesCardOutrank(Card firstCard, Card secondCard)
        {
            return _cardComparers[firstCard.CardName.ToLower()].DoesCardOutrank(firstCard, secondCard);
        }
    }
}
