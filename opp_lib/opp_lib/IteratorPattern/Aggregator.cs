using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.IteratorPattern
{
    public interface Aggregator// : IEnumerable
    {
        //public abstract IEnumerator GetEnumerator();
        Iterator CreateIterator();
    } 
}
