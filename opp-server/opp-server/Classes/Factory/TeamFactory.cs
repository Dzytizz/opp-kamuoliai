using opp_lib.Teams;
using opp_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opp_server.Classes.Factory
{
    public class TeamFactory : Creator
    {
        public override Team GetTeam(string teamColor)
        {
            switch (teamColor)
            {
                case "Red":
                    return new RedTeam();
                case "Blue":
                    return new BlueTeam();
                case "Green":
                    return new GreenTeam();
                case "Yellow":
                    return new YellowTeam();
            }
            return null;
        }
    }
}
