using opp_client.Prototype;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_client.Visitor
{
    public class UpDownVisitor : IVisitor
    {
        public void Visit(Element animatedElement)
        {
            AnimatedFan fan = animatedElement as AnimatedFan;

            Point location = fan.PictureBox.Location;
            location.Y += 1 * fan.Direction;
            fan.PictureBox.Location = location;
        }
    }
}
