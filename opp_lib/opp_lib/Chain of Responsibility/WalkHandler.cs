using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using opp_lib.Strategy;

namespace opp_lib.Chain_of_Responsibility
{
    public class WalkHandler : MovementHandler
    {
        public WalkHandler(Player player) : base(player)
        {
        }

        public override void HandleMovementType(PlayerInput playerInput)
        {
            if (playerInput.ToWalk)
            {
                Player.SetMovementMode(new Walk());
                Player.Move(playerInput);
            }
            if (Successor != null)
            {
                Successor.HandleMovementType(playerInput);
            }
        }
    }
}
