using opp_client.Properties;
using opp_lib;
using opp_lib.Decorator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opp_client.PlayerDecorators
{
    public class PlayerUniformDecorator : Decorator
    {
        public string Uniform { get; set; }
        public PlayerUniformDecorator(IDecorator component, string uniform) : base(component)
        {
            Uniform = uniform;
        }

        public override OvalPictureBox Display(string teamColor)
        {
            OvalPictureBox pb = Component.Display(teamColor);
            pb.Image = (Image)Resources.ResourceManager.GetObject(Uniform);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            return pb;
        }
    }
}
