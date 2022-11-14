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
        [TestMethod()]
        public void CreateField_CreatesLevel2Field_FieldLevel2()
        {
            AbstractLevelFactory levelFactory = new Level2Factory();
            Field field = levelFactory.CreateField();
            Assert.IsTrue(field is FieldLevel2);
        }

        [TestMethod()]
        public void CreateGates_CreatesLevel2Gates_GatesLevel2()
        {
            AbstractLevelFactory levelFactory = new Level2Factory();
            Gates gates = levelFactory.CreateGates(0, 0);
            Assert.IsTrue(gates is GatesLevel2);
        }

        [TestMethod()]
        public void CreateObstacle_CreatesLevel2Obstacle_ObstacleLevel2()
        {
            AbstractLevelFactory levelFactory = new Level2Factory();
            Obstacle obstacle = levelFactory.CreateObstacle(0, 0);
            Assert.IsTrue(obstacle is ObstacleLevel2);
        }
    }
}