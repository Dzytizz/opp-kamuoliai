using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Bridge
{
    public class SquareObstacle : Obstacle
    {
        public SquareObstacle(string color)
        {
            this.Width = 50;
            this.Height = 50;
            this.Color = color;            
        }
    }
}
