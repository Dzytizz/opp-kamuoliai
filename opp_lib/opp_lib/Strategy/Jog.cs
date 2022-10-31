using opp_lib.AdapterMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Strategy
{
    public class Jog : MovementMode
    {

        private ITarget target = new MathAdapter();
        
        public float MakeRequest(float number)
        {
            float ans = target.Calculate(number, 'S');
            return ans;
        }
        public override List<float> MoveDifferently(PlayerInput playerInput, float speed, float xPosition, float yPosition)
        {
            List<float> positions = new List<float>();
            float sqrt = MakeRequest(speed);
            if (playerInput.Up && playerInput.Right)
            {
                xPosition += sqrt;
                yPosition -= sqrt;
            }
            else if (playerInput.Down && playerInput.Right)
            {
                xPosition += sqrt;
                yPosition += sqrt;
            }
            else if (playerInput.Down && playerInput.Left)
            {
                xPosition -= sqrt;
                yPosition += sqrt;
            }
            else if (playerInput.Up && playerInput.Left)
            {
                xPosition -= sqrt;
                yPosition -= sqrt;
            }

            else if (playerInput.Up)
            {
                yPosition -= speed;
            }
            else if (playerInput.Right)
            {
                xPosition += speed;
            }
            else if (playerInput.Down)
            {
                yPosition += speed;
            }
            else if (playerInput.Left)
            {
                xPosition -= speed;
            }

            positions.Add(xPosition);
            positions.Add(yPosition);
            return positions;
        }
    }
}
