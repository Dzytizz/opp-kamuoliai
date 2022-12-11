using opp_lib.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Chain_of_Responsibility
{
    public class RunHandler : MovementHandler
    {
        public RunHandler(Player player) : base(player)
        {
        }

        public override void HandleMovementType(PlayerInput playerInput)
        {
            if (playerInput.ToRun)
            {
                Player.SetMovementMode(new Run());
                Player.Move(playerInput);
            }
            if (Successor != null)
            {
                Successor.HandleMovementType(playerInput);
            }
        }
    }
}
