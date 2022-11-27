using System.Numerics;
using System.Timers;
using opp_lib;

namespace opp_server.Classes
{
    public class NormalBallMovement : BallMovement
    {
        public NormalBallMovement(Ball ball) : base(ball)
        {
        }

        protected sealed override void AccelerateBall()
        {
            Vector2 velocity = Ball.Direction * Ball.Speed;
            Ball.XPosition += (int)velocity.X;
            Ball.YPosition += (int)velocity.Y;
        }
    }
}
