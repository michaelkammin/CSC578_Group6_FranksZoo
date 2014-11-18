using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;
using FranksZooGame.Interfaces;

namespace FranksZooGame.Implementations
{
    public class PerchComparer : ICardComparer
    {
        public bool DoesCardOutrank(Card firstCard, Card secondCard)
        {
            if (firstCard.CardName.ToLower() == "perch")
            {
                return secondCard.CardName.ToLower() == "whale" || secondCard.CardName.ToLower() == "crocodile" || secondCard.CardName.ToLower() == "polar bear" || secondCard.CardName.ToLower() == "seal";
            }
            else throw new Exception("Wrong comparer!");
        }
    }
}
