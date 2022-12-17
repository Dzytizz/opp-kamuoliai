using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.State
{
    public abstract class AbstractState
    {
        protected GameState GameState;

        public AbstractState(GameState gameState)
        {
            GameState = gameState;
        }

        public abstract string GetStateStatus();
        public abstract void StateStartAction();
    }
}
