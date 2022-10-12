using Microsoft.AspNetCore.SignalR.Client;
using opp_client.Singleton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opp_client
{
    public partial class TeamCreation : Form
    {
        public HubConnection connection;

        public TeamCreation(HubConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
        }

        private void TeamCreation_Load(object sender, EventArgs e)
        {
            ThemeManager tm = ThemeManager.GetInstance();
            this.BackColor = tm.BackgroundDark;
            this.Font = tm.TextFont;
            foreach (Control control in this.Controls)
            {
                tm.UpdateColor(control);
            }

            connection.On("CreateTeamsResponse", () =>
            {
                if (!this.Visible) return;
                TeamSelect teamSelectWindow = new TeamSelect(connection);
                teamSelectWindow.Show();
                this.Hide();

            });
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckIndexes();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckIndexes();
        }

        private void CheckIndexes()
        {
            if (comboBox1.SelectedIndex == comboBox2.SelectedIndex)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string team1 = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                string team2 = comboBox2.Items[comboBox2.SelectedIndex].ToString();
                await connection.InvokeAsync("CreateTeamsRequest", team1, team2);
            }
            catch (Exception ex)
            {
                
            }
        }

        private void TeamCreation_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
