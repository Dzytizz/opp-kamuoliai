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
    public partial class Waiting : Form
    {
        public static HubConnection connection;
        public Waiting()
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
        }

        private async void Waiting_Load(object sender, EventArgs e)
        {
            connection.On<bool>("IsAdminResponse", (isAdmin) =>
            {
                if (!this.Visible) return;
                if(isAdmin)
                {                
                    TeamCreation teamCreationWindow = new TeamCreation(connection);
                    teamCreationWindow.Show();
                    this.Hide();
                }
            });
            connection.On("CreateTeamsResponse", () =>
            {
                if (!this.Visible) return;
                TeamSelect teamSelectWindow = new TeamSelect(connection);
                teamSelectWindow.Show();
                this.Hide();
            });
            connection.On<bool>("AreTeamsCreatedResponse", (response) =>
            {
                if (!this.Visible) return;
                if (response)
                {
                    TeamSelect teamSelectWindow = new TeamSelect(connection);
                    teamSelectWindow.Show();
                    this.Hide();
                }
            });
            try
            {
                await connection.StartAsync();
                await connection.InvokeAsync("AreTeamsCreatedRequest");
                await connection.InvokeAsync("IsAdminRequest");
            }
            catch (Exception ex)
            {
            }
        }

        private void Waiting_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
