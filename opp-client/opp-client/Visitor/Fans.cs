using opp_client.Prototype;
using opp_lib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_client.Visitor
{
    public class Fans
    {
        private List<Fan> fans = new List<Fan>();
        private List<OvalPictureBox> fansPictureBoxes = new List<OvalPictureBox>();

        public void Attach(Fan fan, OvalPictureBox pictureBox)
        {
            fans.Add(fan);
            fansPictureBoxes.Add(pictureBox);
        }

        public void Detach(Fan fan, OvalPictureBox pictureBox)
        {
            fans.Remove(fan);
            fansPictureBoxes.Remove(pictureBox);
        }

        public void Animate(IVisitor visitor)
        {
            for (int i = 0; i < fans.Count; i++)
            {
                fans[i].Animate(visitor);
                fansPictureBoxes[i].Location = new System.Drawing.Point(fans[i].XPosition, fans[i].YPosition);
                fansPictureBoxes[i].Size = new Size(fans[i].Radius, fans[i].Radius);
            }
        }
    }
}
