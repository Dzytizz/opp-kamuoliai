using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.State
{
    public class GoalState : AbstractState
    {
        public GoalState(GameState gameState) : base(gameState)
        {
        }

        public override string GetStateStatus()
        {
            return "GOAL";
        }

        public override void StateStartAction()
        {
            var t = Task.Run(async delegate
            {
                await Task.Delay(3000);
                return 0;
            });
            t.Wait();
            GameState.ChangeState(new PlayingState(GameState));
        }
    }
}
