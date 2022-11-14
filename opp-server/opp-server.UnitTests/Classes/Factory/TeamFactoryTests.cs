using Microsoft.VisualStudio.TestTools.UnitTesting;
using opp_lib;
using opp_lib.Teams;
using opp_server.Classes.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace opp_server.Classes.Factory.Tests
{
    [TestClass()]
    public class TeamFactoryTests
    {
        private Creator teamFactory;

        [TestInitialize]
        public void CreateTeamFactory()
        {
            teamFactory = new TeamFactory();
        }

        [TestMethod()]
        public void GetTeam_SelectsRedTeam_RedTeam()
        {
            string selectedColor = "Red";
            Team team = teamFactory.GetTeam(selectedColor);
            Assert.IsInstanceOfType(team, typeof(RedTeam));
        }

        [TestMethod()]
        public void GetTeam_SelectsBlueTeam_BlueTeam()
        {
            string selectedColor = "Blue";
            Team team = teamFactory.GetTeam(selectedColor);
            Assert.IsInstanceOfType(team, typeof(BlueTeam));
        }

        [TestMethod()]
        public void GetTeam_SelectsGreenTeam_GreenTeam()
        {
            string selectedColor = "Green";
            Team team = teamFactory.GetTeam(selectedColor);
            Assert.IsInstanceOfType(team, typeof(GreenTeam));
        }

        [TestMethod()]
        public void GetTeam_SelectsYellowTeam_YellowTeam()
        {
            string selectedColor = "Yellow";
            Team team = teamFactory.GetTeam(selectedColor);
            Assert.IsInstanceOfType(team, typeof(YellowTeam));
        }

        [TestMethod()]
        public void GetTeam_SelectsRandomTeam_Null()
        {
            string selectedColor = "Random";
            Creator teamFactory = new TeamFactory();
            Team team = teamFactory.GetTeam(selectedColor);
            Assert.IsNull(team);
        }
    }
}