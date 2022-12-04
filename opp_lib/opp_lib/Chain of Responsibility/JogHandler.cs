using opp_lib.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Chain_of_Responsibility
{
    public class JogHandler : MovementHandler
    {
        public JogHandler(Player player) : base(player)
        {
        }

        public override void HandleMovementType(PlayerInput playerInput)
        {
            if (playerInput.IsActive())
            {
                Player.SetMovementMode(new Jog());
                Player.Move(playerInput);
            }
            else if (Successor != null)
            {
                Successor.HandleMovementType(playerInput);
            }
        }

       
    }
}
