using Microsoft.AspNetCore.SignalR.Client;
using opp_client.Facade;
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
    public partial class TeamSelect : Form
    {
        public HubConnection connection;
        public static string playerID;

        private ThemeClient themeClient = new ThemeClient();

        public TeamSelect(HubConnection connection)
        {
            InitializeComponent();
            this.connection = connection;

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            playerID = "";
        }

        private async void TeamSelect_Load(object sender, EventArgs e)
        {
            themeClient.ApplyTheme(this);

            connection.On<string, string>("JoinTeamResponse", (newPlayerID, teamColor) =>
            {
                if (!this.Visible) return;
                playerID = newPlayerID;
                listBox.Items.Add($"Player with ID {newPlayerID} added to a {teamColor} team");
            });

            // This response happens when a player joins/leaves a team
            connection.On<int, int>("ReceivePlayerCount", (teamIndex, count) =>
            {
                if (!this.Visible) return;
                int current = -1;
                switch (teamIndex)
                {
                    case 0:
                        current = Int32.Parse(teamACounter.Text);
                        teamACounter.Text = (current + count).ToString();
                        break;
                    case 1:
                        current = Int32.Parse(teamBCounter.Text);
                        teamBCounter.Text = (current + count).ToString();
                        break;
                }
   
            });

            // This response happens when a new client is launched (to update its team counters)
            connection.On<int, int>("PlayerCountResponse", (teamACount, teamBCount) =>
            {
                if (!this.Visible) return;
                teamACounter.Text = teamACount.ToString();
                teamBCounter.Text = teamBCount.ToString();
            });

            connection.On<string, string>("TeamColorsResponse", (team1Color, team2Color) =>
            {
                if (!this.Visible) return;
                label1.Text = $"{team1Color} Team Player Count";
                label2.Text = $"{team2Color} Team Player Count";
            });

            try
            {
                await connection.InvokeAsync("TeamColorsRequest");
                await connection.InvokeAsync("PlayerCountRequest");
            }
            catch (Exception ex)
            {
                listBox.Items.Add(ex.Message);
            }

            comboBox1.SelectedIndex = 0;
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            if (!playerID.Equals(""))
            {
                ClientWindow cw = new ClientWindow(connection, playerID);
                cw.Show();
                this.Hide();
            }
            else
            {
                listBox.Items.Add("No team selected");
            }
        }

        // join a
        private async void JoinTeamAButton_Click(object sender, EventArgs e)
        {
            try
            {
                string playerName = textBox1.Text;
                int playerNumber = int.Parse(textBox2.Text);
                string playerUniform = comboBox1.SelectedItem.ToString();
                if (string.IsNullOrWhiteSpace(playerName) || string.IsNullOrWhiteSpace(playerUniform))
                {
                    return;
                }
                await connection.InvokeAsync("JoinTeamRequest", 0, playerID, playerName, playerUniform, playerNumber);
            }
            catch (Exception ex)
            {
                listBox.Items.Add(ex.Message);

            }
        }

        // join b
        private async void JoinTeamBButton_Click(object sender, EventArgs e)
        {
            try
            {
                string playerName = textBox1.Text;
                int playerNumber = int.Parse(textBox2.Text);
                string playerUniform = comboBox1.SelectedItem.ToString();
                if (string.IsNullOrWhiteSpace(playerName) || string.IsNullOrWhiteSpace(playerUniform))
                {
                    return;
                }
                await connection.InvokeAsync("JoinTeamRequest", 1, playerID, playerName, playerUniform, playerNumber);
            }
            catch (Exception ex)
            {
                listBox.Items.Add(ex.Message);
            }
        }

        private void TeamSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
