using Microsoft.AspNetCore.SignalR.Client;
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
        public static HubConnection connection;
        public static string playerID;

        public TeamSelect()
        {
            InitializeComponent();
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44330/gamehub")
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            playerID = "";
        }

        private async void TeamSelect_Load(object sender, EventArgs e)
        {
            connection.On<string, string>("JoinTeamResponse", (newPlayerID, teamColor) =>
            {
                playerID = newPlayerID;
                listBox.Items.Add($"Player with ID {newPlayerID} added to a {teamColor} team");
            });

            // This response happens when a player joins/leaves a team
            connection.On<int, int>("ReceivePlayerCount", (teamIndex, count) =>
            {
                int current = -1;
                listBox.Items.Add(teamIndex);
                listBox.Items.Add(count);
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
                teamACounter.Text = teamACount.ToString();
                teamBCounter.Text = teamBCount.ToString();
            });

            try
            {
                await connection.StartAsync();
                listBox.Items.Add("Connection started");
                await connection.InvokeAsync("PlayerCountRequest");
            }
            catch (Exception ex)
            {
                listBox.Items.Add(ex.Message);
            }
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
                await connection.InvokeAsync("JoinTeamRequest", 0, "Red", playerID);
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
                await connection.InvokeAsync("JoinTeamRequest", 1, "Blue", playerID);
            }
            catch (Exception ex)
            {
                listBox.Items.Add(ex.Message);
            }
        }
    }
}
