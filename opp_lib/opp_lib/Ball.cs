using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Forms;
using System.Drawing;

namespace opp_lib
{
    public class Ball : ICloneable
    {
        public int XPosition { get;set; }
        public int YPosition { get; set; }
        public int Radius { get; set; }
        public string MainColor { get; set; }
        public float Speed { get; set; }
        public float MaxSpeed = 20;
        public float Decelerate = 1;

        public Vector2 Direction { get; set; }
        public bool HasEdge { get; set; }
        public List<BallVisual> VisualParts { get; set; }

        public Ball(int radius, int xPosition, int yPosition, string mainColor)
        {
            Radius = radius;
            XPosition = xPosition;
            YPosition = yPosition;
            MainColor = mainColor;
            Speed = 0;
            Direction = Vector2.Zero;
            HasEdge = false;
            VisualParts = new List<BallVisual>();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
