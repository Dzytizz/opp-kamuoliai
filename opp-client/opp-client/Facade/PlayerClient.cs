using Microsoft.AspNetCore.SignalR.Client;
using opp_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.Control;

namespace opp_client.Facade
{
    public class PlayerClient
    {
        private Facade Facade;

        public PlayerClient()
        {
            Facade = new Facade();
        }

        public void ProcessMovement(ref PlayerInput playerInput, HubConnection connection, string playerID)
        {
            Facade.ProcessMovement(ref playerInput, connection, playerID); 
        }
    }
}
