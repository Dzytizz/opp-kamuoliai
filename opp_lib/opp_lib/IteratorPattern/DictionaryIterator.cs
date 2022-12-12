using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.IteratorPattern
{

    public class DictionaryIterator : Iterator
    {
        private PlayerDictionary aggregate;
        int index;

        public DictionaryIterator(PlayerDictionary aggregate)
        {
            this.aggregate = aggregate;
            index = -1;
        }

        public bool Next()
        {
            index++;
            return index < aggregate.Count;
        }

        public object Current
        {
            get
            {
                if (index < aggregate.Count)
                    return aggregate.ElementAt(index);
                else
                    throw new InvalidOperationException();
            }
        }
    }
}
