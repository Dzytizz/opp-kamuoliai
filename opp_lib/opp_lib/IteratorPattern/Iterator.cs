using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.IteratorPattern
{
    public interface Iterator //: IEnumerator
    {
        object Current { get; }
        bool Next();
       //bool IsCompleted { get; }

    }
}
