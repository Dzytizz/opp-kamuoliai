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
                await Task.Delay(5000);
                return 0;
            });
            t.Wait();
            if (GameState.Teams[0].Goals == 3 || GameState.Teams[1].Goals == 3) GameState.ChangeState(new WinnerState(GameState));
            else GameState.ChangeState(new PlayingState(GameState));
        }
    }
}
