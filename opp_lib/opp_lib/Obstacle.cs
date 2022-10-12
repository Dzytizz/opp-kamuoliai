using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib
{
    public class Obstacle
    {
        public int XPosition { get;set; }
        public int YPosition { get;set; }
        public int Width { get;set; }
        public int Height { get;set; }
        public string Color { get;set; }

        public Obstacle(int width, int height, string color)
        {
            this.Width = width;
            this.Height = height;
            this.Color = color;
        }
    }
}
