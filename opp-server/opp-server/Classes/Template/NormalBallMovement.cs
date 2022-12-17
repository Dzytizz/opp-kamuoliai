using System;
using System.Numerics;
using System.Timers;
using opp_lib;

namespace opp_server.Classes.Template
{
    public class NormalBallMovement : BallMovement
    {
        public NormalBallMovement(Ball ball) : base(ball)
        {
        }

        protected sealed override void AccelerateBall()
        {
            HandleCollisions();
            Vector2 velocity = Ball.Direction * Ball.Speed;
            Ball.XPosition += (int)velocity.X;
            Ball.YPosition += (int)velocity.Y;
        }
    }
}
