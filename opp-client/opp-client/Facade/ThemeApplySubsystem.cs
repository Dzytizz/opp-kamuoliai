using opp_client.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opp_client.Facade
{
    public class ThemeApplySubsystem
    {
        public void SetWindowTheme(Form form)
        {
            form.BackColor = ThemeManager.GetInstance().BackgroundDark;
            form.Font = ThemeManager.GetInstance().TextFont;
        }

        public void UpdateSubControlColors(Form form)
        {
            foreach (Control control in form.Controls)
            {
                ThemeManager.GetInstance().UpdateColor(control);
            }
        }
    }
}
