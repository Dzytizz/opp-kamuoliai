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
            int startingXPosition = 325;
            int startingYPosition = 85;
            foreach(Team team in Teams)
            {
                int playerId = 0;
                foreach (KeyValuePair<string, Player> player in team.Players)
                {
                    player.Value.XPosition = startingXPosition + (teamId * 200) - (player.Value.Radius / 2);
                    player.Value.YPosition = startingYPosition + (playerId * 200) - (player.Value.Radius / 2);
                    playerId++;
                }
                teamId++;
            }
            Ball.XPosition = (850 / 2) - (Ball.Radius / 2);
            Ball.YPosition = (370 / 2) - (Ball.Radius / 2);
        }

        public void SetupGamestate(GameState copy)
        {
            foreach (Team team in Teams)
            {
                foreach (KeyValuePair<string, Player> player in team.Players)
                {
                    Player neededPlayer = copy.TryFindPlayer(player.Key);
                    player.Value.XPosition = neededPlayer.XPosition;
                    player.Value.YPosition = neededPlayer.YPosition;
                }
            }

            Ball oldBall = this.Ball;
            Ball newBall = new Ball(oldBall.Radius, oldBall.XPosition, oldBall.YPosition, oldBall.MainColor);
            this.Ball = newBall;
        }

        public void Score(int teamId)
        {
            if (State is PlayingState) { 
                Teams[teamId].Goals++;
                ChangeState(new GoalState(this));
            }
        }

        public void ResetScore()
        {
            foreach(Team team in Teams)
            {
                team.Goals = 0;
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
                    Player oldPlayer = entry.Value;
                    Player newPlayer = new Player(oldPlayer.Name, oldPlayer.XPosition, oldPlayer.YPosition, oldPlayer.UniformName, oldPlayer.Number);
                    newPlayer.Radius = oldPlayer.Radius;
                    newPlayer.Speed = oldPlayer.Speed;
                    newTeams[i].Players.Add(entry.Key, newPlayer);
                }
                
            }
            GameState newGameState = new GameState();
            AbstractState oldState = this.State;
            if (oldState is WaitingState) newGameState.State = new WaitingState(newGameState);
            else if (oldState is PlayingState) newGameState.State = new PlayingState(newGameState);
            else if (oldState is GoalState) newGameState.State = new GoalState(newGameState);

            Ball oldBall = this.Ball;
            Ball newBall = new Ball(oldBall.Radius, oldBall.XPosition, oldBall.YPosition, oldBall.MainColor);
            newGameState.Ball = newBall;

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
