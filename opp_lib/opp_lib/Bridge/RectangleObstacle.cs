using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Bridge
{
    public class RectangleObstacle : Obstacle
    {
        public RectangleObstacle(string color)
        {
            this.Width = 100;
            this.Height = 50;
            this.Color = color;
        }
    }
}
