using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opp_lib.Decorator
{
    public interface IDecorator
    {
        OvalPictureBox Display(string teamColor);
    }
}
