using opp_client.Prototype;
using opp_lib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opp_client.Visitor
{
    public class Fans
    {
        private List<Element> fans = new List<Element>();
        public List<OvalPictureBox> pictureBoxes = new List<OvalPictureBox>();


        public void Attach(Element fan, OvalPictureBox pictureBox)
        {
            fans.Add(fan);
            pictureBoxes.Add(pictureBox);
        }

        public void Detach(Element fan, OvalPictureBox pictureBox)
        {
            fans.Remove(fan);
            pictureBoxes.Remove(pictureBox);
        }

        public void Animate(IVisitor visitor)
        {
            foreach(var fan in fans)
            {
                fan.Animate(visitor);
            }
        }

        public void Render()
        {
            for (int i = 0; i < fans.Count; i++)
            {
                Fan fan = fans[i] as Fan;
                pictureBoxes[i].Location = new Point(fan.XPosition, fan.YPosition);
                pictureBoxes[i].Size = new Size(fan.Radius, fan.Radius);

                if (fan.IsLighter > 0)
                {
                    pictureBoxes[i].BackColor = ControlPaint.Light(Color.FromName(fan.ColorOfFan));
                }
                else
                {
                    pictureBoxes[i].BackColor = ControlPaint.Dark(Color.FromName(fan.ColorOfFan));
                }
            }
        }
    }
}
