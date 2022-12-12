using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opp_server.Classes.Mediator
{
    public class ChatRoom : AbstractChatRoom
    {
        private Dictionary<string, ChatRoomMember> participants = new Dictionary<string, ChatRoomMember>();
        public override void Register(ChatRoomMember participant)
        {
            if (!participants.ContainsValue(participant))
            {
                participants[participant.Name] = participant;
            }
            participant.Chatroom = this;
        }
        public override void Send(string from, string to, string message)
        {
            ChatRoomMember participant = participants[to];
            if (participant != null)
            {
                participant.Receive(from, message);
            }
        }
    }
}
