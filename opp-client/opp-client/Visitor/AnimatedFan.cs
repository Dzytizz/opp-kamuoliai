using opp_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_client.Visitor
{
    public class AnimatedFan : Element
    {
        public OvalPictureBox PictureBox { get; set; }

        public float Timer { get; set; }
        public int Direction { get; set; }
        public float Step { get; set; }
        public float MaxValue { get; set; }

        public AnimatedFan(OvalPictureBox pictureBox, int direction, float step, float maxValue)
        {
            PictureBox = pictureBox;
            //Timer = (float)(rng.NextDouble() * MaxValue);
            Timer = 0f;
            Direction = direction;
            Step = step;
            MaxValue = maxValue;
        }

        public override void Animate(IVisitor visitor)
        {
            Timer += Step * Direction;
            if(Timer < 0 || Timer > MaxValue)
            {
                Direction *= -1;
            }

            visitor.Visit(this);
        }
    }
}
