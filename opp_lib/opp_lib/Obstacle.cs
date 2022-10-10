using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib
{
    public class Obstacle
    {
        public int xPosition;
        public int yPosition;
        public int width;
        public int height;
        public string color;

        public Obstacle(int width, int height, string color)
        {
            this.width = width;
            this.height = height;
            this.color = color;
        }
    }
}
