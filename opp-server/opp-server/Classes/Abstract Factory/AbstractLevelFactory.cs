using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using opp_lib;

namespace opp_server.Classes.Abstract_Factory
{
    public abstract class AbstractLevelFactory
    {
        public abstract Gates CreateGates(int xPosition, int yPosition);
        public abstract Field CreateField();
        public abstract Obstacle CreateObstacle(int xPosition, int yPosition);
    }
}
