using Microsoft.AspNetCore.SignalR.Client;
using opp_client.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_client.Proxy
{
    public class MessageMessenger : Messenger
    {
        string PlayerID { get; set; }
        public MessageMessenger(string playerID)
        {
            this.PlayerID = playerID; 
        }
        public override async void HandleMessageAsync(string message, HubConnection connection)
        {
            await connection.InvokeAsync("SendMessageToAllRequest", PlayerID, message);
        }
    }
}
