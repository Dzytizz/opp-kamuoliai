using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using opp_lib;
using Newtonsoft.Json;

namespace opp_server.Hubs
{
    public class GameHub : Hub
    {
        public GameState GameState;

        public GameHub(GameState gameState)
        {
            GameState = gameState;
        }

        public async Task JoinGameRequest()
        {
            string response;
            if(GameState.Players.Count < 4)
            {
                string newPlayerID = Guid.NewGuid().ToString("N");
                Player newPlayer = new Player("Player " + (GameState.Players.Count + 1), 0, 0);
                GameState.Players.Add(newPlayerID, newPlayer);
                response = newPlayerID;
            }
            else
            {
                response = "null";
            }
            await Clients.Client(Context.ConnectionId).SendAsync("JoinGameResponse", response);
        }

        public async Task UpdatePlayerPositionRequest(string playerID, string playerInputJSON)
        {
            PlayerInput playerInput = JsonConvert.DeserializeObject<PlayerInput>(playerInputJSON);
            GameState.Players[playerID].UpdatePosition(playerInput);
            await Clients.Client(Context.ConnectionId).SendAsync("UpdatePlayerPositionResponse", playerID + " position updated");
        }

        public async Task GameStateRequest()
        {
            string gameStateJSON = JsonConvert.SerializeObject(GameState);
            await Clients.Client(Context.ConnectionId).SendAsync("GameStateResponse", gameStateJSON);
        }

        //public async Task SendMessage(string user, string message)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", user, message);
        //}
    }
}
