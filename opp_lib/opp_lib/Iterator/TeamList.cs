using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Iterator
{
    public class TeamList : IteratorAggregate<Team>
    {
        private List<Team> _collection = new List<Team>();

        public override void Add(Team team)
        {
            _collection.Add(team);
        }

        public override void Clear()
        {
            _collection.Clear();
        }

        public override bool Contains(Team item)
        {
            return _collection.Contains(item);
        }

        public override void CopyTo(Team[] array, int arrayIndex)
        {
            if (array != null && array.Rank != 1)
                throw new ArgumentException("Only single dimensional arrays are supported for the requested action.", "array");

            // 1. call the generic version
            Team[] typedArray = array as Team[];
            if (typedArray != null)
            {
                CopyTo(typedArray, arrayIndex);
                return;
            }

            // 2. object[]
            object[] objectArray = array as object[];
            if (objectArray != null)
            {
                for (int i = 0; i < _collection.Count; i++)
                {
                    objectArray[arrayIndex++] = _collection[i];
                }
            }

            throw new ArgumentException("Target array type is not compatible with the type of items in the collection.");
        }

        public override bool Remove(Team team)
        {
            return _collection.Remove(team);
        }

        public Team Get(int index)
        {
            return _collection[index];
        }

        public Team this[int index]
        {
            get => Get(index);
        }

        public override int Count
        {
            get => _collection.Count;
        }

        public override bool IsReadOnly { get; }

        public override IEnumerator<Team> GetEnumerator()
        {
            return new ListIterator(this);
        }
    }
}
