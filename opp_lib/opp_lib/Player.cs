using opp_lib.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace opp_lib
{
    public class Player
    {
        public string Name { get; set; }
        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public float Speed { get; set; } = 5;
        private MovementMode MovementMode { get; set; }

        public Player(string name, float xPosition, float yPosition)
        {
            Name = name;
            XPosition = xPosition;
            YPosition = yPosition;
        }

        public void Move(PlayerInput playerInput)
        {
            List<float> positions = this.MovementMode.MoveDifferently(playerInput, Speed, XPosition, YPosition);
            if (positions.Count == 2)
            {
                XPosition = positions[0];
                YPosition = positions[1];
            }
        }

        public void UpdatePosition(PlayerInput playerInput)
        {
            if (playerInput.ToWalk)
            {
                MovementMode = new Walk(); // slowest (1)
            }
            else if (playerInput.ToRun)
            {
                MovementMode = new Run(); // faster (3)
            }
            else if (playerInput.ToJump)
            {
                MovementMode = new Jump(); // fastest (4)
            }
            else
            {
                MovementMode = new Jog(); // normal (2)
            }
            Move(playerInput);
        }
        public override string ToString()
        {
            return string.Format("{0}, x:{1}, y:{2}", Name, XPosition, YPosition);
        }
    }
}
