using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using opp_lib;
using opp_server.Classes.Observer;
using opp_server.Hubs;
using SignalR_UnitTestingSupportMSTest.Hubs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace opp_server.Hubs.Tests
{
    [TestClass()]
    public class GameHubTests : HubUnitTestsBase
    {
        private GameHub gameHub;
        private Level level;
        private Server server;
        private Ball ball;

        [TestInitialize]
        public void CreateGameHub()
        {
            level = new Level();
            server = new Server();
            ball = new Ball(15, 0, 0, "White");

            gameHub = null;
        }
        

        [TestMethod()]
        public async Task BallRequest_()
        {
            gameHub = new GameHub(level, server, ball);
            AssignToHubRequiredProperties(gameHub);

            await gameHub.BallRequest();

            object[] response = new object[] { JsonConvert.SerializeObject(ball, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }) };
            
            ClientsAllMock
                .Verify(x => x.SendCoreAsync("BallResponse", response, It.IsAny<CancellationToken>()));
        }

        [TestMethod()]
        public async Task IsAdminRequest_True()
        {
            gameHub = new GameHub(level, server, ball);
            AssignToHubRequiredProperties(gameHub);

            gameHub.GameState.AdminExists = false;
            await gameHub.IsAdminRequest();

            object[] response = new object[] { true };

            ClientsClientMock
                .Verify(x => x.SendCoreAsync("IsAdminResponse", response, It.IsAny<CancellationToken>()));
        }

        [TestMethod()]
        public async Task IsAdminRequest_False()
        {
            gameHub = new GameHub(level, server, ball);
            AssignToHubRequiredProperties(gameHub);

            gameHub.GameState.AdminExists = true;
            await gameHub.IsAdminRequest();

            object[] response = new object[] { false };

            ClientsClientMock
                .Verify(x => x.SendCoreAsync("IsAdminResponse", response, It.IsAny<CancellationToken>()));
        }

        [TestMethod]
        public async Task CreateTeamsRequest_()
        {
            gameHub = new GameHub(level, server, ball);
            AssignToHubRequiredProperties(gameHub);

            await gameHub.CreateTeamsRequest("Red", "Blue");

            object[] response = Array.Empty<object>();

            ClientsAllMock
                .Verify(x => x.SendCoreAsync("CreateTeamsResponse", response, It.IsAny<CancellationToken>()));
        }

        [TestMethod()]
        public async Task AreTeamsCreatedRequest_False()
        {
            gameHub = new GameHub(level, server, ball);
            AssignToHubRequiredProperties(gameHub);

            gameHub.GameState.Teams = new List<Team>();
            await gameHub.AreTeamsCreatedRequest();

            object[] response = new object[] { false };

            ClientsClientMock
                .Verify(x => x.SendCoreAsync("AreTeamsCreatedResponse", response, It.IsAny<CancellationToken>()));
        }

        [TestMethod()]
        public async Task AreTeamsCreatedRequest_True()
        {
            gameHub = new GameHub(level, server, ball);
            AssignToHubRequiredProperties(gameHub);

            List<Team> twoTeams = new List<Team>() { new Team(), new Team() };
            gameHub.GameState.Teams = twoTeams;
            await gameHub.AreTeamsCreatedRequest();

            object[] response = new object[] { true };

            ClientsClientMock
                .Verify(x => x.SendCoreAsync("AreTeamsCreatedResponse", response, It.IsAny<CancellationToken>()));
        }

        [DataRow("Red", "Blue")]
        [DataRow("Green", "Yellow")]
        [DataTestMethod()]
        public async Task TeamColorsRequest_(string team1Color, string team2Color)
        {
            gameHub = new GameHub(level, server, ball);
            AssignToHubRequiredProperties(gameHub);

            List<Team> twoTeams = new List<Team>() { new Team(team1Color), new Team(team2Color) };
            gameHub.GameState.Teams = twoTeams;
            await gameHub.TeamColorsRequest();

            object[] response = new object[] { team1Color, team2Color };

            ClientsClientMock
                .Verify(x => x.SendCoreAsync("TeamColorsResponse", response, It.IsAny<CancellationToken>()));
        }

        [TestMethod()]
        public async Task LevelRequest_()
        {
            gameHub = new GameHub(level, server, ball);
            AssignToHubRequiredProperties(gameHub);

            await gameHub.LevelRequest();

            string levelJSON = JsonConvert.SerializeObject(level);
            object[] response = new object[] { levelJSON };

            ClientsClientMock
                .Verify(x => x.SendCoreAsync("LevelResponse", response, It.IsAny<CancellationToken>()));
        }

        [TestMethod()]
        public async Task LevelChangeRequest_()
        {
            gameHub = new GameHub(level, server, ball);
            AssignToHubRequiredProperties(gameHub);

            await gameHub.LevelChangeRequest();

            string levelJSON = JsonConvert.SerializeObject(level);
            object[] response = new object[] { levelJSON };

            ClientsAllMock
                .Verify(x => x.SendCoreAsync("LevelChangeResponse", response, It.IsAny<CancellationToken>()));
        }

        [TestMethod()]
        public async Task UpdatePlayerPositionRequest_()
        {
            gameHub = new GameHub(level, server, ball);
            AssignToHubRequiredProperties(gameHub);

            string playerID = "testId";
            Player newPlayer = new Player("playerName", 0, 0, "stripes", 15);
            gameHub.GameState.Teams = new List<Team>() { new Team("Red") };
            gameHub.GameState.Teams[0].Players.Add(playerID, newPlayer);

            PlayerInput playerInput = new PlayerInput();
            playerInput.Up = true;
            string playerInputJSON = JsonConvert.SerializeObject(playerInput);

            await gameHub.UpdatePlayerPositionRequest(playerID, playerInputJSON);

            object[] response = new object[] { playerID + " position updated" };

            ClientsClientMock
                .Verify(x => x.SendCoreAsync("UpdatePlayerPositionResponse", response, It.IsAny<CancellationToken>()));
        }

        [TestMethod()]
        public async Task GameStateRequest_()
        {
            gameHub = new GameHub(level, server, ball);
            AssignToHubRequiredProperties(gameHub);

            await gameHub.GameStateRequest();

            string gameStateJSON = JsonConvert.SerializeObject(gameHub.GameState.Copy());
            object[] response = new object[] { gameStateJSON };

            ClientsClientMock
                .Verify(x => x.SendCoreAsync("GameStateResponse", response, It.IsAny<CancellationToken>()));
        }

        [DataRow(0, "", "name", "dots", 15)]
        [DataTestMethod]
        public async Task JoinTeamRequest_(int teamIndex, string oldPlayerID, string playerName, string playerUniform, int playerNumber)
        {
            gameHub = new GameHub(level, server, ball);
            AssignToHubRequiredProperties(gameHub);

            await gameHub.JoinTeamRequest(teamIndex, oldPlayerID, playerName, playerUniform, playerNumber);

            object[] response = new object[] { teamIndex, 1};

            ClientsAllMock
                .Verify(x => x.SendCoreAsync("ReceivePlayerCount", response, It.IsAny<CancellationToken>()));
        }

        [TestMethod()]
        public async Task PlayerCountRequest_()
        {
            gameHub = new GameHub(level, server, ball);
            AssignToHubRequiredProperties(gameHub);

            List<Team> twoTeams = new List<Team>() { new Team(), new Team() };
            Player newPlayer1 = new Player("playerName1", 0, 0, "stripes", 15);
            Player newPlayer2 = new Player("playerName2", 0, 0, "dots", 33);
            twoTeams[0].Players.Add("id1", newPlayer1);
            twoTeams[1].Players.Add("id2", newPlayer2);
            gameHub.GameState.Teams = twoTeams;

            await gameHub.PlayerCountRequest();

            object[] response = new object[] { 1,1 };

            ClientsClientMock
                .Verify(x => x.SendCoreAsync("PlayerCountResponse", response, It.IsAny<CancellationToken>()));
        }
    }
}