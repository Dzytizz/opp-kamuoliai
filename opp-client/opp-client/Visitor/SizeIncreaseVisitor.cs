using opp_client.Prototype;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_client.Visitor
{
    public class SizeIncreaseVisitor : IVisitor
    {
        public void Visit(Element animatedElement)
        {
            AnimatedFan fan = animatedElement as AnimatedFan;

            Size size = fan.PictureBox.Size;
            size.Width += 1 * fan.Direction;
            size.Height = size.Width;
            fan.PictureBox.Size = size;
        }
    }
}
