using Microsoft.VisualStudio.TestTools.UnitTesting;
using opp_client.Singleton;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opp_client.Singleton.Tests
{
    [TestClass()]
    public class ThemeManagerTests
    {
        [TestMethod()]
        public void GetInstance_CheckIfSameInstanceIsReturned_InstancesAreSame()
        {
            ThemeManager instance1 = ThemeManager.GetInstance();
            ThemeManager instance2 = ThemeManager.GetInstance();
            Assert.AreSame(instance1, instance2);
        }

        [TestMethod()]
        public void GetInstance_ChangedValuesPassToOtherInstances_ReturnedInstanceHasNewValues()
        {
            ThemeManager instance1 = ThemeManager.GetInstance();
            Color newColor = ColorTranslator.FromHtml("#111111");
            instance1.AccentColor = newColor;
            ThemeManager instance2 = ThemeManager.GetInstance();
            Assert.AreEqual(instance2.AccentColor, newColor);
        }

        [TestMethod()]
        public void UpdateColor_CreatesAndUpdatesControlsColors_ControlsColorsAreUpdated()
        {
            Control newControl = new Control();
            newControl.Controls.Add(new Label());
            newControl.Controls.Add(new ListBox());
            newControl.Controls.Add(new ComboBox());
            newControl.Controls.Add(new Button());
            ThemeManager instance = ThemeManager.GetInstance();
            instance.UpdateColor(newControl);
            Assert.AreEqual(newControl.Controls[0].BackColor, instance.BackgroundMid);
            Assert.AreEqual(newControl.Controls[1].BackColor, instance.BackgroundLight);
            Assert.AreEqual(newControl.Controls[2].BackColor, instance.BackgroundLight);
            Assert.AreEqual(newControl.Controls[3].BackColor, instance.BackgroundMid);
        }

        [TestMethod()]
        public void SetThemeValues_SetsColorsAndFontProperties_ColorsAndFontPropertiesAreSet()
        {
            ThemeManager instance1 = ThemeManager.GetInstance();
            Font newFont = new Font("Comic Sans", 8);
            instance1.SetThemeValues(
                ColorTranslator.FromHtml("#111111"),
                ColorTranslator.FromHtml("#222222"),
                ColorTranslator.FromHtml("#333333"),
                ColorTranslator.FromHtml("#444444"),
                newFont);
            Assert.AreEqual(instance1.AccentColor, ColorTranslator.FromHtml("#111111"));
            Assert.AreEqual(instance1.BackgroundDark, ColorTranslator.FromHtml("#222222"));
            Assert.AreEqual(instance1.BackgroundMid, ColorTranslator.FromHtml("#333333"));
            Assert.AreEqual(instance1.BackgroundLight, ColorTranslator.FromHtml("#444444"));
            Assert.AreEqual(instance1.TextFont, newFont);
        }
    }
}