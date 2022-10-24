using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Command
{
    public abstract class Command
    {
        public abstract List<float> Execute();
        public abstract List<float> Undo();

    }
}
