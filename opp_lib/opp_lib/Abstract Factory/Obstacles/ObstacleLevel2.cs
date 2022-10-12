using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Obstacles
{
    public class ObstacleLevel2 : Obstacle
    {
        public ObstacleLevel2(int xPosition, int yPosition): base(50, 50, "Black")
        {
            this.XPosition = xPosition;
            this.YPosition = yPosition;
        }
    }
}
