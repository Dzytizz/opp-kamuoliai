using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Iterator
{
    public abstract class Iterator<T> : IEnumerator<T>
    {
        public abstract bool MoveNext();
        public abstract void Reset();
        object IEnumerator.Current => Current;

        public T Current { get; set; }
        public void Dispose()
        {
            
        }
    }
}
