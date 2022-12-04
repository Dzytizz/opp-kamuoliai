using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_client.Interpreter
{
    public class CommandInterpreter : IInterpreter
    {
        public void Interpret(Command command)
        {
            string[] subStrings = command.FullCommand.Split(' ');
            string name = subStrings[0].Remove(0, 1);
            List<string> arguments = new List<string>();
            for(int i = 1; i < subStrings.Length; i++)
            {
                arguments.Add(subStrings[i]);
            }
            ParsedCommand parsedCommand = new ParsedCommand(name, arguments);
            command.ParsedCommand = parsedCommand;
        }
    }
}
