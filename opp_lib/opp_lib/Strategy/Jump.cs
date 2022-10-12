using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Strategy
{
    public class Jump : MovementMode
    {
        public override List<float> MoveDifferently(PlayerInput playerInput, float speed, float xPosition, float yPosition)
        {
            List<float> positions = new List<float>();
            if (playerInput.Up)
            {
                yPosition -= speed * speed;
            }
            else if (playerInput.Right)
            {
                xPosition += speed * speed;
            }
            else if (playerInput.Down)
            {
                yPosition += speed * speed;
            }
            else if (playerInput.Left)
            {
                xPosition -= speed * speed;
            }

            positions.Add(xPosition);
            positions.Add(yPosition);
            return positions;
        }
    }
}
