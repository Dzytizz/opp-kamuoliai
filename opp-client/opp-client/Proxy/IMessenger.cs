using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_client.Proxy
{
    public interface IMessenger
    {
        void HandleMessageAsync(string message, HubConnection connection);
    }
}
