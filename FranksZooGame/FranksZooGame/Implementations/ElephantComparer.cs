using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;
using FranksZooGame.Interfaces;

namespace FranksZooGame.Implementations
{
    public class ElephantComparer : ICardComparer
    {
        public bool DoesCardOutrank(Card firstCard, Card secondCard)
        {
            if (firstCard.CardName.ToLower() == "elephant")
            {
                return secondCard.CardName.ToLower() == "mouse";
            }
            else throw new Exception("Wrong comparer!");
        }
    }
}
