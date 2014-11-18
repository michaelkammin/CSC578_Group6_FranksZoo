using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;

namespace FranksZooGame.Interfaces
{
    public interface ICardComparer
    {
        /// <summary>
        /// Compares two cards.
        /// </summary>
        /// <param name="firstCard">The first card.</param>
        /// <param name="secondCard">The second card.</param>
        /// <returns>Returns true if second card outranks first card, otherwise false.</returns>
        bool DoesCardOutrank(Card firstCard, Card secondCard);
    }
}
