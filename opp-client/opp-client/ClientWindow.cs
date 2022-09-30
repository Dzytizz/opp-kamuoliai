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
using Newtonsoft.Json;
using opp_lib;

namespace opp_client
{
    public partial class ClientWindow : Form
    {
        public HubConnection connection;
        public string playerID;
        public PlayerInput playerInput;

        Dictionary<string, PictureBox> mpObjects; 

        public ClientWindow(HubConnection connection, string playerID)
        {
            InitializeComponent();

            this.connection = connection;
            this.playerID = playerID;

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            playerID = "";
            playerInput = new PlayerInput();
            mpObjects = new Dictionary<string, PictureBox>();
        }

        private void ClientWindow_Load(object sender, EventArgs e)
        {
            //connection.On<string, string>("ReceiveMessage", (user, message) =>
            //{
            //    var newMessage = $"{user}: {message}";
            //    messagesList.Items.Add(newMessage);
            //});

            //connection.On<string>("JoinGameResponse", (response) =>
            //{
            //    playerID = response;
            //    playerIDLabel.Text = playerID;
            //});

            connection.On<string>("UpdatePlayerPositionResponse", (response) =>
            {
                //logList.Items.Add(response);
            });

            connection.On<string>("GameStateResponse", (response) =>
            {
                GameState gameStateResponse = JsonConvert.DeserializeObject<GameState>(response);
                //logList.Items.Add(gameStateResponse.ToString());

                for (int i = gameStateResponse.Teams.Count - 1; i >= 0; i--)
                {
                    Team team = gameStateResponse.Teams[i];
                    
                    foreach(KeyValuePair<string, Player> entry in team.Players)
                    {
                        if (!mpObjects.ContainsKey(entry.Key))
                        {
                            PictureBox pb = new PictureBox();
                            pb.Width = 50;
                            pb.Height = 50;
                            pb.BackColor = Color.FromName(team.Color);
                            mpObjects.Add(entry.Key, pb);
                            this.Controls.Add(pb);
                        }

                        mpObjects[entry.Key].Location = new Point((int)entry.Value.XPosition, (int)entry.Value.YPosition);
                    }

                    for (int j = gameStateResponse.Teams[i].Players.Count - 1; j >= 0; j--)
                    {
                       
                    }
                }
            });
        }

        private async void MainGameLoop_Tick(object sender, EventArgs e)
        {
            if (playerInput.IsActive() && !playerID.Equals(""))
            {
                try
                {
                    string playerInputJSON = JsonConvert.SerializeObject(playerInput);
                    await connection.InvokeAsync("UpdatePlayerPositionRequest", playerID, playerInputJSON);
                }
                catch (Exception ex)
                {
                    logList.Items.Add(ex.Message);
                }
            }

            if (!playerID.Equals(""))
            {
                try
                {
                    await connection.InvokeAsync("GameStateRequest");
                }
                catch (Exception ex)
                {
                    logList.Items.Add(ex.Message);
                } 
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.W)
            {
                playerInput.Up = true;
            }
            if (e.KeyCode == Keys.S)
            {
                playerInput.Down = true;
            }
            if (e.KeyCode == Keys.A)
            {
                playerInput.Left = true;
            }
            if (e.KeyCode == Keys.D)
            {
                playerInput.Right = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                playerInput.Up = false;
            }
            if (e.KeyCode == Keys.S)
            {
                playerInput.Down = false;
            }
            if (e.KeyCode == Keys.A)
            {
                playerInput.Left = false;
            }
            if (e.KeyCode == Keys.D)
            {
                playerInput.Right = false;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                await connection.InvokeAsync("GameStateRequest");
            }
            catch (Exception ex)
            {
                logList.Items.Add(ex.Message);
            }
        }

        //private async void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        await connection.InvokeAsync("SendMessage",
        //            userTextBox.Text, messageTextBox.Text);
        //    }
        //    catch (Exception ex)
        //    {
        //        messagesList.Items.Add(ex.Message);
        //    }
        //}
    }
}
