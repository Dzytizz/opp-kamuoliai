using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.AdapterMath
{
    public interface ITarget
    {
        float Calculate(float number, char function);
    }
}
