using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.IteratorPattern
{
    public class ListIterator : Iterator
    {
        private TeamList aggregate;
        int index;

        public ListIterator(TeamList aggregate)
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
                    return aggregate[index];
                else
                    throw new InvalidOperationException();
            }
        }
        //private Team collection;
        //private int current = 0;
        //private int step = 1;
        //// Constructor
        //public ConcreteIterator(Team collection)
        //{
        //    this.collection = collection;
        //}
        //// Gets first item
        //public Player First()
        //{
        //    current = 0;
        //    return collection.Players(current);
        //}
        //// Gets next item
        //public Elempoyee Next()
        //{
        //    current += step;
        //    if (!IsCompleted)
        //    {
        //        return collection.GetEmployee(current);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        //// Check whether iteration is complete
        //public bool IsCompleted
        //{
        //    get { return current >= collection.Count; }
        //}
    }
}
