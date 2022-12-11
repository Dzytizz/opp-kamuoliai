using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_client.Visitor
{
    public abstract class Element
    {
        public abstract void Animate(IVisitor visitor);
    }
}
