using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Iterator
{
    public abstract class IteratorAggregate<T> : ICollection<T>
    {

        public abstract void Add(T item);
        public abstract void Clear();
        public abstract bool Contains(T item);
        public abstract void CopyTo(T[] array, int arrayIndex);
        public abstract bool Remove(T item);
        public abstract int Count { get; }
        public abstract bool IsReadOnly { get; }
        public abstract IEnumerator<T> GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
