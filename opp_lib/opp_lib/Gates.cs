using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib
{
    public class Gates
    {
        public int xPosition;
        public int yPosition;
        public int width = 20;
        public int height;
        public string color;

        public Gates(int height, string color)
        {
            this.height = height;
            this.color = color;
        }
    }
}
