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

namespace opp_server.Classes.Template
{
    public abstract class BallMovement
    {
        public Ball Ball;
        public Field Field;
        public Timer BallLoop = new Timer(50);
        public Server Server { get; set; }
        public Level Level { get; set; }

        public BallMovement(Ball ball)
        {
            Ball = ball;
            BallLoop.Elapsed += BallLoop_Elapsed;
            BallLoop.Enabled = false;
            BallLoop.AutoReset = true;
            BallLoop.Start();
        }

        private void BallLoop_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(Ball.XPosition < 0)
            {
                GameState.GetInstance().Score(1);
            }
            else if(Ball.XPosition > 850)
            {
                GameState.GetInstance().Score(0);
            }

            if (Ball.Speed > 0)
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
            if (Ball.Speed < 0) Ball.Speed = 0;
        }

        public void KickBall(Player player)
        {
            Vector2 ballPosition = new Vector2(Ball.XPosition, Ball.YPosition);
            Vector2 playerPosition = new Vector2(player.XPosition, player.YPosition);
            float distance = Vector2.Distance(ballPosition, playerPosition);
            if (distance > Ball.Radius / 2 + player.Radius / 2 + 15) return;
            Vector2 direction = ballPosition - playerPosition;
            Ball.Direction = Vector2.Normalize(direction);
            Ball.Speed = Ball.MaxSpeed;
        }
        public bool HandleCollisions()
        {
            foreach (Obstacle obstacle in Level.Obstacles)
            {
                if (HandleCollision(Ball, obstacle)) return true;
            }
            return false;
        }

        public bool HandleCollision(Ball ball, Obstacle obstacle)
        {
            Vector2 bc = new Vector2(ball.XPosition + ball.Radius / 2, ball.YPosition + ball.Radius / 2);
            Vector2 o1 = new Vector2(obstacle.XPosition, obstacle.YPosition + obstacle.Height);
            Vector2 o2 = new Vector2(obstacle.XPosition + obstacle.Width, obstacle.YPosition);
            for (int i = 1; i <= (int)ball.Speed; i++)
            {
                bc += Ball.Direction;
                if (DoOverlap(bc, ball.Radius / 2, o1, o2))
                {

                    ball.Direction = NewDirection(bc - ball.Direction, ball.Direction, o1, o2);
                    Vector2 collisionPoint = bc - Ball.Direction - new Vector2(ball.Radius / 2, ball.Radius / 2);
                    Ball.XPosition = (int)collisionPoint.X;
                    Ball.YPosition = (int)collisionPoint.Y;
                    return true;
                }
            }
            return false;
        }

        public bool DoOverlap(Vector2 bc, float R, Vector2 o1, Vector2 o2)
        {
            float Xn = Math.Max(o1.X, Math.Min(bc.X, o2.X));
            float Yn = Math.Min(o1.Y, Math.Max(bc.Y, o2.Y));
            float Dx = Xn - bc.X;
            float Dy = Yn - bc.Y;
            return Dx * Dx + Dy * Dy < R * R;
        }

        public Vector2 NewDirection(Vector2 bc, Vector2 direction, Vector2 o1, Vector2 o2)
        {
            if (bc.Y >= o1.Y || bc.Y <= o2.Y)
            {
                return new Vector2(direction.X, direction.Y * -1);
            }
            if (bc.X <= o1.X || bc.X >= o2.X)
            {
                return new Vector2(direction.X * -1, direction.Y);
            }
            return Vector2.Zero;
        }
    }
}
