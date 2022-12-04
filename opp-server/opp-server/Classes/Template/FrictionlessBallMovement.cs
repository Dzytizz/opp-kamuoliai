using System.Numerics;
using System.Timers;
using opp_lib;

namespace opp_server.Classes.Template
{
    public class FrictionlessBallMovement : BallMovement
    {
        public FrictionlessBallMovement(Ball ball) : base(ball)
        {
        }

        protected sealed override void AccelerateBall()
        {
            Vector2 velocity = Ball.Direction * Ball.Speed;
            Ball.XPosition += (int)velocity.X;
            Ball.YPosition += (int)velocity.Y;
        }

        protected sealed override void ApplyFieldFriction()
        {
            return;
        }
    }
}
