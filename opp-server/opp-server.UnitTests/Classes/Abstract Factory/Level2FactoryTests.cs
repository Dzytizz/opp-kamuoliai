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
    public class Level2FactoryTests
    {
        private AbstractLevelFactory levelFactory;

        [TestInitialize]
        public void CreateLevelFactory()
        {
            levelFactory = new Level2Factory();
        }

        [TestMethod()]
        public void CreateField_CreatesLevel2Field_FieldLevel2()
        {
            Field field = levelFactory.CreateField();
            Assert.IsInstanceOfType(field, typeof(FieldLevel2));
        }

        [TestMethod()]
        public void CreateGates_CreatesLevel2Gates_GatesLevel2()
        {
            Gates gates = levelFactory.CreateGates(0, 0);
            Assert.IsInstanceOfType(gates, typeof(GatesLevel2));
        }

        [TestMethod()]
        public void CreateObstacle_CreatesLevel2Obstacle_ObstacleLevel2()
        {
            Obstacle obstacle = levelFactory.CreateObstacle(0, 0);
            Assert.IsInstanceOfType(obstacle, typeof(ObstacleLevel2));
        }
    }
}