using opp_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opp_server.Classes.Observer
{
    public class Server : Subject
    {
        public override void Receive()
        {
            Send();
        }

        public override void Send()
        {
            foreach (Client client in ClientsList)
            {
                client.Update();
            }
        }
    }
}
