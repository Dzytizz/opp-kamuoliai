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
