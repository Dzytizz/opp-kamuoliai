using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opp_server.Classes.Mediator
{
    public abstract class AbstractChatRoom
    {
        public abstract void Register(ChatRoomMember member);
        public abstract void Send(string from, string to, string message);
    }
}
