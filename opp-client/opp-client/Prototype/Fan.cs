using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using opp_lib;
using opp_client.Visitor;

namespace opp_client.Prototype
{
    public class Fan : Element, ICloneable
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public string ColorOfFan { get; set; }
        public int Radius { get; set; }

        public int Direction { get; set; }
        float timer = 0f;
        float maxVal = 3f;
        float step = 0.2f;

        public Fan(int xPosition, int yPosition, string color, int radius, System.Random rng)
        {
            this.XPosition = xPosition;
            this.YPosition = yPosition;
            this.ColorOfFan = color;
            this.Radius = radius;
            this.Direction = rng.NextDouble() <= 0.5f ? this.Direction = 1 : this.Direction = -1;

            timer = (float)(rng.NextDouble() * maxVal);
        }
        public OvalPictureBox CreateFan()
        {
            OvalPictureBox box = new OvalPictureBox();
            box.Size = new Size(this.Radius, this.Radius);
            box.BorderStyle = BorderStyle.FixedSingle;
            box.BackColor = System.Drawing.Color.FromName(this.ColorOfFan);
            box.Location = new Point(XPosition, YPosition);

            return box;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }


        public override void Animate(IVisitor visitor)
        {
            timer += step * Direction;
            if (timer < 0 || timer > maxVal)
            {
                Direction *= -1;
            }

            visitor.Visit(this);
        }
    }
}
