using opp_client.Properties;
using opp_lib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opp_client.Flyweight
{
    public class Snowflake
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public SnowflakeType Type { get; private set; }

        public Snowflake(int xPosition, int yPosition, SnowflakeType type)
        {
            this.XPosition = xPosition;
            this.YPosition = yPosition;
            this.Type = type;
        }
        public OvalPictureBox CreateSnowflake()
        {
            OvalPictureBox box = new OvalPictureBox();
            box.Size = new Size(this.Type.Radius, this.Type.Radius);
            box.BorderStyle = BorderStyle.FixedSingle;
            box.BackColor = ControlPaint.LightLight(System.Drawing.Color.FromName(this.Type.Color));
            box.Location = new Point(XPosition, YPosition);
            return box;
        }

        public void MoveDown()
        {
            if (YPosition > 458) YPosition = 0;
            YPosition += Type.Speed;
        }
    }
}
