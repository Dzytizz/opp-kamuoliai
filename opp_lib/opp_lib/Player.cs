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
using opp_lib.Chain_of_Responsibility;

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

        private MovementHandler MovementChain;

        public Player(string name, float xPosition, float yPosition, string uniformName, int number)
        {
            Name = name;
            XPosition = xPosition;
            YPosition = yPosition;
            UniformName = uniformName;
            Number = number;
            Radius = 50;

            // creation and setup of movement handler
            MovementHandler jog = new JogHandler(this);
            MovementHandler run = new RunHandler(this);
            MovementHandler jump = new JumpHandler(this);
            MovementHandler undo = new UndoHandler(this);
            MovementHandler walk = new WalkHandler(this);

            this.MovementChain = jog;
            jog.SetSuccessor(run.SetSuccessor(jump.SetSuccessor(undo.SetSuccessor(walk))));
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

        public Invoker GetInvoker()
        {
            return this.invoker;
        }

        public void SetMovementMode(MovementMode movementMode)
        {
            this.MovementMode = movementMode;
        }

        public void UpdatePosition(PlayerInput playerInput)
        {
            this.MovementChain.HandleMovementType(playerInput);
            //if (playerInput.ToWalk)
            //{
            //    MovementMode = new Walk(); // slowest (1)
            //    Move(playerInput);
            //}
            //else if (playerInput.ToRun)
            //{
            //    MovementMode = new Run(); // faster (3)
            //    Move(playerInput);
            //}
            //else if (playerInput.ToJump)
            //{
            //    List<float> positions = invoker.DoJump(playerInput, Speed, XPosition, YPosition);
            //    SetPositions(positions);
            //    //MovementMode = new Jump(); // fastest (4)
            //}
            //else if (playerInput.ToUndo)
            //{
            //    //Console.WriteLine("Doing");
            //    List<float> positions = invoker.Undo(playerInput, Speed, XPosition, YPosition);
            //    SetPositions(positions);
            //    //MovementMode = new Jump(); // fastest (4)
            //}
            //else
            //{
            //    MovementMode = new Jog(); // normal (2)
            //    Move(playerInput);
            //}
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
