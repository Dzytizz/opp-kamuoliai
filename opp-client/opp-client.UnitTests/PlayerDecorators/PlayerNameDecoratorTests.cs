using Microsoft.VisualStudio.TestTools.UnitTesting;
using opp_client.PlayerDecorators;
using opp_lib;
using opp_lib.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opp_client.PlayerDecorators.Tests
{
    [TestClass()]
    public class PlayerNameDecoratorTests
    {
        [TestMethod()]
        public void Display_AddsPlayerNameDecoration_OvalPictureBoxWithPlayerNameLabel()
        {
            string playerName = "Test";
            Player player = new Player(playerName, 0, 0, "Test", 0);
            Decorator playerNameDecorator = new PlayerNameDecorator(player, playerName);
            OvalPictureBox opb = playerNameDecorator.Display("Red");
            Label label = new Label();
            label.Text = playerName;
            Assert.IsInstanceOfType(opb.Controls[0], typeof(Label));
            Assert.AreEqual(opb.Controls[0].Text, playerName);
        }
    }
}