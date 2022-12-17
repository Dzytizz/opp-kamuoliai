using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.State
{
    public class PlayingState : AbstractState
    {
        public PlayingState(GameState gameState) : base(gameState) { }

        public override string GetStateStatus()
        {
            string team1Color = GameState.Teams[0].Color;
            int team1Goals = GameState.Teams[0].Goals;
            string team2Color = GameState.Teams[1].Color;
            int team2Goals = GameState.Teams[1].Goals;
            return String.Format("Team {0} {1}:{2} Team {3}", team1Color, team1Goals, team2Goals, team2Color);
        }

        public override void StateStartAction()
        {
            GameState.ResetPlayersAndBall();
        }
    }
}
