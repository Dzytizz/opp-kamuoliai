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
    public class BallTests
    {

        [DataRow(15, 0, 0, "Red")]
        [DataRow(20, 15, 17, "Yellow")]
        [DataRow(10, 3, 4, "Green")]
        [DataRow(15, 7, 8, "Blue")]
        [DataTestMethod]
        public void Ball_(int radius, int xPosition, int yPosition, string mainColor)
        {
            Ball createdBall = new Ball(radius, xPosition, yPosition, mainColor);
            Assert.AreEqual(createdBall.Radius, radius);
            Assert.AreEqual(createdBall.XPosition, xPosition);
            Assert.AreEqual(createdBall.YPosition, yPosition);  
            Assert.AreEqual(createdBall.MainColor, mainColor);
        }
    }
}