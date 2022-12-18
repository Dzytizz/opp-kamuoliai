using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.State
{
    public class WinnerState : AbstractState
    {
        public WinnerState(GameState gameState) : base(gameState) { }

        public override string GetStateStatus()
        {
            string winnerColor;
            if(GameState.Teams[0].Goals > GameState.Teams[1].Goals)
            {
                winnerColor = GameState.Teams[0].Color;
            }
            else winnerColor = GameState.Teams[1].Color;
            return String.Format("{0} team won", winnerColor);
        }

        public override void StateStartAction()
        {
            var t = Task.Run(async delegate
            {
                await Task.Delay(10000);
                return 0;
            });
            t.Wait();
            GameState.ChangeState(new WaitingState(GameState));
        }
    }
}
