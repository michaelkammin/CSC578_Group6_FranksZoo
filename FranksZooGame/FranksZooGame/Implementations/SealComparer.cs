using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;
using FranksZooGame.Interfaces;

namespace FranksZooGame.Implementations
{
    public class SealComparer : ICardComparer
    {
        public bool DoesCardOutrank(Card firstCard, Card secondCard)
        {
            if (firstCard.CardName.ToLower() == "seal")
            {
                return secondCard.CardName.ToLower() == "whale" || secondCard.CardName.ToLower() == "polar bear";
            }
            else throw new Exception("Wrong comparer!");
        }
    }
}
