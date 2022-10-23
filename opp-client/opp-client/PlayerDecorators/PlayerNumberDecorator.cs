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
    public class PlayerNumberDecorator : Decorator
    {
        public string Number { get; set; }
        public PlayerNumberDecorator(IDecorator component, string number) : base(component)
        {
            Number = number;
        }

        public override OvalPictureBox Display(string teamColor)
        {
            OvalPictureBox pb = Component.Display(teamColor);
            Label playerNumberLabel = new Label();
            playerNumberLabel.AutoSize = true;
            playerNumberLabel.Text = Number;
            pb.Controls.Add(playerNumberLabel);
            playerNumberLabel.Location = new Point(25 - (playerNumberLabel.Size.Width / 2), 40 - (playerNumberLabel.Size.Height / 2));
            playerNumberLabel.BringToFront();
            return pb;
        }
    }
}
