using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opp_server.Classes.Mediator
{
    public class SingleChatRoomMember : ChatRoomMember
    {
        public SingleChatRoomMember(string name, IClientProxy clientProxy) : base(name, clientProxy)
        {

        }
        public override void Receive(string from, string message)
        {
            string formattedMessage = String.Format("{0}: {1}", from, message);
            clientProxy.SendAsync("SendMessageToResponse", formattedMessage);
            base.Receive(from, message);
        }
    }
}
