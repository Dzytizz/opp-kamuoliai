using Microsoft.VisualStudio.TestTools.UnitTesting;
using opp_lib;
using opp_lib.Fields;
using opp_lib.Gatess;
using opp_lib.Obstacles;
using opp_server.Classes.Abstract_Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace opp_server.Classes.Abstract_Factory.Tests
{
    [TestClass()]
    public class Level1FactoryTests
    {
        private AbstractLevelFactory levelFactory;

        [TestInitialize]
        public void CreateLevelFactory()
        {
            levelFactory = new Level1Factory();
        }

        [TestMethod()]
        public void CreateField_CreatesLevel1Field_FieldLevel1()
        {
            Field field = levelFactory.CreateField();
            Assert.IsInstanceOfType(field, typeof(FieldLevel1));
        }

        [TestMethod()]
        public void CreateGates_CreatesLevel1Gates_GatesLevel1()
        {
            Gates gates = levelFactory.CreateGates(0, 0);
            Assert.IsInstanceOfType(gates, typeof(GatesLevel1));
        }

        [TestMethod()]
        public void CreateObstacle_CreatesLevel1Obstacle_ObstacleLevel1()
        {
            Obstacle obstacle = levelFactory.CreateObstacle(0, 0);
            Assert.IsInstanceOfType(obstacle, typeof(ObstacleLevel1));
        }
    }
}