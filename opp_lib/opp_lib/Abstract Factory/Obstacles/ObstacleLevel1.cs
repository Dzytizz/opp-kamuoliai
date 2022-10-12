using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Obstacles
{
    public class ObstacleLevel1 : Obstacle
    {
        public ObstacleLevel1(int xPosition, int yPosition): base(100, 100, "Orange")
        {
            this.XPosition = xPosition;
            this.YPosition = yPosition;
        }
    }
}
