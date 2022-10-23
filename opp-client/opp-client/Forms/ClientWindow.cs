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
using opp_client.Singleton;
using System.IO;
using opp_client.Properties;
using opp_lib.Decorator;
using opp_client.PlayerDecorators;
using opp_client.Prototype;


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
        Control temp;

        Control ballControl;

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

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private async void ClientWindow_Load(object sender, EventArgs e)
        {
            ThemeManager tm = ThemeManager.GetInstance();
            this.BackColor = tm.BackgroundDark;
            this.Font = tm.TextFont;
            foreach (Control control in this.Controls)
            {
                tm.UpdateColor(control);
            }

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

            connection.On<string>("BallResponse", (response) =>
            {
                Ball ball = JsonConvert.DeserializeObject<Ball>(response);

                if(ballControl == null) // if no ball is created, create one using Builder
                {
                    // initial setup
                    OvalPictureBox pb = new OvalPictureBox();
                    pb.Width = pb.Height = ball.Radius;
                    pb.BackColor = Color.FromName(ball.MainColor);
                    ballControl = pb;
                    this.Controls.Add(ballControl);

                    // layered images
                    Control lastLayer = ballControl;
                    for (int i = 0; i < ball.VisualParts.Count; i++)
                    {
                        BallVisual bv = ball.VisualParts[i];

                        pb = new OvalPictureBox();
                        pb.Width = pb.Height = bv.Radius;
                        pb.BackColor = Color.Transparent;

                        pb.Image = (Image)Resources.ResourceManager.GetObject(bv.ImageName);
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        pb.BringToFront();

                        ballControl.Controls.Add(pb);

                        lastLayer.Controls.Add(pb);
                        lastLayer = lastLayer.Controls[0];
                    }

                    // edge always on top
                    if (ball.HasEdge)
                    {
                        pb = new OvalPictureBox();
                        pb.Width = pb.Height = ball.Radius;
                        pb.BackColor = Color.Transparent;

                        pb.Image = Resources.border;
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        pb.BringToFront();

                        lastLayer.Controls.Add(pb);
                    }
                }
                // else ball location is updated only
                ballControl.Location = new Point(ball.XPosition, ball.YPosition);
            });

            connection.On<string>("GameStateResponse", (response) =>
            {
                GameState gameStateResponse = JsonConvert.DeserializeObject<GameState>(response);
                //logList.Items.Add(gameStateResponse.ToString());

                int teamNumber = 0;
                for (int i = gameStateResponse.Teams.Count - 1; i >= 0; i--)
                {
                    Team team = gameStateResponse.Teams[i];

                    foreach (KeyValuePair<string, Player> entry in team.Players)
                    {
                        if (!mpObjects.ContainsKey(entry.Key))
                        {
                            //OvalPictureBox pb = new OvalPictureBox();
                            //pb.Width = 50;
                            //pb.Height = 50;
                            //pb.BackColor = Color.FromName(team.Color);
                            //if (entry.Key.Equals(playerID))
                            //{
                            //    pb.BackColor = ControlPaint.LightLight(pb.BackColor);
                            //}
                            //mpObjects.Add(entry.Key, pb);
                            //this.Controls.Add(pb);
                            Decorator playerNameDecorator = new PlayerNameDecorator(entry.Value, entry.Value.Name);
                            Decorator playerUniformDecorator = new PlayerUniformDecorator(playerNameDecorator, entry.Value.UniformName);
                            Decorator playerNumberDecorator = new PlayerNumberDecorator(playerUniformDecorator, entry.Value.Number.ToString());
                            OvalPictureBox pb = playerNumberDecorator.Display(team.Color);
                            if (entry.Key.Equals(playerID))
                            {
                                pb.BackColor = ControlPaint.LightLight(pb.BackColor);
                            }
                            mpObjects.Add(entry.Key, pb);
                            this.Controls.Add(pb);
           
                        }

                        mpObjects[entry.Key].Location = new Point((int)entry.Value.XPosition, (int)entry.Value.YPosition);
                    }
                    int nullPosition = 0;
                    
                    Fan fan1 = new Fan(nullPosition, nullPosition, team.Color, 20);

                    if (teamNumber == 0)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            Fan fan = fan1.Clone() as Fan;
                            fan.XPosition = fan1.XPosition + 40 + j * 40;
                            fan.YPosition = fan1.YPosition + 340;
                            OvalPictureBox fanBox = fan.CreateFan();
                            int ihash = fan.GetHashCode();
                            // Console.WriteLine(ihash);
                            //  Console.WriteLine("Pirma komanda " + j + ": " + ihash);
                            this.Controls.Add(fanBox);
                        }
                    }

                    if (teamNumber == 1)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            Fan fan = (Fan)fan1.Clone();
                            fan.XPosition = fan1.XPosition + 430 + j * 40;
                            fan.YPosition = fan1.YPosition + 340;
                            OvalPictureBox fanBox = fan.CreateFan();
                            int ihash = fan.GetHashCode();
                            //Console.WriteLine(ihash);
                            //Console.WriteLine("Antra komanda " + j + ": " + ihash);
                            this.Controls.Add(fanBox);
                        }
                    }
                    teamNumber++;

                }
            });

            connection.On<string>("LevelResponse", (response) => 
            {
                Level level = JsonConvert.DeserializeObject<Level>(response);
                leftGates = CreateGates(level.LeftGates);
                rightGates = CreateGates(level.RightGates);
                CreateField(level.Field);
                this.Controls.Add(leftGates);
                this.Controls.Add(rightGates);
                obstacles = new List<PictureBox>();
                foreach(Obstacle o in level.Obstacles)
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
                UpdateGates(leftGates, level.LeftGates);
                UpdateGates(rightGates, level.RightGates);
                CreateField(level.Field);
                foreach (Obstacle o in level.Obstacles)
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
                await connection.InvokeAsync("BallRequest");
            }
            catch (Exception ex)
            {
                logList.Items.Add(ex.Message);
            }
        }

        private async void MainGameLoop_Tick(object sender, EventArgs e)
        {
            if (!playerID.Equals(""))
            {
                // send inputs to server
                if(playerInput.IsActive())
                {
                    try
                    {
                        string playerInputJSON = JsonConvert.SerializeObject(playerInput);
                        playerInput.ResetJump();
                        await connection.InvokeAsync("UpdatePlayerPositionRequest", playerID, playerInputJSON);
                    }
                    catch (Exception ex)
                    {
                        logList.Items.Add(ex.Message);
                    }
                }
            
                // request recalculated ball position from server
                try
                {
                    await connection.InvokeAsync("BallRequest");
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

            if (e.KeyCode == Keys.ControlKey) // slowest (1)
            {
                playerInput.ToWalk = true;
            }
            if (e.KeyCode == Keys.ShiftKey) // faster (3)
            {
                playerInput.ToRun = true;
            }
            if (e.KeyCode == Keys.Space && playerInput.ToJumpKeyUp) // fastest/dash (4)
            {
                playerInput.ToJump = true;
                playerInput.ToJumpKeyUp = false;
            }
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

            if (e.KeyCode == Keys.ControlKey) // slowest (1)
            {
                playerInput.ToWalk = false;
            }
            if (e.KeyCode == Keys.ShiftKey) // faster (3)
            {
                playerInput.ToRun = false;
            }
            if (e.KeyCode == Keys.Space) // fastest/dash (4)
            {
                playerInput.ToJump = false;
                playerInput.ToJumpKeyUp = true;
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

        // Clears inputs if window goes out of focus
        protected override void OnDeactivate(EventArgs e)
        {
            playerInput.Clear();
        }

        private void ClientWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private PictureBox CreateGates(Gates gates)
        {
            PictureBox picture = new PictureBox();
            picture.Width = gates.Width;
            picture.Height = gates.Height;
            picture.BackColor = Color.FromName(gates.Color);
            picture.Location = new Point(gates.XPosition, gates.YPosition);
            return picture;
        }

        private void CreateField(Field field)
        {
            this.BackColor = Color.FromName(field.Color);
        }

        private PictureBox CreateObstacle(Obstacle obstacle)
        {
            PictureBox picture = new PictureBox();
            picture.Width = obstacle.Width;
            picture.Height = obstacle.Height;
            picture.BackColor = Color.FromName(obstacle.Color);
            picture.Location = new Point(obstacle.XPosition, obstacle.YPosition);
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
            picture.Width = gates.Width;
            picture.Height = gates.Height;
            picture.BackColor = Color.FromName(gates.Color);
            picture.Location = new Point(gates.XPosition, gates.YPosition);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
