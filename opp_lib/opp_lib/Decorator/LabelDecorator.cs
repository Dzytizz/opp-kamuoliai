using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opp_lib.Decorator
{
    public class LabelDecorator : Decorator
    {
        public LabelDecorator(Player player) : base(player) { }

        public override OvalPictureBox Display(string teamColor)
        {
            OvalPictureBox pb = Player.Display(teamColor);
            Label playerNameLabel = new Label();
            playerNameLabel.AutoSize = true;
            playerNameLabel.Text = Player.Name;            
            pb.Controls.Add(playerNameLabel);
            playerNameLabel.Location = new Point((int)Player.XPosition + 25 - (playerNameLabel.Size.Width / 2), (int)Player.YPosition + 25 - (playerNameLabel.Size.Height / 2));
            playerNameLabel.BringToFront();
            return pb;
        }
    }
}
