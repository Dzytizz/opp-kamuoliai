using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Iterator
{
    public abstract class Iterator : IEnumerator
    {
        public abstract bool MoveNext();
        public abstract void Reset();
        public object Current { get; }
    }
}
