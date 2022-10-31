using opp_lib.AdapterMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Strategy
{
    public class Jump : MovementMode
    {
        private ITarget target = new MathAdapter();
        public float MakeRequest(float number)
        {
            float ans = target.Calculate(number, 'P');
            return ans;
        }
        public override List<float> MoveDifferently(PlayerInput playerInput, float speed, float xPosition, float yPosition)
        {
            List<float> positions = new List<float>();
            float pow = MakeRequest(speed);
            if (playerInput.Up)
            {
                yPosition -= pow;
            }
            else if (playerInput.Right)
            {
                xPosition += pow;
            }
            else if (playerInput.Down)
            {
                yPosition += pow;
            }
            else if (playerInput.Left)
            {
                xPosition -= pow;
            }

            positions.Add(xPosition);
            positions.Add(yPosition);
            return positions;
        }
    }
}
