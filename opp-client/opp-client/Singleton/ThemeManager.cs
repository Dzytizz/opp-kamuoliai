using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace opp_client.Singleton
{
    public class ThemeManager
    {
        private static ThemeManager Instance = new ThemeManager();
        public Color AccentColor { get; set; } 
        public Color BackgroundDark { get; set; }
        public Color BackgroundMid { get; set; }
        public Color BackgroundLight { get; set; }
        public Font TextFont { get; set; }

        public ThemeManager()
        {
            AccentColor = ColorTranslator.FromHtml("#3BBA9C");
            BackgroundDark = ColorTranslator.FromHtml("#2E3047");
            BackgroundMid = ColorTranslator.FromHtml("#43455C");
            BackgroundLight = ColorTranslator.FromHtml("#707793");
            TextFont = new Font("Segoe UI", 8);
        }

        public static ThemeManager GetInstance()
        {
            return Instance;
        }

        public void UpdateColor(Control control)
        {
            if (control is Label)
            {
                control.BackColor = BackgroundMid;
                control.ForeColor = AccentColor;
            }

            if (control is ListBox)
            {
                control.BackColor = BackgroundLight;
                control.ForeColor = BackgroundMid;
            }

            if(control is ComboBox)
            {
                control.BackColor = BackgroundLight;
                control.ForeColor = BackgroundMid;
            }

            if(control is Button)
            {
                control.BackColor = BackgroundMid;
                control.ForeColor = AccentColor;
            }

            foreach (Control subControl in control.Controls)
            {
                UpdateColor(subControl);
            }
        }

        public void SetThemeValues(Color accentColor, Color backgroundDark, Color backgroundMid, Color backgroundLight, Font textFont)
        {
            AccentColor = accentColor;
            BackgroundDark = backgroundDark;
            BackgroundMid = backgroundMid;
            BackgroundLight = backgroundLight;
            TextFont = textFont;
        }
    }
}
