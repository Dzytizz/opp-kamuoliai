using opp_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opp_server.Classes.Observer
{
    public abstract class Subject
    {
        protected List<Client> ClientsList = new List<Client>();
        public abstract void Send();
        public abstract void Receive();
        public void Subscribe(Client param)
        {
            ClientsList.Add(param);
        }

        public void Unsubscribe(Client param)
        {
            int index = ClientsList.IndexOf(param);
            ClientsList.RemoveAt(index);
        }
    }
}
