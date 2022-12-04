using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_client.Proxy
{
    public abstract class Messenger : IMessenger
    {
        //public HubConnection connection { get; set; }
        public abstract void HandleMessageAsync(string message, HubConnection connection);
    }
}
