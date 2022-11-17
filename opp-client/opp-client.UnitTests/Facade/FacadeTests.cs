using Microsoft.VisualStudio.TestTools.UnitTesting;
using opp_client.Facade;
using opp_client.Singleton;
using opp_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client.Hubs;
using SignalR_UnitTestingSupportMSTest.Hubs;

namespace opp_client.Facade.Tests
{
    [TestClass()]
    public class FacadeTests
    {
        private ThemeClient themeClient;
        private PlayerClient playerClient;

        [TestInitialize]
        public void CreateClients()
        {
            themeClient = new ThemeClient();
            playerClient = new PlayerClient();
        }

        [TestMethod()]
        public void ApplyTheme_CreatesFormAndSetsThemeViaApplyTheme_ThemeVariablesSetProperly()
        {
            Form form = new Form();
            form.Controls.Add(new Label());
            form.Controls.Add(new ListBox());
            form.Controls.Add(new ComboBox());
            form.Controls.Add(new Button());

            themeClient.ApplyTheme(form);

            ThemeManager instance = ThemeManager.GetInstance();
            Assert.AreEqual(form.Controls[0].BackColor, instance.BackgroundMid);
            Assert.AreEqual(form.Controls[1].BackColor, instance.BackgroundLight);
            Assert.AreEqual(form.Controls[2].BackColor, instance.BackgroundLight);
            Assert.AreEqual(form.Controls[3].BackColor, instance.BackgroundMid);
        }
    }
}