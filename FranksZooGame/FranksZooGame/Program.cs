using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FranksZooGame.Classes;
using FranksZooGame.Implementations;
using FranksZooGame.Interfaces;

namespace FranksZooGame
{
    class Program
    {
        static void Main(string[] args)
        {
            IApplicationComponentService applicationComponent = new ApplicationComponentServiceImpl(new ApplicationSessionServiceImpl(), new UserComponentServiceImpl(), new GameComponentServiceImpl());

            applicationComponent.StartGame();

            User[] currentUsers = applicationComponent.GetCurrentUsers();

            foreach (User user in currentUsers)
            {
                Console.WriteLine(user.ToString());
            }
        }
    }
}
