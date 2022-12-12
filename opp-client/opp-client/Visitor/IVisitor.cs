using opp_client.Prototype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_client.Visitor
{
    public interface IVisitor
    {
        void Visit(Element fanElement);
    }
}
