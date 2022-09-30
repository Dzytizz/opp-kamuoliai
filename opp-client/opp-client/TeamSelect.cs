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

            listBox.Items.Add("Teams are empty.");
            playerID = "";
        }

        private async void TeamSelect_Load(object sender, EventArgs e)
        {

            connection.On<string>("JoinTeamResponse", (response) =>
            {
                playerID = response.Split('|')[0];
                listBox.Items.Add($"Player with ID {playerID} added to a {response.Split('|')[1]} team");
            });

            try
            {
                await connection.StartAsync();
                listBox.Items.Add("Connection started");
            }
            catch (Exception ex)
            {
                listBox.Items.Add(ex.Message);
            }
        }

        // start
        private void button3_Click(object sender, EventArgs e)
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
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                await connection.InvokeAsync("JoinTeam", 0, "Red", playerID);
            }
            catch (Exception ex)
            {
                listBox.Items.Add(ex.Message);

            }
        }

        // join b
        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                await connection.InvokeAsync("JoinTeam", 1, "Blue", playerID);
            }
            catch (Exception ex)
            {
                listBox.Items.Add(ex.Message);
            }
        }
    }
}
