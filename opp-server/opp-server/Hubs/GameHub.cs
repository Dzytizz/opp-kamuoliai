using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Extensions.Hosting.Internal;
using opp_lib;
using Newtonsoft.Json;
using opp_lib.Iterator;
using opp_server.Classes.Factory;
using opp_server.Classes.Abstract_Factory;
using opp_server.Classes.Observer;
using opp_server.Classes.Builder;
using opp_server.Classes.Template;
using opp_server.Classes.Mediator;
using opp_lib.CompositePattern;
using opp_lib.State;
using opp_server.Classes.Memento;

namespace opp_server.Hubs
{
    public class GameHub : Hub
    {
        public GameState GameState;
        public Level Level;
        public Server Server;
        public Ball Ball;
        public BallMovement[] BallMovements;
        public ChatRoom ChatRoom;
        public Originator Originator;
        //private Memento Memento;
        private Caretaker Caretaker;
        

        public GameHub(Level level, Server server, Ball ball, BallMovement[] ballMovements, ChatRoom chatRoom, Originator originator, Caretaker caretaker)
        {
            this.GameState = GameState.GetInstance();
            this.GameState.Ball = ball;
            this.Level = level;
            this.Server = server;
            this.Ball = ball;
            this.BallMovements = ballMovements;
            this.ChatRoom = chatRoom;
            this.Originator = originator;
            //this.Originator.State = this.GameState.Copy();
            this.Caretaker = caretaker;
            foreach (var bm in ballMovements)
            {
                bm.Server = this.Server;
                bm.Level = this.Level;
            }
            
        }

        public async Task SaveGameState()
        {
            this.Originator.State = GameState.Copy();
            this.Caretaker.Memento = this.Originator.CreateMemento();
        }

        public async Task RestartGameState()
        {
            this.Originator.SetMemento(this.Caretaker.Memento);
            GameState = Originator.State.Copy();

            GameState.GetInstance().Teams = Originator.State.Copy().Teams;
            GameState.GetInstance().Ball = Originator.State.Copy().Ball;
            GameState.SetupGamestate(Originator.State.Copy());
            GameState gsCopy = GameState.Copy();
            string gameStateJSON = JsonConvert.SerializeObject(gsCopy);
            await Clients.All.SendAsync("GameStateResponse", gameStateJSON);
            //await Clients.All.SendAsync("RestartGameStateResponse");
        }

        public async Task StartGameRequest()
        {
            if (GameState.State is WaitingState) GameState.StartGame();
        }

