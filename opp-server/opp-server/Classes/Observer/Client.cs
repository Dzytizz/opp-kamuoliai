using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using opp_lib;
using opp_server.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opp_server.Classes.Observer
{
    public class Client : Observer
    {
        public string ConnectionId;
        public HubCallerContext HubContext;
        public Client(string connectionId, HubCallerContext context)
        {
            this.ConnectionId = connectionId;
            //this.HubContext = GlobalHost.ConnectionManager.GetHubContext<GameHub>();
            this.HubContext = context;
        }

        public override async void Update()
        {
            GameState gsCopy = GameState.GetInstance().Copy();
            string gameStateJSON = JsonConvert.SerializeObject(gsCopy);
        }
    }
}
