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
        PictureBox leftGates;
        PictureBox rightGates;
        List<PictureBox> obstacles;

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

        private async void ClientWindow_Load(object sender, EventArgs e)
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

            //connection.On<string>("UpdatePlayerPositionResponse", (response) =>
            //{
            //    logList.Items.Add(response);
            //});

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
                            OvalPictureBox pb = new OvalPictureBox();
                            pb.Width = 50;
                            pb.Height = 50;
                            pb.BackColor = Color.FromName(team.Color);
                            if (entry.Key.Equals(playerID))
                            {
                                pb.BackColor =ControlPaint.LightLight(pb.BackColor);
                            }
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

            connection.On<string>("LevelResponse", (response) => 
            {
                Level level = JsonConvert.DeserializeObject<Level>(response);
                leftGates = CreateGates(level.leftGates);
                rightGates = CreateGates(level.rightGates);
                CreateField(level.field);
                this.Controls.Add(leftGates);
                this.Controls.Add(rightGates);
                obstacles = new List<PictureBox>();
                foreach(Obstacle o in level.obstacles)
                {
                    PictureBox obstacle = CreateObstacle(o);
                    obstacles.Add(obstacle);
                    this.Controls.Add(obstacle);
                }
            });

            connection.On<string>("LevelChangeResponse", (response) => 
            {
                Level level = JsonConvert.DeserializeObject<Level>(response);
                ClearObstacles();
                UpdateGates(leftGates, level.leftGates);
                UpdateGates(rightGates, level.rightGates);
                CreateField(level.field);
                foreach (Obstacle o in level.obstacles)
                {
                    PictureBox obstacle = CreateObstacle(o);
                    obstacles.Add(obstacle);
                    this.Controls.Add(obstacle);
                }
            });

            try
            {
                await connection.InvokeAsync("LevelRequest");
                await connection.InvokeAsync("GameStateRequest");
            }
            catch (Exception ex)
            {
                logList.Items.Add(ex.Message);
            }
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

           /* if (!playerID.Equals(""))
            {
                try
                {
                    await connection.InvokeAsync("GameStateRequest");
                }
                catch (Exception ex)
                {
                    logList.Items.Add(ex.Message);
                } 
            }*/
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
            if (e.KeyCode == Keys.E)
            {
                playerInput.ToJog = true;
            }
            if (e.KeyCode == Keys.Q)
            {
                playerInput.ToRun = true;
            }
            if (e.KeyCode == Keys.Space)
            {
                playerInput.ToJump = true;
            }
        }

        protected override void OnDeactivate(EventArgs e)
        {
            playerInput.Clear();
        }

        private async void KeyIsUp(object sender, KeyEventArgs e)
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

            if (e.KeyCode == Keys.E)
            {
                playerInput.ToJog = false;
            }
            if (e.KeyCode == Keys.Q)
            {
                playerInput.ToRun = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                playerInput.ToJump = false;
            }
            if (e.KeyCode == Keys.N)
            {
                try
                {
                    await connection.InvokeAsync("LevelChangeRequest");
                }
                catch (Exception ex)
                {
                    logList.Items.Add(ex.Message);
                }

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

        private void ClientWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private PictureBox CreateGates(Gates gates)
        {
            PictureBox picture = new PictureBox();
            picture.Width = gates.width;
            picture.Height = gates.height;
            picture.BackColor = Color.FromName(gates.color);
            picture.Location = new Point(gates.xPosition, gates.yPosition);
            return picture;
        }

        private void CreateField(Field field)
        {
            this.BackColor = Color.FromName(field.color);
        }

        private PictureBox CreateObstacle(Obstacle obstacle)
        {
            PictureBox picture = new PictureBox();
            picture.Width = obstacle.width;
            picture.Height = obstacle.height;
            picture.BackColor = Color.FromName(obstacle.color);
            picture.Location = new Point(obstacle.xPosition, obstacle.yPosition);
            return picture;
        }

        private void ClearObstacles()
        {
            foreach(PictureBox obstacle in obstacles)
            {
                this.Controls.Remove(obstacle);
            }
            obstacles.Clear();
        }

        private void UpdateGates(PictureBox picture, Gates gates)
        {
            picture.Width = gates.width;
            picture.Height = gates.height;
            picture.BackColor = Color.FromName(gates.color);
            picture.Location = new Point(gates.xPosition, gates.yPosition);
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
