using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using opp_lib.Iterator;
using opp_lib.State;

namespace opp_lib
{
    public class GameState
    {
        private static GameState Instance { get; set; } = new GameState();
        public TeamList Teams { get; set; }
        public bool AdminExists { get; set; } = false;
        public int CurrentLevel { get; set; }

        public Ball Ball { get; set; }

        public AbstractState State { get; set; }

        private GameState()
        {
            Teams = new TeamList();
            CurrentLevel = 1;
            State = new WaitingState(this);
        }

        public void StartGame()
        {
            ChangeState(new PlayingState(this));
        }

        public void ChangeState(AbstractState state)
        {
            this.State = state;
            this.State.StateStartAction();
        }

        public void ResetPlayersAndBall()
        {
            int teamId = 0;
            int startingXPosition = 100;
            int startingYPosition = 100;
            foreach(Team team in Teams)
            {
                int playerId = 0;
                foreach (KeyValuePair<string, Player> player in team.Players)
                {
                    player.Value.XPosition = startingXPosition + (teamId * 100);
                    player.Value.YPosition = startingYPosition + (playerId * 100);
                    playerId++;
                }
                teamId++;
            }
            Ball.XPosition = 150;
            Ball.YPosition = 150;
        }

        public void Score(int teamId)
        {
            if (State is PlayingState) { 
                Teams[teamId].Goals++;
                ChangeState(new GoalState(this));
            }
        }

        public static GameState GetInstance()
        {
            return Instance;
        }

        public GameState Copy()
        {
            TeamList newTeams = new TeamList();
            for (int i = 0; i < Teams.Count; i++)
            {
                newTeams.Add(new Team());
                newTeams[i].Color = Teams[i].Color;
                newTeams[i].Goals = Teams[i].Goals;

                foreach(KeyValuePair<string,Player> entry in Teams[i].Players)
                {
                    newTeams[i].Players.Add(entry.Key, entry.Value);
                }
                
            }
            GameState newGameState = new GameState();
            AbstractState oldState = this.State;
            if (oldState is WaitingState) newGameState.State = new WaitingState(newGameState);
            else if (oldState is PlayingState) newGameState.State = new PlayingState(newGameState);
            else if (oldState is GoalState) newGameState.State = new GoalState(newGameState);
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
