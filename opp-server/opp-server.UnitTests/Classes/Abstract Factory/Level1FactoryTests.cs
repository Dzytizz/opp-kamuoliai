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
        [TestMethod()]
        public void CreateField_CreatesLevel1Field_FieldLevel1()
        {
            AbstractLevelFactory levelFactory = new Level1Factory();
            Field field = levelFactory.CreateField();
            Assert.IsTrue(field is FieldLevel1);
        }

        [TestMethod()]
        public void CreateGates_CreatesLevel1Gates_GatesLevel1()
        {
            AbstractLevelFactory levelFactory = new Level1Factory();
            Gates gates = levelFactory.CreateGates(0, 0);
            Assert.IsTrue(gates is GatesLevel1);
        }

        [TestMethod()]
        public void CreateObstacle_CreatesLevel1Obstacle_ObstacleLevel1()
        {
            AbstractLevelFactory levelFactory = new Level1Factory();
            Obstacle obstacle = levelFactory.CreateObstacle(0, 0);
            Assert.IsTrue(obstacle is ObstacleLevel1);
        }
    }
}