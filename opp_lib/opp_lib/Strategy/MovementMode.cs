using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Strategy
{
    public abstract class MovementMode
    {
        public abstract List<float> MoveDifferently(PlayerInput playerInput, float speed, float xPosition, float yPosition);
    }
}
