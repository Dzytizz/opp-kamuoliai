using Microsoft.VisualStudio.TestTools.UnitTesting;
using opp_lib;
using opp_server.Classes.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace opp_server.Classes.Factory.Tests
{
    [TestClass()]
    public class TeamFactoryTests
    {
        [TestMethod()]
        public void GetTeam_SelectsRedTeam_RedTeam()
        {
            string selectedColor = "Red";
            Creator teamFactory = new TeamFactory();
            Team team = teamFactory.GetTeam(selectedColor);
            Assert.IsTrue(team.Color.Equals(selectedColor));
        }

        [TestMethod()]
        public void GetTeam_SelectsBlueTeam_BlueTeam()
        {
            string selectedColor = "Blue";
            Creator teamFactory = new TeamFactory();
            Team team = teamFactory.GetTeam(selectedColor);
            Assert.IsTrue(team.Color.Equals(selectedColor));
        }

        [TestMethod()]
        public void GetTeam_SelectsGreenTeam_GreenTeam()
        {
            string selectedColor = "Green";
            Creator teamFactory = new TeamFactory();
            Team team = teamFactory.GetTeam(selectedColor);
            Assert.IsTrue(team.Color.Equals(selectedColor));
        }

        [TestMethod()]
        public void GetTeam_SelectsYellowTeam_YellowTeam()
        {
            string selectedColor = "Yellow";
            Creator teamFactory = new TeamFactory();
            Team team = teamFactory.GetTeam(selectedColor);
            Assert.IsTrue(team.Color.Equals(selectedColor));
        }

        [TestMethod()]
        public void GetTeam_SelectsRandomTeam_Null()
        {
            string selectedColor = "Random";
            Creator teamFactory = new TeamFactory();
            Team team = teamFactory.GetTeam(selectedColor);
            Assert.IsTrue(team == null);
        }
    }
}