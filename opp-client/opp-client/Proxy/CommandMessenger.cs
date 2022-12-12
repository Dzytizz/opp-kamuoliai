using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using opp_client.Interpreter;

namespace opp_client.Proxy
{
    public class CommandMessenger : Messenger
    {
        string PlayerID { get; set; }

        public CommandMessenger(string playerID)
        {
            this.PlayerID = playerID;
        }
        public override async void HandleMessageAsync(string message, HubConnection connection)
        {
            Command c = new Command(message);
            CommandInterpreter interpreter = new CommandInterpreter();
            interpreter.Interpret(c);
            switch (c.ParsedCommand.Name)
            {
                case "changeLevel":
                    await connection.InvokeAsync("LevelChangeRequest", c.ParsedCommand.Arguments);
                    break;
                case "msg":
                    await connection.InvokeAsync("SendMessageToRequest", PlayerID, c.ParsedCommand.Arguments);
                    break;

            }
        }
    }
}
