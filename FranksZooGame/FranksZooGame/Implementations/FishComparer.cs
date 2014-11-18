using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;
using FranksZooGame.Interfaces;

namespace FranksZooGame.Implementations
{
    public class FishComparer : ICardComparer
    {
        public bool DoesCardOutrank(Card firstCard, Card secondCard)
        {
            if (firstCard.CardName.ToLower() == "fish")
            {
                return secondCard.CardName.ToLower() == "whale" || secondCard.CardName.ToLower() == "crocodile" || secondCard.CardName.ToLower() == "seal" || secondCard.CardName.ToLower() == "perch";
            }
            else throw new Exception("Wrong comparer!");
        }
    }
}
