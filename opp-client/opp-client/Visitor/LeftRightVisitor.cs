using opp_client.Prototype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_client.Visitor
{
    public class LeftRightVisitor : IVisitor
    {
        public void Visit(Element fanElement)
        {
            Fan fan = fanElement as Fan;
            fan.XPosition += 1 * fan.Direction;
        }
    }
}
