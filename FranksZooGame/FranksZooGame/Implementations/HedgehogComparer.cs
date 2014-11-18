using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;
using FranksZooGame.Interfaces;

namespace FranksZooGame.Implementations
{
    public class HedgehogComparer : ICardComparer
    {
        public bool DoesCardOutrank(Card firstCard, Card secondCard)
        {
            if (firstCard.CardName.ToLower() == "hedgehog")
            {
                return secondCard.CardName.ToLower() == "fox";
            }
            else throw new Exception("Wrong comparer!");
        }
    }
}
