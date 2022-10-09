using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Gatess
{
    public class GatesLevel1 : Gates
    {
        public GatesLevel1(int xPosition, int yPosition) : base(200, "Black")
        {
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }
    }
}
