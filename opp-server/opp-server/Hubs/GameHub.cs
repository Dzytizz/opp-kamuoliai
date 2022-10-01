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

        public async Task UpdatePlayerPositionRequest(string playerID, string playerInputJSON)
        {
            PlayerInput playerInput = JsonConvert.DeserializeObject<PlayerInput>(playerInputJSON);
            Player player = GameState.TryFindPlayer(playerID);
            player.UpdatePosition(playerInput);
            //GameState.Players[playerID].UpdatePosition(playerInput); <============
            //await Clients.Client(Context.ConnectionId).SendAsync("UpdatePlayerPositionResponse", playerID + " position updated"); // response was only used for debugging
        }

        public async Task GameStateRequest()
        {
            GameState gsCopy = GameState.Copy();
            string gameStateJSON = JsonConvert.SerializeObject(gsCopy);
            await Clients.Client(Context.ConnectionId).SendAsync("GameStateResponse", gameStateJSON);
        }

        public async Task JoinTeamRequest(int teamIndex, string color, string oldPlayerID)
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

            Player newPlayer = new Player($"Team{teamIndex}Player{GameState.Teams.ElementAt(teamIndex).Players.Count + 1}", 0, 0);
            GameState.Teams[teamIndex].Players.Add(newPlayerID, newPlayer);

            GameState.Teams[teamIndex].Color = color;

            await Clients.Client(Context.ConnectionId).SendAsync("JoinTeamResponse", newPlayerID, color);
            await Clients.All.SendAsync("ReceivePlayerCount", teamIndex, 1); // update teamCounter for all clients (adds one)
        }
        public async Task PlayerCountRequest()
        {
            if (GameState.Teams.Count == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    GameState.Teams.Add(new Team(new Dictionary<string, Player>(), "Gray"));
                }
            }

            await Clients.Client(Context.ConnectionId).SendAsync("PlayerCountResponse", GameState.Teams[0].Players.Count(), GameState.Teams[1].Players.Count());
        }

        //public async Task SendMessage(string user, string message)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", user, message);
        //}
    }
}
