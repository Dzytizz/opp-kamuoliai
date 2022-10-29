using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_client.Facade
{
    public class PlayerPositionUpdateSubsystem
    {
        public async void UpdatePlayerPositionRequest(HubConnection connection, string playerID, string playerInputJSON)
        {
            await connection.InvokeAsync("UpdatePlayerPositionRequest", playerID, playerInputJSON);
        }
    }
}
