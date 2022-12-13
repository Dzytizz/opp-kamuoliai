﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using opp_lib.Iterator;

namespace opp_lib
{
    public class Team
    {
        public PlayerDictionary Players { get; set; }
        //public List<Player> Players { get; set; }
        public string Color { get; set; }

        public Team()
        {
            this.Players = new PlayerDictionary();
            this.Color = "Gray";
        }

        public Team(string color)
        {
            this.Players = new PlayerDictionary();
            this.Color = color;
        }

        public Team(PlayerDictionary players, string color)
        {
            this.Players = players;
            this.Color = color;
        }
    }
}
