using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Gatess
{
    public class GatesLevel2 : Gates
    {
        public GatesLevel2(int xPosition, int yPosition) : base(300, "Green")
        {
            this.XPosition = xPosition;
            this.YPosition = yPosition;
        }
    }
}
