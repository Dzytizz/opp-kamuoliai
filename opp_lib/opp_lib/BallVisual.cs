using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib
{
    public class BallVisual
    {
        public int Radius { get; set; }
        public string ImageName { get; set; }

        public BallVisual(int radius, string imageName)
        {
            Radius = radius;
            ImageName = imageName;
        }
    }
}
