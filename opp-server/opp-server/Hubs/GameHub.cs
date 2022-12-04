using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Extensions.Hosting.Internal;
using opp_lib;
using Newtonsoft.Json;
using opp_server.Classes.Factory;
using opp_server.Classes.Abstract_Factory;
using opp_server.Classes.Observer;
using opp_server.Classes.Builder;
using opp_server.Classes;

namespace opp_server.Hubs
{
    public class GameHub : Hub
    {
        public GameState GameState;
        public Level Level;
        public Server Server;
        public Ball Ball;
        public BallMovement[] BallMovements;

        public GameHub(Level level, Server server, Ball ball, BallMovement[] ballMovements)
        {
            this.GameState = GameState.GetInstance();
            this.Level = level;
            this.Server = server;
            this.Ball = ball;
            this.BallMovements = ballMovements;
            foreach (var bm in ballMovements)
            {
                bm.Server = this.Server;
                bm.Level = this.Level;
            }
        }

        //public async Task JoinGameRequest()
        //{
        //    string response;
        //    if (GameState.Players.Count < 4)
        //    {
        //        string newPlayerID = Guid.NewGuid().ToString("N");
        //        Player newPlayer = new Player("Player " + (GameState.Players.Count + 1), 0, 0);
        //        GameState.Players.Add(newPlayerID, newPlayer);
        //        response = newPlayerID;
        //    }
        //    else
        //    {
        //        response = "null";
        //    }
        //    await Clients.Client(Context.ConnectionId).SendAsync("JoinGameResponse", response);
        //}

        public async Task SendMessageToAllRequest(string playerID, string message)
        {
            string playerName = GameState.TryFindPlayer(playerID).Name;
            string formedMessage = String.Format("{0}: {1}", playerName, message);
            await Clients.All.SendAsync("SendMessageToAllResponse", formedMessage);
        }

        public async Task KickBallRequest(string playerID)
        {
            Player player = GameState.TryFindPlayer(playerID);
            foreach (var bm in BallMovements)
            {
                bm.BallLoop.Enabled = false;
            }
            BallMovements[GameState.CurrentLevel-1].BallLoop.Enabled = true;
            BallMovements[GameState.CurrentLevel-1].KickBall(player);
            await Clients.Client(Context.ConnectionId).SendAsync("KickBallResponse");
        }

