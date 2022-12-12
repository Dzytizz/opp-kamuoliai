using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.IteratorPattern
{
    public class TeamList : Aggregator
    {
        private List<Team> list = new List<Team>();

        public void Add(Team team)
        {
            list.Add(team);
        }

        public void Remove(Team team)
        {
            list.Remove(team);
        }

        public List<Team> Get()
        {
            return list;
        }
        public object this[int index]
        {
            get { return list[index]; }
        }
        public int Count
        {
            get { return list.Count; }
        }
        public Iterator CreateIterator()
        {
            return new ListIterator(this);
        }
        //public ListIterator<Player> GetIterator()
        //{
        //    return list.iterator();
        //}

    }
    
}
