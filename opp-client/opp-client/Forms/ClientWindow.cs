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
using opp_client.Facade;
using opp_client.Flyweight;
using opp_client.Proxy;
using opp_client.Visitor;
using System.Drawing.Printing;

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
        List<PictureBox> wallsPb;
        Control ballControl;
        List<Tuple<Snowflake, OvalPictureBox>> snowflakes;

        ThemeClient themeClient = new ThemeClient();
        PlayerClient playerClient = new PlayerClient();
        bool isTyping = false;

        IMessenger messenger;

        Fans animatedFans = new Fans();
        UpDownVisitor upDownVisitor = new UpDownVisitor();
        LeftRightVisitor leftRightVisitor = new LeftRightVisitor();
        ColorChangeVisitor colorChangeVisitor = new ColorChangeVisitor();

        public ClientWindow(HubConnection connection, string playerID)
        {
            InitializeComponent();

            this.connection = connection;
            this.playerID = playerID;
            messenger = new MessengerProxy(playerID, ClientSize.Width, ClientSize.Height);

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            //playerID = "";
            playerInput = new PlayerInput();
            mpObjects = new Dictionary<string, PictureBox>();

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            snowflakes = new List<Tuple<Snowflake, OvalPictureBox>>();
            GenerateSnowflakes();

            chatTextBox.Hide();
        }

        private async void ClientWindow_Load(object sender, EventArgs e)
        {
            //ThemeManager tm = ThemeManager.GetInstance();
            themeClient.ApplyTheme(this);

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

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

            connection.On<string, string>("TeamColorsResponse", (team1Color, team2Color) =>
            {
                int nullPosition = 0;
                int radius = 20;
                Fan fan1 = new Fan(nullPosition, nullPosition, team1Color, radius);

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

                    animatedFans.Attach(fan, fanBox);
                }

                fan1 = new Fan(nullPosition, nullPosition, team2Color, radius);

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

                    animatedFans.Attach(fan, fanBox);
                }
            });

            connection.On<string>("BallResponse", (response) =>
            {
                Ball ball = JsonConvert.DeserializeObject<Ball>(response);

                if (ballControl == null) // if no ball is created, create one using Builder
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
                foreach (Obstacle o in level.Obstacles)
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

            connection.On<string>("SendMessageToAllResponse", (message) =>
            {
                logList.Items.Add(message);
            });

            connection.On<string>("SendMessageToResponse", (message) =>
            {
                logList.Items.Add(message);
            });

            connection.On<List<Obstacle>>("WallResponse", (walls) => {
                foreach (var wall in walls)
                {
                    PictureBox pb = new PictureBox();
                    pb.Location = new Point(wall.XPosition, wall.YPosition);
                    pb.Width = wall.Width;
                    pb.Height = wall.Height;
                    pb.BackColor = Color.FromName(wall.Color);
                    wallsPb.Add(pb);
                    this.Controls.Add(pb);
                    pb.BringToFront();
                }
            });

            connection.On("WallRemoveResponse", () =>
            {
                foreach (var pb in wallsPb)
                {
                    this.Controls.Remove(pb);
                }
                wallsPb.Clear();
            });

            try
            {
                await connection.InvokeAsync("LevelRequest");
                await connection.InvokeAsync("GameStateRequest");
                await connection.InvokeAsync("BallRequest");
                await connection.InvokeAsync("TeamColorsRequest");
                await connection.InvokeAsync("WallRequest", ClientSize.Width, ClientSize.Height);
            }
            catch (Exception ex)
            {
                logList.Items.Add(ex.Message);
            }
        }

        private async void MainGameLoop_Tick(object sender, EventArgs e)
        {
            if (!playerID.Equals("") && !isTyping)
            {
                // send inputs to server
                if (playerInput.IsActive())
                {
                    try
                    {
                        playerClient.ProcessMovement(ref playerInput, connection, playerID);    
                    }
                    catch (Exception ex)
                    {
                        logList.Items.Add(ex.Message);
                    }
                }
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
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
            if (e.KeyCode == Keys.B)
            {
                playerInput.ToUndo = true;
                playerInput.ToUndoKeyUp = false;
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
            if (e.KeyCode == Keys.B)
            {
                playerInput.ToUndo = false;
                playerInput.ToUndoKeyUp = true;
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

            //if (e.KeyCode == Keys.N)
            //{
            //    try
            //    {
            //        List<string> arguments = new List<string>();
            //        arguments.Add("2");
            //        await connection.InvokeAsync("LevelChangeRequest", arguments);
            //    }
            //    catch (Exception ex)
            //    {
            //        logList.Items.Add(ex.Message);
            //    }

            //}
            if (e.KeyCode == Keys.K)
            {
                await connection.InvokeAsync("KickBallRequest", playerID);
            }
            if(e.KeyCode == Keys.Enter)
            {
                HandleTypingMode();
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
            foreach (PictureBox obstacle in obstacles)
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

        private void GenerateSnowflakes()
        {
            Random r = new Random();
            for(int i = 0; i < 30/2; i++)
            {
                SnowflakeType type = SnowflakeFactory.GetSnowflakeType("small", "blue", 5, 15);
                Snowflake snowflake = new Snowflake(r.Next(0, 850), r.Next(0, 458), type);
                OvalPictureBox pb = snowflake.CreateSnowflake();
                snowflakes.Add(Tuple.Create(snowflake, pb));
                this.Controls.Add(pb);
            }
            for (int i = 0; i < 20/2; i++)
            {
                SnowflakeType type = SnowflakeFactory.GetSnowflakeType("medium", "blue", 10, 10);
                Snowflake snowflake = new Snowflake(r.Next(0, 850), r.Next(0, 458), type);
                OvalPictureBox pb = snowflake.CreateSnowflake();
                snowflakes.Add(Tuple.Create(snowflake, pb));
                this.Controls.Add(pb);
            }
            for (int i = 0; i < 10/2; i++)
            {
                SnowflakeType type = SnowflakeFactory.GetSnowflakeType("large", "blue", 15, 5);
                Snowflake snowflake = new Snowflake(r.Next(0, 850), r.Next(0, 458), type);
                OvalPictureBox pb = snowflake.CreateSnowflake();
                snowflakes.Add(Tuple.Create(snowflake, pb));
                this.Controls.Add(pb);
            }
        }

        private async void HandleTypingMode()
        {
            isTyping = !isTyping;
            if(isTyping)
            {
                chatTextBox.Text = "";
                chatTextBox.Show();
                this.ActiveControl = chatTextBox;
            }
            else
            {
                if(chatTextBox.Text.Length > 0)
                {

                    //Cia Kviesti Messenger Proxy
                    //Sita istrinti
                    messenger.HandleMessageAsync(chatTextBox.Text, connection);
                    //await connection.InvokeAsync("SendMessageToAllRequest", playerID, chatTextBox.Text); // <-
                    //Sita istrinti
                }
                chatTextBox.Hide();
                this.ActiveControl = logList;
            }
        }

        //private int snowflakeIndex = 0;

        private int snowflakeBlock = 1;
        private int snowflakeBlockCount = 3;
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            SuspendLayout();

            //if (snowflakeIndex == snowflakes.Count)
            //{
            //    snowflakeIndex = 0;
            //}
            //Snowflake snowflake = snowflakes[snowflakeIndex].Item1;
            //snowflake.MoveDown();
            //OvalPictureBox pictureBox = snowflakes[snowflakeIndex].Item2;
            //pictureBox.Location = new Point(snowflake.XPosition, snowflake.YPosition);
            //snowflakeIndex++;


            if (snowflakeBlock > snowflakeBlockCount)
            {
                snowflakeBlock = 1;
            }

            int blockSize = snowflakes.Count / snowflakeBlockCount;
            for (int i = (snowflakeBlock-1)*snowflakeBlock; i < snowflakeBlock * blockSize; i++)
            {
                Snowflake snowflake = snowflakes[i].Item1;
                snowflake.MoveDown();
                OvalPictureBox pictureBox = snowflakes[i].Item2;
                pictureBox.Location = new Point(snowflake.XPosition, snowflake.YPosition);
            }
            snowflakeBlock++;


            //foreach (Tuple<Snowflake, OvalPictureBox> tuple in snowflakes)
            //{
            //    tuple.Item1.MoveDown();
            //    tuple.Item2.Location = new Point(tuple.Item1.XPosition, tuple.Item1.YPosition);
            //}

            animatedFans.Animate(upDownVisitor);
            animatedFans.Animate(leftRightVisitor);
            animatedFans.Animate(colorChangeVisitor);
            animatedFans.Render();

            ResumeLayout(false);
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
