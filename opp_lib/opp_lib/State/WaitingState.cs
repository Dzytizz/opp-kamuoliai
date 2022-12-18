using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.State
{
    public class WaitingState : AbstractState
    {
        public WaitingState(GameState gameState) : base(gameState) { }

        public override string GetStateStatus()
        {
            return "Waiting for players to choose level and start";
        }

        public override void StateStartAction()
        {
            GameState.ResetScore();
        }
    }
}
