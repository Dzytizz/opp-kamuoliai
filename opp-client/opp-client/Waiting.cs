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
                if(isAdmin)
                {
                    TeamCreation teamCreationWindow = new TeamCreation(connection);
                    teamCreationWindow.Show();
                    Hide();
                }
            });
            connection.On("CreateTeamsResponse", () =>
            {
                //TeamSelect teamSelectWindow = new TeamSelect();
                //teamSelectWindow.Show();
                //Close();
                TeamSelect teamSelectWindow = new TeamSelect(connection);
                Hide();
                teamSelectWindow.ShowDialog();
                Hide();
            });
            connection.On<bool>("AreTeamsCreatedResponse", (response) =>
            {
                if (response)
                {
                    TeamSelect teamSelectWindow = new TeamSelect(connection);
                    
                    teamSelectWindow.Show();
                    Hide();
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
    }
}
