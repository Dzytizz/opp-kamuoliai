using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib
{
    public class Field
    {
        public string Color { get; set; }
        public float FrictionMultiplier { get; set; }

        public Field(string color, float frictionMultiplier)
        {
            this.Color = color;
            this.FrictionMultiplier = frictionMultiplier;
        }
    }
}
