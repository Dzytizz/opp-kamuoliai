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
        public Field Field;
        public Timer BallLoop = new Timer(50);
        public Server Server { get; set; }
        public BallMovement(Ball ball)
        {
            this.Ball = ball;
            BallLoop.Elapsed += BallLoop_Elapsed;
            BallLoop.Enabled = false;
            BallLoop.AutoReset = true;
            BallLoop.Start();
        }

        private void BallLoop_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(Ball.Speed > 0)
            {
                AccelerateBall();
                DecelerateBall();
                
                ApplyFieldFriction();

                Server.Send();
            }
        }

        protected abstract void AccelerateBall();

        protected void DecelerateBall()
        {
            Ball.Speed -= Ball.Decelerate;
            if (Ball.Speed < 0) Ball.Speed = 0;
        }

        protected virtual void ApplyFieldFriction()
        {
            Ball.Speed -= Ball.Speed * Field.FrictionMultiplier;
            if(Ball.Speed < 0) Ball.Speed = 0;
        }

        public void KickBall(Player player)
        {
            Vector2 ballPosition = new Vector2(Ball.XPosition, Ball.YPosition);
            Vector2 playerPosition = new Vector2(player.XPosition, player.YPosition);
            float distance = Vector2.Distance(ballPosition, playerPosition);
            if (distance > Ball.Radius/2 + player.Radius/2 + 15) return;
            Vector2 direction = ballPosition - playerPosition;
            Ball.Direction = Vector2.Normalize(direction);
            Ball.Speed = Ball.MaxSpeed;
        }
    }
}