        public async Task StateStatusRequest()
        {
            await Clients.Client(Context.ConnectionId).SendAsync("StateStatusResponse", GameState.State.GetStateStatus());
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
        public async Task SendMessageToRequest(string playerID, List<string> arguments)
        {
            string to = arguments[0];
            string from = GameState.TryFindPlayer(playerID).Name;
            List<string> messageCopy = arguments;
            messageCopy.RemoveAt(0);
            string message = String.Join(' ', messageCopy);
            ChatRoom.Send(from, to, message);
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
            if (!(GameState.State is WaitingState)) return;
            try
            {
                int level = Int32.Parse(arguments[0]);
                GameState.CurrentLevel = level;
                Originator.State = GameState;
                Caretaker.Memento = Originator.CreateMemento();
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

        public async Task JoinTeamRequest(int teamIndex, string oldPlayerID, string playerName, string playerUniform, int playerNumber, string playerPosition)
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
                Player tempPlayer;
                GameState.Teams[existingTeamIndex].Players.TryGetValue(oldPlayerID, out tempPlayer);
                GameState.Teams[existingTeamIndex].AttackPlayer.Remove(new Leaf(tempPlayer));
                GameState.Teams[existingTeamIndex].DefendPlayer.Remove(new Leaf(tempPlayer));
                newPlayerID = oldPlayerID;
            }

            Player newPlayer = new Player(playerName, 0, 0, playerUniform, playerNumber);
            if (playerPosition.Equals("Defend player"))
            {
                GameState.Teams[teamIndex].DefendPlayer.Add(new Leaf(newPlayer));
            }
            if (playerPosition.Equals("Attack player"))
            {
                GameState.Teams[teamIndex].AttackPlayer.Add(new Leaf(newPlayer));
            }
            GameState.Teams[teamIndex].AttackPlayer.SetValues(5, 50);
            GameState.Teams[teamIndex].DefendPlayer.SetValues(3, 70);
            GameState.Teams[teamIndex].Players.Add(newPlayerID, newPlayer);

            Client client = new Client(Clients.Client(Context.ConnectionId));
            ChatRoom.Register(new SingleChatRoomMember(playerName, Clients.Client(Context.ConnectionId)));
            client.Ball = Ball;
            Server.Subscribe(client);
            
            await Clients.Client(Context.ConnectionId).SendAsync("JoinTeamResponse", newPlayerID, GameState.Teams[teamIndex].Color);
            await Clients.All.SendAsync("ReceivePlayerCount", teamIndex, 1); // update teamCounter for all clients (adds one)
        }
        public async Task PlayerCountRequest()
        {
            await Clients.Client(Context.ConnectionId).SendAsync("PlayerCountResponse", GameState.Teams[0].Players.Count(), GameState.Teams[1].Players.Count());
        }

        public async Task WallRequest(int screenWidth, int screenHeight)
        {
            Obstacle upperWall = new Obstacle(0, 31, screenWidth, 1, "Black");
            Obstacle leftWall1 = new Obstacle(0, 31, 1, Level.LeftGates.YPosition, "Black");
            Obstacle leftWall2 = new Obstacle(0, Level.LeftGates.YPosition + Level.LeftGates.Height, 1, screenHeight - (Level.LeftGates.YPosition + Level.LeftGates.Height), "Black");
            Obstacle downWall = new Obstacle(0, 370, screenWidth, 1, "Black");
            Obstacle rightWall1 = new Obstacle(screenWidth, 31, 1, Level.RightGates.YPosition, "Black");
            Obstacle rightWall2 = new Obstacle(screenWidth, Level.RightGates.YPosition+Level.RightGates.Height, 1, screenHeight - (Level.RightGates.YPosition + Level.RightGates.Height), "Black");
            List<Obstacle> walls = new List<Obstacle>() { upperWall, leftWall1, leftWall2, downWall, rightWall1, rightWall2 };
            this.Level.Obstacles.AddRange(walls);
            await Clients.Client(Context.ConnectionId)
                .SendAsync("WallResponse", walls);
        }

        public async Task WallRemoveRequest(int screenWidth, int screenHeight)
        {
            Obstacle upperWall = new Obstacle(0, 31, screenWidth, 1, "Black");
            Obstacle leftWall1 = new Obstacle(0, 31, 1, Level.LeftGates.YPosition, "Black");
            Obstacle leftWall2 = new Obstacle(0, Level.LeftGates.YPosition + Level.LeftGates.Height, 1, screenHeight - (Level.LeftGates.YPosition + Level.LeftGates.Height), "Black");
            Obstacle downWall = new Obstacle(0, 370, screenWidth, 1, "Black");
            Obstacle rightWall1 = new Obstacle(screenWidth, 31, 1, Level.RightGates.YPosition, "Black");
            Obstacle rightWall2 = new Obstacle(screenWidth, Level.RightGates.YPosition + Level.RightGates.Height, 1, screenHeight - (Level.RightGates.YPosition + Level.RightGates.Height), "Black");
            this.Level.Obstacles.Remove(upperWall);
            this.Level.Obstacles.Remove(leftWall1);
            this.Level.Obstacles.Remove(leftWall2);
            this.Level.Obstacles.Remove(downWall);
            this.Level.Obstacles.Remove(rightWall1);
            this.Level.Obstacles.Remove(rightWall2);
            await Clients.Client(Context.ConnectionId).SendAsync("WallRemoveResponse");
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
            List<Obstacle> obstacles = new List<Obstacle>();
            // viena kliutis
            Obstacle obstacle = factory.CreateObstacle(400, 31);

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
