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
            Fan fan = animatedElement as Fan;

            fan.YPosition += 2 * animatedElement.Direction;
        }
    }
}
