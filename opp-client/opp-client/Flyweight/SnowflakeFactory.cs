using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_client.Flyweight
{
    static class SnowflakeFactory
    {
        private static Dictionary<string, SnowflakeType> SnowFlakeTypes = new Dictionary<string, SnowflakeType>();

        public static SnowflakeType GetSnowflakeType(string type, string color, int radius, int speed)
        {
            if (SnowFlakeTypes.ContainsKey(type)) return SnowFlakeTypes[type];
            else { 
                SnowFlakeTypes.Add(type, new SnowflakeType(color, radius, speed));
                return SnowFlakeTypes[type];
            }
        }
    }
}
