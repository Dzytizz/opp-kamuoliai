using Microsoft.VisualStudio.TestTools.UnitTesting;
using opp_client.PlayerDecorators;
using opp_lib;
using opp_lib.Decorator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_client.PlayerDecorators.Tests
{
    [TestClass()]
    public class PlayerUniformDecoratorTests
    {
        [TestMethod()]
        public void Display_AddsPlayerUniformDecoration_OvalPictureBoxWithImageBackground()
        {
            string playerUniform = "stripes";
            Player player = new Player("Test", 0, 0, playerUniform, 0);
            Decorator playerUniformDecorator = new PlayerUniformDecorator(player, playerUniform);
            OvalPictureBox opb = playerUniformDecorator.Display("Red");
            Assert.AreEqual(opb.Image.Tag, playerUniform);
        }
    }
}