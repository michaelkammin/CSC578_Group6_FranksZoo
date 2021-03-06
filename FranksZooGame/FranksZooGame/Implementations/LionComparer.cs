﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;
using FranksZooGame.Interfaces;

namespace FranksZooGame.Implementations
{
    public class LionComparer : ICardComparer
    {
        public bool DoesCardOutrank(Card firstCard, Card secondCard)
        {
            if (firstCard.CardName.ToLower() == "lion")
            {
                return secondCard.CardName.ToLower() == "elephant";
            }
            else throw new Exception("Wrong comparer!");
        }
    }
}
