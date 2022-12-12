using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Iterator
{
    public class TeamList : IteratorAggregate
    {
        private List<Team> _collection = new List<Team>();

        public void Add(Team team)
        {
            _collection.Add(team);
        }

        public void Remove(Team team)
        {
            _collection.Remove(team);
        }

        public Team this[int index]
        {
            get => _collection[index];
        }

        public int Count
        {
            get => _collection.Count;
        }
        
        public override IEnumerator GetEnumerator()
        {
            return new ListIterator(this);
        }
    }
}
