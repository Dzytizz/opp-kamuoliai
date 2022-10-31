using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using opp_lib.Bridge;
namespace opp_lib.Obstacles
{
    public class ObstacleLevel2 : SquareObstacle
    {
        public ObstacleLevel2(int xPosition, int yPosition): base(new PurpleColor().setColor())
        {
            this.XPosition = xPosition;
            this.YPosition = yPosition;
        }
    }
}
