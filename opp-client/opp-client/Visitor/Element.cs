using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_client.Visitor
{
    public abstract class Element
    {
        public int Direction { get; set; } = 1;
        public float Timer { get; set; } = 0f;
        public float Step { get; set; } = 0.2f;
        public float MaxValue { get; set; } = 3f;

        public virtual void Animate(IVisitor visitor)
        {
            Timer += Step * Direction;

            if (Timer < 0 || Timer > MaxValue)
            {
                Direction *= -1;
            }
        }
    }
}
