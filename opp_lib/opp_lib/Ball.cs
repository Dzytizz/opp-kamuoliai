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
    public class Ball
    {
        public int XPosition { get;set; }
        public int YPosition { get; set; }
        public int Radius { get; set; }
        public string MainColor { get; set; }
        public Vector2 Speed { get; set; }
        public bool HasEdge { get; set; }
        public List<BallVisual> VisualParts { get; set; } 

        public Ball(int radius, int xPosition, int yPosition, string mainColor)
        {
            Radius = radius;
            XPosition = xPosition;
            YPosition = yPosition;
            MainColor = mainColor;
            Speed = Vector2.Zero;
            HasEdge = false;
            VisualParts = new List<BallVisual>();
        }
    }
}
