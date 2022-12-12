using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opp_lib.Iterator
{
    public class ListIterator : Iterator<Team>
    {
        private TeamList _collection;
        private int _position = -1;

        public ListIterator(TeamList collection)
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
