using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_client.Proxy
{
    public class MessengerProxy : IMessenger
    {
        protected Messenger messenger;
        protected string PlayerID { get; set; }
        public MessengerProxy(string playerID)
        {
            this.PlayerID = playerID;
            
        }
        public void HandleMessageAsync(string message, HubConnection connection)
        {
            if(message[0] == '/')
            {
                messenger = new CommandMessenger(this.PlayerID);
            }
            else
            {
                messenger = new MessageMessenger(this.PlayerID);

            }
                messenger.HandleMessageAsync(message, connection);
        }
    }
}
