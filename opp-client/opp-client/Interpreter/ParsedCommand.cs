using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_client.Interpreter
{
    public class ParsedCommand
    {
        public string Name { get; set; }
        public List<string> Arguments { get; set; }

        public ParsedCommand(string name, List<string> arguments)
        {
            Name = name;
            Arguments = arguments;
        }
    }
}
