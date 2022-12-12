using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using opp_lib.IteratorPattern;

namespace opp_lib
{
    public class GameState
    {
        private static GameState Instance { get; set; } = new GameState();
        // public List<Team> Teams { get; set; }
        public TeamList Teams { get; set; }
        public bool AdminExists { get; set; } = false;
        public int CurrentLevel { get; set; }
        private Iterator TeamIterator { get; set; }


        private GameState()
        {
            Teams = new TeamList();
            TeamIterator = Teams.CreateIterator();
          //  Teams = new List<Team>();
            CurrentLevel = 1;
        }

        public static GameState GetInstance()
        {
            return Instance;
        }

        public GameState Copy()
        {
            List<Team> newTeams = new List<Team>();
            int i = 0;
            while (TeamIterator.Next())
            {
                newTeams.Add(new Team());
                newTeams[i].Color = ((Team)TeamIterator.Current).Color;
                Iterator iterator = ((Team)TeamIterator.Current).iterator;
                while (iterator.Next())
                {
                    newTeams[i].Players.Add(((KeyValuePair<string, Player>)iterator.Current).Key, ((KeyValuePair<string, Player>)iterator.Current).Value);
                }
                //foreach (KeyValuePair<string, Player> entry in ((Team)TeamIterator.Current).Players.ToList())
                //{
                //    newTeams[i].Players.Add(entry.Key, entry.Value);
                //}
                i++;
            }
                //    }
                //for (int i = 0; i < Teams.Count; i++)
                //{
                //    newTeams.Add(new Team());
                //    newTeams[i].Color = Teams[i].Color;

                //    foreach(KeyValuePair<string,Player> entry in Teams[i].Players.ToList())
                //    {
                //        newTeams[i].Players.Add(entry.Key, entry.Value);
                //    }

                //}
                GameState newGameState = new GameState();
            foreach (var item in newTeams)
            {
                newGameState.Teams.Add(item);
            }
         //   newGameState.Teams = newTeams;
            return newGameState;
        }

        public Player TryFindPlayer (string playerID)
        {
            Player player = null;
            while(TeamIterator.Next())
            {
                if (((Team)TeamIterator.Current).Players.TryGetValue(playerID, out player))
                {
                    return player;
                }
            }
            //for (int i = Teams.Count-1; i >= 0; i--)
            //{
            //    if (Teams[i].Players.TryGetValue(playerID, out player))
            //    {
            //        return player;
            //    }
            //}

            return null;
        }

        public int TryFindPlayerTeamIndex(string playerID)
        {
            for (int i = Teams.Count-1; i >= 0 ; i--)
            {
                if (((Team)TeamIterator.Current).Players.ContainsKey(playerID))
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

            while (TeamIterator.Next())
            {
                Iterator iterator = ((Team)TeamIterator.Current).iterator;
                while (iterator.Next())
                {
                    s+= ((KeyValuePair<string, Player>)iterator.Current).Value.ToString() + "|";
                    //.Players.Add(((KeyValuePair<string, Player>)iterator.Current).Key, ((KeyValuePair<string, Player>)iterator.Current).Value);
                }
                //foreach (KeyValuePair<string, Player> entry in ((Team)TeamIterator.Current).Players)
                //{
                //    s += entry.Value.ToString() + "|";
                //}
            }
            //foreach (Team team in Teams)
            //{
            //    foreach (KeyValuePair<string, Player> entry in team.Players)
            //    {
            //        s += entry.Value.ToString() + "|";
            //    }
            //}
            return s;
        }
    }
}
