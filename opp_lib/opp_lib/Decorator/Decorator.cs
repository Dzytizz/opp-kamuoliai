using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opp_lib.Decorator
{
    public abstract class Decorator : IDecorator
    {
        public IDecorator Component;
        public Decorator(IDecorator component)
        {
            Component = component;
        }

        public abstract OvalPictureBox Display(string teamColor);
    }
}
