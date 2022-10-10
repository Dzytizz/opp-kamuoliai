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
        public float Speed = 5;
        private Algorithm algorithm;

        public Player(string name, float xPosition, float yPosition)
        {
            Name = name;
            XPosition = xPosition;
            YPosition = yPosition;
        }

        public Algorithm getAlgorithm()
        {
            return algorithm;
        }

        public void SetAlgorithm(Algorithm algorithm)
        {
            this.algorithm = algorithm;
        }

        public void Action(PlayerInput playerInput)
        {
            List<float> positions = this.algorithm.BehaveDifferently(playerInput, Speed, XPosition, YPosition);
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
                SetAlgorithm(new Run());
            }
            else if (playerInput.ToJog)
            {
                SetAlgorithm(new Jog());
            }
            else if (playerInput.ToJump)
            {
                SetAlgorithm(new Jump());
            }
            else
            {
                SetAlgorithm(new Walk());
            }
            Action(playerInput);
        }

       /* public void UpdatePosition(PlayerInput playerInput)
        {
            if (playerInput.Up && playerInput.Right)
            {
                XPosition += Speed / 1.414f;
                YPosition -= Speed / 1.414f;
            }

            else if (playerInput.Down && playerInput.Right)
            {
                XPosition += Speed / 1.414f;
                YPosition += Speed / 1.414f;
            }

            else if (playerInput.Down && playerInput.Left)
            {
                XPosition -= Speed / 1.414f;
                YPosition += Speed / 1.414f;
            }

            else if (playerInput.Up && playerInput.Left)
            {
                XPosition -= Speed / 1.414f;
                YPosition -= Speed / 1.414f;
            }

            else if (playerInput.Up)
            {
                YPosition -= Speed;
            }

            else if (playerInput.Right)
            {
                XPosition += Speed;
            }

            else if (playerInput.Down)
            {
                YPosition += Speed;
            }

            else if (playerInput.Left)
            {
                XPosition -= Speed;
            }
        }*/

        public override string ToString()
        {
            return string.Format("{0}, x:{1}, y:{2}", Name, XPosition, YPosition);
        }
    }
}
