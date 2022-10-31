using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using opp_lib.Bridge;

namespace opp_lib.Obstacles
{
    public class ObstacleLevel1 : RectangleObstacle
    {
        public ObstacleLevel1(int xPosition, int yPosition): base(new OrangeColor().setColor())
        {
            this.XPosition = xPosition;
            this.YPosition = yPosition;
        }
    }
}
