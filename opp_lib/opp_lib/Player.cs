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
        private Algorithm Algorithm { get; set; }

        public Player(string name, float xPosition, float yPosition)
        {
            Name = name;
            XPosition = xPosition;
            YPosition = yPosition;
        }

        public void Action(PlayerInput playerInput)
        {
            List<float> positions = this.Algorithm.BehaveDifferently(playerInput, Speed, XPosition, YPosition);
            if (positions.Count == 2)
            {
                XPosition = positions[0];
                YPosition = positions[1];
            }
        }

        public void UpdatePosition(PlayerInput playerInput)
        {
            if (playerInput.ToRun)
            {
                Algorithm = new Run();
            }
            else if (playerInput.ToJog)
            {
                Algorithm = new Jog();
            }
            else if (playerInput.ToJump)
            {
                Algorithm = new Jump();
            }
            else
            {
                Algorithm = new Walk();
            }
            Action(playerInput);
        }
        public override string ToString()
        {
            return string.Format("{0}, x:{1}, y:{2}", Name, XPosition, YPosition);
        }
    }
}
