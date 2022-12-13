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
            throw new NotImplementedException();
        }

        public override bool Contains(Team item)
        {
            throw new NotImplementedException();
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

        public Team this[int index]
        {
            get => _collection[index];
        }

        //public override void CopyTo(Array array, int index)
        //{
        //    if (array != null && array.Rank != 1)
        //        throw new ArgumentException("Only single dimensional arrays are supported for the requested action.", "array");

        //    // 1. call the generic version
        //    Team[] typedArray = array as Team[];
        //    if (typedArray != null)
        //    {
        //        CopyTo(typedArray, index);
        //        return;
        //    }

        //    // 2. object[]
        //    object[] objectArray = array as object[];
        //    if (objectArray != null)
        //    {
        //        for (int i = 0; i < _collection.Count; i++)
        //        {
        //            objectArray[index++] = _collection[i];
        //        }
        //    }

        //    throw new ArgumentException("Target array type is not compatible with the type of items in the collection.");
        //}

        public override int Count
        {
            get => _collection.Count;
        }

        public override bool IsReadOnly { get; }

        public override IEnumerator GetEnumerator()
        {
            return new ListIterator(this);
        }
    }
}
