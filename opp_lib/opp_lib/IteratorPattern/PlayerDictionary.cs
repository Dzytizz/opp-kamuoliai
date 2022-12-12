using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.IteratorPattern
{
  
 public class PlayerDictionary : Aggregator
    {
        private Dictionary<string, Player> dictionary = new Dictionary<string, Player>();

        public void Add(string key, Player player)
        {
            dictionary.Add(key, player);
        }

        public void Remove(string key)
        {
            dictionary.Remove(key);
        }
        public KeyValuePair<string,Player> ElementAt(int index)
        {
            return dictionary.ElementAt(index);
        }
        public bool TryGetValue(string key, out Player player)
        {
            return dictionary.TryGetValue(key, out player);
        }
        public bool ContainsKey(string key)
        {
            return dictionary.ContainsKey(key);
        }
        
        public Dictionary<string, Player> Get()
        {
            return dictionary;
        }
        public object this[string key]
        {
            get { return dictionary[key]; }
        }
        public int Count
        {
            get { return dictionary.Count; }
        }
        public Iterator CreateIterator()
        {
            return new DictionaryIterator(this);
        }
        //public ListIterator<Player> GetIterator()
        //{
        //    return list.iterator();
        //}

    }
}
