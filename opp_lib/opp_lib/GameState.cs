using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace opp_lib
{
    public class GameState
    {
        private static GameState Instance { get; set; } = new GameState();
        public List<Team> Teams { get; set; }
        public bool AdminExists { get; set; } = false;
        public int CurrentLevel { get; set; }

        private GameState()
        {
            Teams = new List<Team>();
            CurrentLevel = 1;
        }

        public static GameState GetInstance()
        {
            return Instance;
        }

        public GameState Copy()
        {
            List<Team> newTeams = new List<Team>();
            for (int i = 0; i < Teams.Count; i++)
            {
                newTeams.Add(new Team());
                newTeams[i].Color = Teams[i].Color;

                foreach(KeyValuePair<string,Player> entry in Teams[i].Players.ToList())
                {
                    newTeams[i].Players.Add(entry.Key, entry.Value);
                }
                
            }
            GameState newGameState = new GameState();
            newGameState.Teams = newTeams;
            return newGameState;
        }

        public Player TryFindPlayer (string playerID)
        {
            Player player = null;
            for (int i = Teams.Count-1; i >= 0; i--)
            {
                if (Teams[i].Players.TryGetValue(playerID, out player))
                {
                    return player;
                }
            }

            return null;
        }

        public int TryFindPlayerTeamIndex(string playerID)
        {
            for (int i = Teams.Count-1; i >= 0 ; i--)
            {
                if (Teams[i].Players.ContainsKey(playerID))
                {
                    return i;
                }
            }

            return -1;
        }

        public void UpdatePlayer(string playerID, PlayerInput playerInput)
        {
            Player player = TryFindPlayer(playerID);
            if(player != null) 
            {
                player.UpdatePosition(playerInput);
            }
        }

        public override string ToString()
        {
            string s = "";
            foreach (Team team in Teams)
            {
                foreach (KeyValuePair<string, Player> entry in team.Players)
                {
                    s += entry.Value.ToString() + "|";
                }
            }
            return s;
        }
    }
}
