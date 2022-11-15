using Microsoft.VisualStudio.TestTools.UnitTesting;
using opp_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Tests
{
    [TestClass()]
    public class GameStateTests
    {
        [TestMethod()]
        public void GetInstance_CheckIfSameInstanceIsReturned_InstancesAreSame()
        {
            GameState instance1 = GameState.GetInstance();
            GameState instance2 = GameState.GetInstance();
            Assert.AreSame(instance1, instance2);
        }

        [TestMethod()]
        public void GetInstance_ChangedValuesPassToOtherInstances_ReturnedInstanceHasNewValues()
        {
            GameState instance1 = GameState.GetInstance();
            instance1.AdminExists = true;
            GameState instance2 = GameState.GetInstance();
            Assert.AreEqual(instance2.AdminExists, true);
        }

        [TestMethod()]
        public void Copy_SetsValuesAndCopiesInstance_DeepCopyWithValuesIsReturned()
        {
            GameState instance = GameState.GetInstance();
            List<Team> teams = new List<Team>() { new Team("Red"), new Team("Blue") };
            Player player1 = new Player("name1", 0, 0, "stripes", 13);
            Player player2 = new Player("name2", 0, 0, "stripes", 15);
            teams[0].Players.Add("id1", player1);
            teams[1].Players.Add("id2", player2);
            bool adminExists = true;
            int currentLevel = 1;
            instance.Teams = teams;
            instance.AdminExists = adminExists;
            instance.CurrentLevel = currentLevel;

            GameState copiedInstance = instance.Copy();

            Assert.AreNotSame(copiedInstance, instance);
            Assert.AreEqual(instance.Teams, teams);
            Assert.AreEqual(instance.AdminExists, adminExists);
            Assert.AreEqual(instance.CurrentLevel, currentLevel);
        }

        [TestMethod()]
        public void TryFindPlayer_SetsValuesAndFindsSecondPlayer_SecondPlayerReturned()
        {
            GameState instance = GameState.GetInstance();
            List<Team> teams = new List<Team>() { new Team("Red"), new Team("Blue") };
            Player player1 = new Player("name1", 0, 0, "stripes", 15);
            Player player2 = new Player("name2", 0, 0, "dots", 17);
            teams[0].Players.Add("id1", player1);
            teams[1].Players.Add("id2", player2);
            instance.Teams = teams;

            Player foundPlayer = instance.TryFindPlayer("id2");

            Assert.AreEqual(foundPlayer, player2);
        }

        [TestMethod()]
        public void TryFindPlayer_SetsValuesAndTriesToFindNonExisting_NullReturned()
        {
            GameState instance = GameState.GetInstance();
            List<Team> teams = new List<Team>() { new Team("Red"), new Team("Blue") };
            Player player1 = new Player("name1", 0, 0, "stripes", 15);
            Player player2 = new Player("name2", 0, 0, "dots", 17);
            teams[0].Players.Add("id1", player1);
            teams[1].Players.Add("id2", player2);
            instance.Teams = teams;

            Player foundPlayer = instance.TryFindPlayer("id3");

            Assert.IsNull(foundPlayer);
        }

        [TestMethod()]
        public void TryFindPlayerTeamIndex_SetsValuesAndFindsIndexOfPlayerTeam_PlayerTeamIndexReturned()
        {
            GameState instance = GameState.GetInstance();
            List<Team> teams = new List<Team>() { new Team("Red"), new Team("Blue") };
            Player player1 = new Player("name1", 0, 0, "stripes", 15);
            Player player2 = new Player("name2", 0, 0, "dots", 17);
            teams[0].Players.Add("id1", player1);
            teams[1].Players.Add("id2", player2);
            instance.Teams = teams;

            int teamIndex = instance.TryFindPlayerTeamIndex("id2");

            Assert.AreEqual(teamIndex, 1);
        }

        [TestMethod()]
        public void TryFindPlayerTeamIndex_SetsValuesAndTriesToFindNonExistingPlayer_PlayerIndexIsNegative1()
        {
            GameState instance = GameState.GetInstance();
            List<Team> teams = new List<Team>() { new Team("Red"), new Team("Blue") };
            Player player1 = new Player("name1", 0, 0, "stripes", 15);
            Player player2 = new Player("name2", 0, 0, "dots", 17);
            teams[0].Players.Add("id1", player1);
            teams[1].Players.Add("id2", player2);
            instance.Teams = teams;

            int teamIndex = instance.TryFindPlayerTeamIndex("id3");

            Assert.AreEqual(teamIndex, -1);
        }

        [TestMethod()]
        public void UpdatePlayer_SetsValuesAndChecksIfPositionUpdatedCorrectly_PlayerYPositionIncreasedBySpeed()
        {
            GameState instance = GameState.GetInstance();
            List<Team> team = new List<Team>() { new Team("Red")};
            Player player = new Player("name1", 0, 0, "stripes", 15);
            instance.Teams = team;
            instance.Teams[0].Players.Add("id1", player);

            PlayerInput playerInput = new PlayerInput();
            playerInput.Down = true;

            instance.UpdatePlayer("id1", playerInput);
            Player updatedPlayer = instance.TryFindPlayer("id1");

            Assert.AreEqual(updatedPlayer.YPosition, player.Speed);
        }

        [TestMethod()]
        public void ToString_SetsValuesAndGetsToString_ToStringIsEqualToExpectedOutput()
        {
            GameState instance = GameState.GetInstance();
            List<Team> team = new List<Team>() { new Team("Red") };
            Player player = new Player("name1", 0, 0, "stripes", 15);
            instance.Teams = team;
            instance.Teams[0].Players.Add("id1", player);

            string output = "name1, x:0, y:0|";
            Assert.AreEqual(instance.ToString(), output);
        }
    }
}