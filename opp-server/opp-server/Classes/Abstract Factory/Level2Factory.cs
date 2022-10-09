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
    public class Level2Factory : AbstractLevelFactory
    {
        public override Field CreateField()
        {
            return new FieldLevel2();
        }

        public override Gates CreateGates(int xPosition, int yPosition)
        {
            return new GatesLevel2(xPosition, yPosition);
        }

        public override Obstacle CreateObstacle(int xPosition, int yPosition)
        {
            return new ObstacleLevel2(xPosition, yPosition);
        }
    }
}
