using Microsoft.VisualStudio.TestTools.UnitTesting;
using opp_lib;
using opp_server.Classes.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace opp_server.Classes.Builder.Tests
{
    [TestClass()]
    public class BallBuilderTests
    {
        private Builder builder;
        private Ball initialBall;

        [TestInitialize]
        public void CreateBuilderAndBall()
        {
            initialBall = new Ball(15, 0, 0, "Red");
            builder = new BallBuilder(initialBall);
        }

        [TestMethod()]
        public void AddCircles_AddsCircleBallVisual_CircleBallVisualAdded()
        {
            Ball newBall = builder.AddCircles().Build();
            BallVisual bv = new BallVisual(initialBall.Radius, "circles");
            Assert.AreEqual(newBall.VisualParts[0], bv);
        }

        [TestMethod()]
        public void AddEdge_SetsHasEdgeToTrue_HasEdgeIsTrue()
        {
            Ball newBall = builder.AddEdge().Build();
            Assert.IsTrue(newBall.HasEdge);
        }

        [TestMethod()]
        public void AddDots_AddsDotsBallVisual_DotsBallVisualAdded()
        {
            Ball newBall = builder.AddDots().Build();
            BallVisual bv = new BallVisual(initialBall.Radius, "dots");
            Assert.AreEqual(newBall.VisualParts[0], bv);
        }

        [TestMethod()]
        public void AddLines_AddsLinesBallVisual_LinesBallVisualAdded()
        {
            Ball newBall = builder.AddLines().Build();
            BallVisual bv = new BallVisual(initialBall.Radius, "stripes");
            Assert.AreEqual(newBall.VisualParts[0], bv);
        }

        [TestMethod()]
        public void AddAir_IncreasesRadiusBy5_BallRadiusIncreasedBy5()
        {
            int initialRadius = initialBall.Radius;
            Ball newBall = builder.AddAir().Build();
            int addedAir = 5;
            Assert.AreEqual(initialRadius + addedAir, newBall.Radius);
        }
    }
}