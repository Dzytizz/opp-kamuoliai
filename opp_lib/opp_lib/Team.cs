using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using opp_lib.Iterator;
using opp_lib.CompositePattern;

namespace opp_lib
{
    public class Team
    {
        public PlayerDictionary Players { get; set; }
        //public List<Player> Players { get; set; }
        public string Color { get; set; }
        public int Goals { get; set; }
        public Composite AttackPlayer { get; set; }
        public Composite DefendPlayer { get; set; }

        public Team()
        {
            this.Players = new PlayerDictionary();
            this.Color = "Gray";
            this.Goals = 0;
            this.AttackPlayer = new Composite();
            this.DefendPlayer = new Composite();
        }

        public Team(string color)
        {
            this.Players = new PlayerDictionary();
            this.Color = color;
            this.AttackPlayer = new Composite();
            this.DefendPlayer = new Composite();
        }

        public Team(PlayerDictionary players, string color)
        {
            this.Players = players;
            this.Color = color;
            this.AttackPlayer = new Composite();
            this.DefendPlayer = new Composite();
        }
    }
}
