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
        //public int Team { get; set; }

        public Player(string name, float xPosition, float yPosition)
        {
            Name = name;
            XPosition = xPosition;
            YPosition = yPosition;
        }

        public void UpdatePosition(PlayerInput playerInput)
        {
            if (playerInput.Up && playerInput.Right)
            {
                XPosition += Speed / 1.414f;
                YPosition -= Speed / 1.414f;
            }

            if (playerInput.Down && playerInput.Right)
            {
                XPosition += Speed / 1.414f;
                YPosition += Speed / 1.414f;
            }

            if (playerInput.Down && playerInput.Left)
            {
                XPosition -= Speed / 1.414f;
                YPosition += Speed / 1.414f;
            }

            if (playerInput.Up && playerInput.Left)
            {
                XPosition -= Speed / 1.414f;
                YPosition -= Speed / 1.414f;
            }

            if (playerInput.Up)
            {
                YPosition -= Speed;
            }

            if (playerInput.Right)
            {
                XPosition += Speed;
            }

            if (playerInput.Down)
            {
                YPosition += Speed;
            }

            if (playerInput.Left)
            {
                XPosition -= Speed;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, x:{1}, y:{2}", Name, XPosition, YPosition);
        }
    }
}
