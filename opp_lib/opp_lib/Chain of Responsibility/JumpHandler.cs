using opp_lib.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Chain_of_Responsibility
{
    public class JumpHandler : MovementHandler
    {
        public JumpHandler(Player player) : base(player)
        {
        }

        public override void HandleMovementType(PlayerInput playerInput)
        {
            if (playerInput.ToJump)
            {
                List<float> positions = Player.GetInvoker()
                    .DoJump(playerInput, Player.Speed, Player.XPosition, Player.YPosition);
                Player.SetPositions(positions);
            } 
            if (Successor != null)
            {
                Successor.HandleMovementType(playerInput);
            }
        }
    }
}
