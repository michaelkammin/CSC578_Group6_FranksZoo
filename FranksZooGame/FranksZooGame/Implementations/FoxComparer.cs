using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;
using FranksZooGame.Interfaces;

namespace FranksZooGame.Implementations
{
    public class FoxComparer : ICardComparer
    {
        public bool DoesCardOutrank(Card firstCard, Card secondCard)
        {
            if (firstCard.CardName.ToLower() == "fox")
            {
                return secondCard.CardName.ToLower() == "elephant" || secondCard.CardName.ToLower() == "crocodile" || secondCard.CardName.ToLower() == "polar bear" || secondCard.CardName.ToLower() == "lion";
            }
            else throw new Exception("Wrong comparer!");
        }
    }
}
