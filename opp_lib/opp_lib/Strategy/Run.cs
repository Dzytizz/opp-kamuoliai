using opp_lib.AdapterMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Strategy
{

    public class Run : MovementMode
    {
        private ITarget target = new MathAdapter();
        public float MakeRequest(float number)
        {
            float ans = target.Calculate(number, 'M');
            return ans;
        }
        public override List<float> MoveDifferently(PlayerInput playerInput, float speed, float xPosition, float yPosition)
        {
            List<float> positions = new List<float>();
            float sqrtM = MakeRequest(speed);
            if (playerInput.Up && playerInput.Right)
            {
                xPosition += sqrtM;
                yPosition -= sqrtM;
            }
            else if (playerInput.Down && playerInput.Right)
            {
                xPosition += sqrtM;
                yPosition += sqrtM;
            }
            else if (playerInput.Down && playerInput.Left)
            {
                xPosition -= sqrtM;
                yPosition += sqrtM;
            }
            else if (playerInput.Up && playerInput.Left)
            {
                xPosition -= sqrtM;
                yPosition -= sqrtM;
            }

            else if (playerInput.Up)
            {
                yPosition -= speed * 2;
            }
            else if (playerInput.Right)
            {
                xPosition += speed * 2;
            }
            else if (playerInput.Down)
            {
                yPosition += speed * 2;
            }
            else if (playerInput.Left)
            {
                xPosition -= speed * 2;
            }

            positions.Add(xPosition);
            positions.Add(yPosition);
            return positions;
        }
    }
}
