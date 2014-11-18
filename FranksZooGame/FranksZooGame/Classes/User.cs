using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FranksZooGame.Classes
{
    public class User
    {
        public string UserName { get; set; }

        public List<Card> UserHand { get; set; }

        public int CurrentScore { get; set; } // Score as of now

        public int PreviousScore { get; set; } //Score at end of last hand

        public int HandPosition { get; set; } //Order in which players run out of cards in hands

        public List<Trick> Tricks { get; set; } //Tricks will hold all the cards from all the tricks this user got in the current hand 

        public List<Card> playSet { get; set; }

        public User()
        {
            UserName = "";
            UserHand = new List<Card>();
        }

        public User(string name)
        {
            UserName = name;
            UserHand = new List<Card>();
        }

        public User(string name, List<Card> cards)
        {
            UserName = name;
            UserHand = cards;
        }

        public override string ToString()
        {
            StringBuilder userString = new StringBuilder(UserName);

            userString.Append("\n\n");
            userString.Append("Hand: ");

            for (int i = 0; i < this.UserHand.Count; i++)
            {
                userString.Append(this.UserHand[i].CardName);
                userString.Append("\n");
            }

            userString.Append("\n\n");

            return userString.ToString();
        }

        //public override bool Equals(object obj)
        //{
        //    if (obj is User)
        //    {
        //        User otherUser = (User)obj;

        //        return otherUser.UserName == this.UserName;
        //    }

        //    return false;
        //}

        //public void AddCurrentScore(int points)
        //{
        //    this.CurrentScore=this.CurrentScore+points;
        //}

        //public void AddCard(List<Card> toAdd)
        //{
        //    Card current= toAdd.First();
        //    foreach(Card c in toAdd)
        //    {
        //        UserHand.Add(c);
        //    }
        //}

        //public int GetNumCards()
        //{
        //    return UserHand.Count();
        //}

        //public void AddTricks(Trick t)
        //{
        //    foreach (Card c in t.getTrickList())
        //    {
        //        Tricks.getTrickList().Add(c);
        //    }
        //}

        //public void ResetTricks()
        //{
        //    Tricks.getTrickList().Clear();
        //}

        //public void ChoosePlayCard(Card c)
        //{
        //    playSet.Add(c);
        //}

        //public void RemovePlayCard(Card c)
        //{
        //    playSet.Remove(c);
        //}
    }
}
