using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using opp_lib;
using opp_lib.Fields;
using opp_lib.Gatess;
using opp_lib.Obstacles;

namespace opp_server.Classes.Abstract_Factory
{
    public class Level1Factory : AbstractLevelFactory
    {
        public override Field CreateField()
        {
            return new FieldLevel1();
        }

        public override Gates CreateGates(int xPosition, int yPosition)
        {
            return new GatesLevel1(xPosition, yPosition);
        }

        public override Obstacle CreateObstacle(int xPosition, int yPosition)
        {
            return new ObstacleLevel1(xPosition, yPosition);
        }
    }
}
