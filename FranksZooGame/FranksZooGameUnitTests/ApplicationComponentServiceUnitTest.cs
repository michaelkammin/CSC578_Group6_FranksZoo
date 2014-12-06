using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FranksZooGame.Classes;
using FranksZooGame.Implementations;
using FranksZooGame.Interfaces;

namespace FranksZooGameUnitTests
{
    [TestClass]
    public class ApplicationComponentServiceUnitTest
    {
        private IApplicationSessionService GenerateApplicationSessionService()
        {
            ApplicationSessionServiceImpl applicationSessionService = new ApplicationSessionServiceImpl();
            applicationSessionService.SetCurrentUsers(new List<User>());

            return applicationSessionService;
        }

        private IApplicationComponentService GenerateApplicationComponent()
        {
            return new ApplicationComponentServiceImpl(GenerateApplicationSessionService(), new UserComponentServiceImpl(), new GameComponentService());
        }

        private void AddTestUser(IApplicationComponentService applicationComponent, string userName)
        {
            applicationComponent.AddUser(userName, applicationComponent.GetCurrentUsers());
        }

        private void AddThreeTestUsers(IApplicationComponentService applicationComponent)
        {
            AddTestUser(applicationComponent, "User1");
            AddTestUser(applicationComponent, "User2");
            AddTestUser(applicationComponent, "User3");
        }

        private void AddFourTestUsers(IApplicationComponentService applicationComponent)
        {
            AddThreeTestUsers(applicationComponent);
            AddTestUser(applicationComponent, "User4");
        }

        private void DealCardsToPlayers(IApplicationComponentService applicationComponent)
        {
            applicationComponent.DealCards(applicationComponent.GetCurrentUsers(), applicationComponent.ShuffleDeck(applicationComponent.CreateDeck()));
        }

        private void ClearPlayerHand(IApplicationComponentService applicationComponent, string userName)
        {
            applicationComponent.GetCurrentUsers().Find(x => x.UserName == userName).UserHand.Clear();
        }

        [TestMethod]
        public void TestInvalidUserName()
        {
            IApplicationComponentService applicationComponent = GenerateApplicationComponent();

            string invalidUserName = "MyVeryLongUserName";

            bool result = applicationComponent.IsUserNameValid(invalidUserName);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestValidUserName()
        {
            IApplicationComponentService applicationComponent = GenerateApplicationComponent();

            string invalidUserName = "User1";

            bool result = applicationComponent.IsUserNameValid(invalidUserName);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestValidMaxUserCount()
        {
            IApplicationComponentService applicationComponent = GenerateApplicationComponent();

            AddThreeTestUsers(applicationComponent);

            bool result = applicationComponent.CheckMaxUserCount(applicationComponent.GetCurrentUsers());

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestInvalidMaxUserCount()
        {
            IApplicationComponentService applicationComponent = GenerateApplicationComponent();

            AddFourTestUsers(applicationComponent);

            bool result = applicationComponent.CheckMaxUserCount(applicationComponent.GetCurrentUsers());

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestAddUser()
        {
            IApplicationComponentService applicationComponent = GenerateApplicationComponent();

            string userName = "User1";

            applicationComponent.AddUser(userName, applicationComponent.GetCurrentUsers());

            bool result = applicationComponent.GetCurrentUsers().Count == 1 && applicationComponent.GetCurrentUsers()[0].UserName == userName;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestRandomDealer()
        {
            IApplicationComponentService applicationComponent = GenerateApplicationComponent();

            AddFourTestUsers(applicationComponent);

            User firstRandomDealer = applicationComponent.SelectRandomDealer(applicationComponent.GetCurrentUsers());
            User secondRandomDealer = applicationComponent.SelectRandomDealer(applicationComponent.GetCurrentUsers());

            bool result = firstRandomDealer.UserName != secondRandomDealer.UserName;

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestDealCards()
        {
            IApplicationComponentService applicationComponent = GenerateApplicationComponent();

            AddFourTestUsers(applicationComponent);

            DealCardsToPlayers(applicationComponent);

            bool allPlayersHaveCards = true;

            foreach(User user in applicationComponent.GetCurrentUsers())
            {
                if (user.UserHand == null || user.UserHand.Count == 0)
                {
                    allPlayersHaveCards = false;
                    break;
                }
            }

            Assert.IsTrue(allPlayersHaveCards);
        }

        [TestMethod]
        public void TestDetermineNextPlayerAllWithCards()
        {
            IApplicationComponentService applicationComponent = GenerateApplicationComponent();

            AddFourTestUsers(applicationComponent);

            DealCardsToPlayers(applicationComponent);

            User nextPlayer = applicationComponent.DetermineNextPlayer(applicationComponent.GetCurrentUsers(), applicationComponent.GetCurrentUsers().Find(x => x.UserName == "User1"));

            Assert.IsTrue(nextPlayer.UserName == "User2");
        }

        [TestMethod]
        public void TestDetermineNextPlayerUser4Current()
        {
            IApplicationComponentService applicationComponent = GenerateApplicationComponent();

            AddFourTestUsers(applicationComponent);

            DealCardsToPlayers(applicationComponent);

            User nextPlayer = applicationComponent.DetermineNextPlayer(applicationComponent.GetCurrentUsers(), applicationComponent.GetCurrentUsers().Find(x => x.UserName == "User4"));

            Assert.IsTrue(nextPlayer.UserName == "User1");
        }

        [TestMethod]
        public void TestDetermineNextPlayerOnePlayerWithCards()
        {
            IApplicationComponentService applicationComponent = GenerateApplicationComponent();

            AddFourTestUsers(applicationComponent);

            DealCardsToPlayers(applicationComponent);

            ClearPlayerHand(applicationComponent, "User2");
            ClearPlayerHand(applicationComponent, "User3");
            ClearPlayerHand(applicationComponent, "User4");

            User nextPlayer = applicationComponent.DetermineNextPlayer(applicationComponent.GetCurrentUsers(), applicationComponent.GetCurrentUsers().Find(x => x.UserName == "User4"));

            Assert.IsTrue(nextPlayer == null);
        }
    }
}
