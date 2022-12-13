using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Iterator
{
    public class PlayerDictionary : IteratorAggregate<KeyValuePair<string,Player>>
    {
        private Dictionary<string,Player> _collection = new Dictionary<string, Player>();

        public override IEnumerator<KeyValuePair<string, Player>> GetEnumerator()
        {
            return new DictionaryIterator(this);
        }

        public void Add(string key, Player player)
        {
            _collection.Add(key, player);
        }

        public bool TryGetValue(string id, out Player player)
        {
            return _collection.TryGetValue(id, out player);
        }

        public bool ContainsKey(string key)
        {
            return _collection.ContainsKey(key);
        }

        public override void Add(KeyValuePair<string, Player> item)
        {
            _collection.Add(item.Key, item.Value);
        }

        public override void Clear()
        {
            _collection.Clear();
        }

        public override bool Contains(KeyValuePair<string, Player> item)
        {
            return _collection.Contains(item);
        }

        public override void CopyTo(KeyValuePair<string, Player>[] array, int arrayIndex)
        {
            if (array != null && array.Rank != 1)
                throw new ArgumentException("Only single dimensional arrays are supported for the requested action.", "array");

            // 1. call the generic version
            KeyValuePair<string, Player>[] typedArray = array as KeyValuePair<string, Player>[];
            if (typedArray != null)
            {
                CopyTo(typedArray, arrayIndex);
                return;
            }

            // 2. object[]
            //object[] objectArray = array as object[];
            //if (objectArray != null)
            //{
            //    for (int i = 0; i < _collection.Count; i++)
            //    {
            //        objectArray[arrayIndex++] = _collection[i];
            //    }
            //}

            throw new ArgumentException("Target array type is not compatible with the type of items in the collection.");
        }

        public override bool Remove(KeyValuePair<string, Player> item)
        {
            return _collection.Remove(item.Key);
        }

        public bool Remove(string key)
        {
            return _collection.Remove(key);
        }

        public KeyValuePair<string, Player> Get(int index)
        {
            return _collection.ElementAt(index);
        }

        public KeyValuePair<string, Player> this[int index]
        {
            get => Get(index);
        }


        public override int Count
        {
            get => _collection.Count;
        }
        public override bool IsReadOnly { get; }
    }
}
