using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib
{
    public class Team
    {
        public Dictionary<string, Player> Players { get; set; }
        public string Color { get; set; }

        public Team()
        {
            this.Players = new Dictionary<string, Player>();
            this.Color = "Gray";
        }

        public Team(string color)
        {
            this.Players = new Dictionary<string, Player>();
            this.Color = color;
        }

        public Team(Dictionary<string, Player> players, string color)
        {
            this.Players = players;
            this.Color = color;
        }
    }
}
