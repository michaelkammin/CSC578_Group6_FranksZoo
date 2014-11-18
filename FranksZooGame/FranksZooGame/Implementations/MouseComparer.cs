using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;
using FranksZooGame.Interfaces;

namespace FranksZooGame.Implementations
{
    public class MouseComparer : ICardComparer
    {
        public bool DoesCardOutrank(Card firstCard, Card secondCard)
        {
            if (firstCard.CardName.ToLower() == "mouse")
            {
                return secondCard.CardName.ToLower() == "crocodile" || secondCard.CardName.ToLower() == "polar bear" || secondCard.CardName.ToLower() == "lion" || secondCard.CardName.ToLower() == "seal" || secondCard.CardName.ToLower() == "fox" || secondCard.CardName.ToLower() == "hedgehog";
            }
            else throw new Exception("Wrong comparer!");
        }
    }
}
