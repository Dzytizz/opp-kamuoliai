using opp_client.Prototype;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opp_client.Visitor
{
    public class ColorChangeVisitor : IVisitor
    {
        public void Visit(Element animatedElement)
        {
            Fan fan = animatedElement as Fan;

            if (animatedElement.Direction > 0)
            {
                fan.IsLighter = 1;
            }
            else
            {
                fan.IsLighter = -1;
            }
        }
    }
}
