using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using opp_lib.IteratorPattern;
using System.Threading.Tasks;

namespace opp_lib
{
    public class Team
    {
        public PlayerDictionary  Players{ get; set; }
        public Iterator iterator { get; set; }
        // public Dictionary<string, Player> Players { get; set; }
        public string Color { get; set; }

        public Team()
        {
            Players = new PlayerDictionary();
            iterator = Players.CreateIterator();
            //this.Players = new Dictionary<string, Player>();
            //  this.Players = new Dictionary<string, Player>();
            this.Color = "Gray";
        }

        public Team(string color)
        {
            Players = new PlayerDictionary();
            iterator = Players.CreateIterator();
           // this.Players = new Dictionary<string, Player>();
            this.Color = color;
        }

        public Team(Dictionary<string, Player> players, string color)
        {
            Players = new PlayerDictionary();
            iterator = Players.CreateIterator();
           // this.Players = players;
            this.Color = color;
        }
    }
}