        public async Task BallRequest()
        {
            // ======= some code that updates ball position goes here =======
            //Ball.XPosition += 2;

            string ballJSON = JsonConvert.SerializeObject(Ball, Formatting.None, new JsonSerializerSettings(){ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
            await Clients.Client(Context.ConnectionId).SendAsync("BallResponse", ballJSON);
        }

        public async Task IsAdminRequest()
        {      
            if(!GameState.AdminExists)
            {
                GameState.AdminExists = true;
                await Clients.Client(Context.ConnectionId).SendAsync("IsAdminResponse", true);
            }
            else
            {
                await Clients.Client(Context.ConnectionId).SendAsync("IsAdminResponse", false);
            }

            //GameState.Players[playerID].UpdatePosition(playerInput); <============
            //await Clients.Client(Context.ConnectionId).SendAsync("UpdatePlayerPositionResponse", playerID + " position updated"); // response was only used for debugging
        }

        public async Task CreateTeamsRequest(string team1Color, string team2Color)
        {
            Creator creator = new TeamFactory();
            GameState.Teams.Add(creator.GetTeam(team1Color));
            GameState.Teams.Add(creator.GetTeam(team2Color));
            await Clients.All.SendAsync("CreateTeamsResponse");
        }

        public async Task AreTeamsCreatedRequest()
        {
            bool response = GameState.Teams.Count == 2;
            await Clients.Client(Context.ConnectionId).SendAsync("AreTeamsCreatedResponse", response);
        }

        public async Task TeamColorsRequest()
        {
            string team1Color = GameState.Teams[0].Color;
            string team2Color = GameState.Teams[1].Color;
            await Clients.Client(Context.ConnectionId).SendAsync("TeamColorsResponse", team1Color, team2Color);
        }

        public async Task LevelRequest()
        {
            GenerateLevel();
            string levelJSON = JsonConvert.SerializeObject(Level);
            await Clients.Client(Context.ConnectionId).SendAsync("LevelResponse", levelJSON);
        }

        public async Task LevelChangeRequest(List<string> arguments)
        {
            //if(GameState.CurrentLevel < 3)
            //    GameState.CurrentLevel++;
            try
            {
                int level = Int32.Parse(arguments[0]);
                GameState.CurrentLevel = level;
            }
            catch
            {
                return;
            }
            GenerateLevel();
            string levelJSON = JsonConvert.SerializeObject(Level);
            await Clients.All.SendAsync("LevelChangeResponse", levelJSON);
        }

        public async Task UpdatePlayerPositionRequest(string playerID, string playerInputJSON)
        {
            PlayerInput playerInput = JsonConvert.DeserializeObject<PlayerInput>(playerInputJSON);
            Player player = GameState.TryFindPlayer(playerID);
            player.UpdatePosition(playerInput);
            Server.Send();
            //GameState.Players[playerID].UpdatePosition(playerInput); <============
            await Clients.Client(Context.ConnectionId).SendAsync("UpdatePlayerPositionResponse", playerID + " position updated"); // response was only used for debugging
        }

        public async Task GameStateRequest()
        {
            GameState gsCopy = GameState.Copy();
            string gameStateJSON = JsonConvert.SerializeObject(gsCopy);
            await Clients.Client(Context.ConnectionId).SendAsync("GameStateResponse", gameStateJSON);
        }

        public async Task JoinTeamRequest(int teamIndex, string oldPlayerID, string playerName, string playerUniform, int playerNumber)
        {
            int existingTeamIndex = GameState.TryFindPlayerTeamIndex(oldPlayerID); // check if oldPlayerID exists
            string newPlayerID = "";
            if (existingTeamIndex == -1) // if doesn't exist generate new ID
            {
                newPlayerID = Guid.NewGuid().ToString("N");
            }
            else // if exists remove and set newPlayerID to oldPlayerID
            {
                GameState.Teams[existingTeamIndex].Players.Remove(oldPlayerID);
                await Clients.All.SendAsync("ReceivePlayerCount", existingTeamIndex, -1);   // also update teamCounter in all clients (removes one)
                newPlayerID = oldPlayerID;
            }

            Player newPlayer = new Player(playerName, 0, 0, playerUniform, playerNumber);
            GameState.Teams[teamIndex].Players.Add(newPlayerID, newPlayer);
            Client client = new Client(Clients.Client(Context.ConnectionId));
            client.Ball = Ball;
            Server.Subscribe(client);
            await Clients.Client(Context.ConnectionId).SendAsync("JoinTeamResponse", newPlayerID, GameState.Teams[teamIndex].Color);
            await Clients.All.SendAsync("ReceivePlayerCount", teamIndex, 1); // update teamCounter for all clients (adds one)
        }
        public async Task PlayerCountRequest()
        {
            await Clients.Client(Context.ConnectionId).SendAsync("PlayerCountResponse", GameState.Teams[0].Players.Count(), GameState.Teams[1].Players.Count());
        }

        private void GenerateLevel()
        {
            AbstractLevelFactory factory;
            int gatesYPosition = 100;
            int rightGatesXPosition = 812;
            switch (GameState.CurrentLevel)
            {
                case 1:
                    factory = new Level1Factory();
                    gatesYPosition = 100;
                    break;
                case 2:
                    factory = new Level2Factory();
                    //pakeist
                    gatesYPosition = 75;
                    break;
                default:
                    factory = new Level1Factory();
                    break;
            }
            Gates leftGates = factory.CreateGates(0, gatesYPosition);
            Gates rightGates = factory.CreateGates(rightGatesXPosition, gatesYPosition);
            Field field = factory.CreateField();
            foreach (var bm in BallMovements)
            {
                bm.Field = field;
            }
            //Padaryt random ir daug
            Obstacle obstacle = factory.CreateObstacle(375, 150);
            List<Obstacle> obstacles = new List<Obstacle>();
            obstacles.Add(obstacle);
        
            Level.SetLevel(leftGates, rightGates, field, obstacles);
        }

        //private void SetUpBallMovement(int currentLevel)
        //{
        //    if (BallMovement != null)
        //    {
        //        BallMovement.BallLoop.Stop();
        //        BallMovement.BallLoop.Dispose();
        //        BallMovement = null;
        //    }
        //    switch (currentLevel)
        //    {
        //        case 1:
        //            BallMovement = new NormalBallMovement(Ball);
        //            break;
        //        case 2:
        //            BallMovement = new FrictionlessBallMovement(Ball);
        //            break;
        //        default:
        //            BallMovement = new NormalBallMovement(Ball);
        //            break;
        //    }   
        //    BallMovement.Server = Server;
        //}

        //public async Task SendMessage(string user, string message)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", user, message);
        //}
    }
}
