using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opp_server.Classes.Mediator
{
    public class ChatRoomMember
    {
        ChatRoom chatroom;
        public IClientProxy clientProxy;
        string name;
        // Constructor
        public ChatRoomMember(string name, IClientProxy clientProxy)
        {
            this.name = name;
            this.clientProxy = clientProxy;
        }
        // Gets participant name
        public string Name
        {
            get { return name; }
        }
        // Gets chatroom
        public ChatRoom Chatroom
        {
            set { chatroom = value; }
            get { return chatroom; }
        }
        // Sends message to given participant
        public void Send(string to, string message)
        {
            chatroom.Send(name, to, message);
        }
        // Receives message from given participant
        public virtual void Receive(
            string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'",
                from, Name, message);
        }
    }
}
