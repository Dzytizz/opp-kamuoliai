using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Chain_of_Responsibility
{
    public abstract class MovementHandler
    {
        protected MovementHandler Successor;
        protected Player Player;

        public MovementHandler(Player player)
        {
            this.Player = player;
            this.Successor = null;
        }

        public MovementHandler SetSuccessor(MovementHandler successor)
        {
            this.Successor = successor;
            return this;
        }

        public abstract void HandleMovementType(PlayerInput playerInput);
    }
}
