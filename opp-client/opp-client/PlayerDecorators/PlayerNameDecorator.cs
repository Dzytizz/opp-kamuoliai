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
    class PlayerNameDecorator : Decorator
    {
        public string Name { get; set; }
        public PlayerNameDecorator(IDecorator component, string name) : base(component)
        {
            Name = name;
        }

        public override OvalPictureBox Display(string teamColor)
        {
            OvalPictureBox pb = Component.Display(teamColor);
            Label playerNameLabel = new Label();
            playerNameLabel.AutoSize = true;
            playerNameLabel.Text = Name;
            pb.Controls.Add(playerNameLabel);
            playerNameLabel.Location = new Point(25 - (playerNameLabel.Size.Width / 2), 25 - (playerNameLabel.Size.Height / 2));
            playerNameLabel.BringToFront();
            return pb;
        }
    }
}
