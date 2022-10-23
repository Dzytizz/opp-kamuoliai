using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opp_lib
{
    public class OvalPictureBox : PictureBox
    {
        public OvalPictureBox()
        {
            this.BackColor = Color.Transparent;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(0, 0, this.Width - 1, this.Height - 1);

                this.Region = new Region(gp);
            }
        }

        //public static OvalPictureBox SquareToOval(PictureBox pictureBox)
        //{
        //    OvalPictureBox ovalPictureBox = new OvalPictureBox();
        //    ovalPictureBox.Width = pictureBox.Width;
        //    ovalPictureBox.Height = pictureBox.Height;
        //    ovalPictureBox.BackColor = pictureBox.BackColor;
        //    ovalPictureBox.Location = pictureBox.Location;
        //    foreach (Control control in pictureBox.Controls)
        //    {
        //        ovalPictureBox.Controls.Add(control);
        //    }
        //    return ovalPictureBox;
        //}
    }
}
