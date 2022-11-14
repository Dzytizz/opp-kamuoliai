using Microsoft.VisualStudio.TestTools.UnitTesting;
using opp_lib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Tests
{
    [TestClass()]
    public class PlayerTests
    {
        [TestMethod()]
        public void Move()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void SetPositions()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void UpdatePosition()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void Display_GeneratesBasePlayerObject_OvalPictureBoxWithTeamColorBackground()
        {
            string teamColor = "Red";
            Player player = new Player("Test", 0, 0, "Test", 0);
            OvalPictureBox opb = player.Display(teamColor);
            Assert.AreEqual(opb.BackColor, Color.FromName(teamColor));
        }
    }
}