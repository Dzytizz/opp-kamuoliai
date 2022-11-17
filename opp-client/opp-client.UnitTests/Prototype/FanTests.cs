using Microsoft.VisualStudio.TestTools.UnitTesting;
using opp_client.Prototype;
using opp_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_client.Prototype.Tests
{
    [TestClass()]
    public class FanTests
    {
        private Fan fan;

        [TestInitialize]
        public void CreateFan()
        {
            fan = new Fan(0, 0, "Red", 15);
        }

        [TestMethod()]
        public void CreateFan_CreateOvalPictureBox_OvalPictureBoxValuesAreFromFan()
        {
            OvalPictureBox pictureBox = fan.CreateFan();
            Assert.AreEqual(pictureBox.Size, new System.Drawing.Size(fan.Radius, fan.Radius));
            Assert.AreEqual(pictureBox.Location, new System.Drawing.Point(fan.XPosition, fan.XPosition));
        }

        [TestMethod()]
        public void Clone_ClonesFan_ClonedValuesAreSameButObjectIsDifferent()
        {
            Fan clonedFan = (Fan)fan.Clone();
            Assert.AreEqual(fan.Radius, clonedFan.Radius);
            Assert.AreEqual(fan.XPosition, clonedFan.XPosition);
            Assert.AreEqual(fan.YPosition, clonedFan.YPosition);
            Assert.AreNotSame(fan, clonedFan);
        }
    }
}