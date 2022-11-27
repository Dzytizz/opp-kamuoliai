using opp_lib.Command;
using opp_lib.Decorator;
using opp_lib.Strategy;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opp_lib
{
    public class Player : IDecorator
    {
        public string Name { get; set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public float Speed { get; set; } = 5;
        private MovementMode MovementMode { get; set; }
        public string UniformName { get; set; }
        public int Number { get; set; }

        public int Radius { get; set; }

        Invoker invoker = new Invoker();

        public Player(string name, float xPosition, float yPosition, string uniformName, int number)
        {
            Name = name;
            XPosition = xPosition;
            YPosition = yPosition;
            UniformName = uniformName;
            Number = number;
            Radius = 50;
        }

        public void Move(PlayerInput playerInput)
        {
            List<float> positions = this.MovementMode.MoveDifferently(playerInput, Speed, XPosition, YPosition);
            SetPositions(positions);
        }

        public void SetPositions (List<float> positions)
        {
            if (positions.Count == 2)
            {
                this.XPosition = positions[0];
                this.YPosition = positions[1];
            }
        }

        public void UpdatePosition(PlayerInput playerInput)
        {
            if (playerInput.ToWalk)
            {
                MovementMode = new Walk(); // slowest (1)
                Move(playerInput);
            }
            else if (playerInput.ToRun)
            {
                MovementMode = new Run(); // faster (3)
                Move(playerInput);
            }
            else if (playerInput.ToJump)
            {
                List<float> positions = invoker.DoJump(playerInput, Speed, XPosition, YPosition);
                SetPositions(positions);
                //MovementMode = new Jump(); // fastest (4)
            }
            else if (playerInput.ToUndo)
            {
                //Console.WriteLine("Doing");
                List<float> positions = invoker.Undo(playerInput, Speed, XPosition, YPosition);
                SetPositions(positions);
                //MovementMode = new Jump(); // fastest (4)
            }
            else
            {
                MovementMode = new Jog(); // normal (2)
                Move(playerInput);
            }
            
        }
        public override string ToString()
        {
            return string.Format("{0}, x:{1}, y:{2}", Name, XPosition, YPosition);
        }

        public OvalPictureBox Display(string teamColor)
        {
            OvalPictureBox pb = new OvalPictureBox();
            pb.Width = Radius;
            pb.Height = Radius;
            pb.BackColor = Color.FromName(teamColor);
            return pb;
        }
    }
}
