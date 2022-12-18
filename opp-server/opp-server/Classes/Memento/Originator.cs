using opp_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opp_server.Classes.Memento
{
    public class Originator
    {
        GameState state;
        public GameState State
        {
            get { return state; }
            set
            {
                state = value;
            }
        }

        public Memento CreateMemento()
        {
            return (new Memento(state));
        }
       
        public void SetMemento(Memento memento)
        {
            State = memento.State.Copy();
        }

    }
}
