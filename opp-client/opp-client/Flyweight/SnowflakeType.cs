using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_client.Flyweight
{
    public class SnowflakeType
    {
        public string Color { get; private set; }
        public int Radius { get; private set; }
        public int Speed { get; private set; }

        public SnowflakeType(string color, int radius, int speed)
        {
            Color = color;
            Radius = radius;
            Speed = speed;
        }
    }
}
