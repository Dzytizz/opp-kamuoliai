using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib
{
    public class GameState
    {
        public Dictionary<string, Player> Players;

        public GameState()
        {
            Players = new Dictionary<string, Player>();
        }

        public void UpdatePlayer(string playerID, PlayerInput playerInput)
        {
            Players[playerID].UpdatePosition(playerInput);
        }

        public override string ToString()
        {
            string s = "";
            foreach (KeyValuePair<string, Player> entry in Players)
            {
                s += entry.Value.ToString() + "\n";
            }
            return s;
        }
    }
}
