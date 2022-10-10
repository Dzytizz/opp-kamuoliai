using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Strategy
{
    public abstract class Algorithm
    {
        public abstract List<float> BehaveDifferently(PlayerInput playerInput, float speed, float xPosition, float yPosition);
    }
}
