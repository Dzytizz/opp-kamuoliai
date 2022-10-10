using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib
{
    public class Field
    {
        public string color;
        public float frictionMultiplier;

        public Field(string color, float frictionMultiplier)
        {
            this.color = color;
            this.frictionMultiplier = frictionMultiplier;
        }
    }
}
