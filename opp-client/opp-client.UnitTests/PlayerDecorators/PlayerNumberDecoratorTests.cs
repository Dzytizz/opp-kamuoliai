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
    public class PlayerNumberDecoratorTests
    {
        [TestMethod()]
        public void Display_AddsPlayerNumberDecoration_OvalPictureBoxWithPlayerNumberLabel()
        {
            string playerNumber = "10";
            Player player = new Player("Test", 0, 0, "Test", 10);
            Decorator playerNumberDecorator = new PlayerNumberDecorator(player, playerNumber);
            OvalPictureBox opb = playerNumberDecorator.Display("Red");
            Label label = new Label();
            label.Text = playerNumber;
            Assert.IsInstanceOfType(opb.Controls[0], typeof(Label));
            Assert.AreEqual(opb.Controls[0].Text, playerNumber);
        }
    }
}