using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opp_client.Facade
{
    public class ThemeClient
    {
        private Facade Facade;
        public ThemeClient()
        {
            Facade = new Facade();
        }

        public void ApplyTheme(Form form)
        {
            Facade.ApplyTheme(form);
        }
    }
}
