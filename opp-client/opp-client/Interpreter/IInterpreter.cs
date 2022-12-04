using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_client.Interpreter
{
    interface IInterpreter
    {
        void Interpret(Command command);
    }
}
