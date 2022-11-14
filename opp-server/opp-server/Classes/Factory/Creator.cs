using opp_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace opp_server.Classes.Factory
{
    public abstract class Creator
    {
        public abstract Team GetTeam(string teamColor);
    }
}
