using opp_client.Prototype;
using opp_lib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_client.Visitor
{
    public class Fans
    {
        private List<AnimatedFan> fans = new List<AnimatedFan>();


        public void Attach(AnimatedFan fan)
        {
            fans.Add(fan);
        }

        public void Detach(AnimatedFan fan)
        {
            fans.Remove(fan);
        }

        public void Animate(IVisitor visitor)
        {
            foreach(var animatedFan in fans)
            {
                animatedFan.Animate(visitor);
            }
        }
    }
}
