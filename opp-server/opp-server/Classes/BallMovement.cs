using Microsoft.AspNetCore.SignalR;
using opp_lib;
using opp_server.Classes.Observer;
using opp_server.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Timers;

namespace opp_server.Classes
{
    public class BallMovement
    {
        public Ball Ball;
        public Timer BallLoop = new Timer(50);
        public Server Server { get; set; }
        public BallMovement(Ball ball)
        {
            this.Ball = ball;
            BallLoop.Elapsed += BallLoop_Elapsed;
            BallLoop.Enabled = true;
            BallLoop.AutoReset = true;
            BallLoop.Start();
        }

        private void BallLoop_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(Ball.Speed > 0)
            {
                Vector2 velocity = Ball.Direction * Ball.Speed;
                Ball.XPosition += (int)velocity.X;
                Ball.YPosition += (int)velocity.Y;
                Ball.Speed -= Ball.Decelerate;
                if (Ball.Speed < 0) Ball.Speed = 0;
                Server.Send();
            }
        }

        public void KickBall(Player player)
        {
            Vector2 ballPosition = new Vector2(Ball.XPosition, Ball.YPosition);
            Vector2 playerPosition = new Vector2(player.XPosition, player.YPosition);
            float distance = Vector2.Distance(ballPosition, playerPosition);
            if (distance > Ball.Radius + player.Radius + 5) return;
            Vector2 direction = ballPosition - playerPosition;
            Ball.Direction = Vector2.Normalize(direction);
            Ball.Speed = Ball.MaxSpeed;
        }
    }
}
