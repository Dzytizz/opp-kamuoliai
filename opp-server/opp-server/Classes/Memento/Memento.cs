using opp_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opp_server.Classes.Memento
{
    public class Memento
    {
        GameState state;

        public Memento(GameState state)
        {
            this.state = state.Copy();
        }
        public GameState State
        {
            get { return state; }
        }
    }
}
