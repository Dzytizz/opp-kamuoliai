using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Iterator
{
    public class DictionaryIterator : Iterator<KeyValuePair<string, Player>>

    {
        private PlayerDictionary _collection;
        private int _position = -1;

        public DictionaryIterator(PlayerDictionary collection)
        {
            this._collection = collection;
        }

        public override bool MoveNext()
        {
            int updatedPosition = this._position + 1;

            if (updatedPosition >= 0 && updatedPosition < _collection.Count)
            {
                this._position = updatedPosition;
                Current = this._collection[updatedPosition];
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Reset()
        {
            this._position = 0;
        }
    }
}
