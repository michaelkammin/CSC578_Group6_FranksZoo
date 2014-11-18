using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;
using FranksZooGame.Interfaces;

namespace FranksZooGame.Implementations
{
    public class WhaleComparer : ICardComparer
    {
        public bool DoesCardOutrank(Card firstCard, Card secondCard)
        {
            if (firstCard.CardName == "Whale")
            {
                return false;
            }
            else throw new Exception("Wrong comparer!");
        }
    }
}
