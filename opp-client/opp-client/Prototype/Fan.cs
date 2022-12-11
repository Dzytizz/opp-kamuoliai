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
    public class Fan : ICloneable
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public string ColorOfFan { get; set; }
        public int Radius { get; set; }

        public Fan(int xPosition, int yPosition, string color, int radius)
        {
            this.XPosition = xPosition;
            this.YPosition = yPosition;
            this.ColorOfFan = color;
            this.Radius = radius;
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
    }
}
