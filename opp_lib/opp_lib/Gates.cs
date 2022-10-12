using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib
{
    public class Gates
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public int Width { get; set; } = 20;
        public int Height { get; set; }
        public string Color { get; set; }

        public Gates(int height, string color)
        {
            this.Height = height;
            this.Color = color;
        }
    }
}
