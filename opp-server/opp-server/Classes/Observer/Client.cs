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
        public IClientProxy ClientProxy;
        public Ball Ball { get; set; }
        public Client(IClientProxy client)
        {
            this.ClientProxy = client;
        }
        public override async void Update()
        {
            GameState gsCopy = GameState.GetInstance().Copy();
            string gameStateJSON = JsonConvert.SerializeObject(gsCopy);
            await ClientProxy.SendAsync("GameStateResponse", gameStateJSON);
            Ball ballCopy = (Ball)Ball.Clone();
            string ballJSON = JsonConvert.SerializeObject(ballCopy);
            await ClientProxy.SendAsync("BallResponse", ballJSON);
        }
    }
}
