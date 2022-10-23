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
            //pb.Location = new Point((int)Player.XPosition, (int)Player.YPosition);
            Label playerNameLabel = new Label();
            playerNameLabel.AutoSize = true;
            playerNameLabel.Text = Player.Name;
            //playerNameLabel.Padding = new Padding(0, 0, 0, 0);
            //playerNameLabel.Margin = new Padding(0, 0, 0, 0);
            pb.Controls.Add(playerNameLabel);
            playerNameLabel.Location = new Point( 25 - (playerNameLabel.Size.Width / 2),  25 - (playerNameLabel.Size.Height / 2));
            //playerNameLabel.Location = new Point(25, 25);
            playerNameLabel.BringToFront();

            return pb;
        }
    }
}
