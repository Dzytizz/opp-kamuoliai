using Microsoft.VisualStudio.TestTools.UnitTesting;
using opp_lib;
using opp_server.Classes.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace opp_server.Classes.Builder.Tests
{
    [TestClass()]
    public class DirectorTests
    {
        private Director director;
        private Ball initialBall;
        private BallBuilder ballBuilder;

        [TestInitialize]
        public void CreateDirector()
        {
            director = new Director();
            initialBall = new Ball(15, 0, 0, "Red");
            ballBuilder = new BallBuilder(initialBall);
        }

        [TestMethod()]
        public void ConstructSimple_ReturnsInitialBall_InitialBallIsEqualToReturnedBall()
        {
            Ball newBall = director.ConstructSimple(ballBuilder);
            Assert.AreSame(initialBall, newBall);
        }

        [TestMethod()]
        public void ConstructStripy_AddsLinesBallVisual_LinesBallVisualAdded()
        {
            Ball newBall = director.ConstructStripy(ballBuilder);
            BallVisual bv = new BallVisual(initialBall.Radius, "stripes");
            Assert.AreEqual(newBall.VisualParts[0], bv);
        }

        [TestMethod()]
        public void ConstructDottyEdged_AddsDotsBallVisualAndIncreasesRadius_DotsBallVisualAddedAndRadiusIncreased()
        {
            Ball newBall = director.ConstructDottyEdged(ballBuilder);
            BallVisual bv = new BallVisual(initialBall.Radius, "dots");
            Assert.AreEqual(newBall.VisualParts[0], bv);
            Assert.IsTrue(newBall.HasEdge);
        }

        [TestMethod()]
        public void ConstructFancy_AddsAllBallVisualsAndAddsEdge_AllVisualsAddedAndEdgeAdded()
        {
            Ball newBall = director.ConstructFancy(ballBuilder);
            BallVisual bvCircles = new BallVisual(initialBall.Radius, "circles");
            BallVisual bvLines = new BallVisual(initialBall.Radius, "stripes");
            BallVisual bvDots = new BallVisual(initialBall.Radius, "dots");
            Assert.AreEqual(newBall.VisualParts[0], bvCircles);
            Assert.AreEqual(newBall.VisualParts[1], bvLines);
            Assert.AreEqual(newBall.VisualParts[2], bvDots);
            Assert.IsTrue(newBall.HasEdge);
        }

        [TestMethod()]
        public void ConstructInflated_IncreasesRadiusBy20_RadiusIncreasedBy1()
        {
            int initialRadius = initialBall.Radius;
            Ball newBall = director.ConstructInflated(ballBuilder);
            int addedAir = 5 * 4;
            Assert.AreEqual(initialRadius + addedAir, newBall.Radius);
        }
    }
}