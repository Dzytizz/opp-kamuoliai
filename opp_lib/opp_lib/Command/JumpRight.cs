using opp_lib.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Command
{
    public class JumpRight : Command
    {
        Jump jump;
        PlayerInput playerInput;
        float speed;
        float xPosition;
        float yPosition;
        public JumpRight(Jump jump, PlayerInput playerInput, float speed, float xPosition, float yPosition)
        {
            this.jump = jump;
            this.playerInput = playerInput;
            this.speed = speed;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }
        public override List<float> Execute()
        {
            List<float> positions = jump.MoveDifferently(this.playerInput, this.speed, this.xPosition, this.yPosition);
            return positions;
        }

        public override List<float> Undo()
        {
            this.playerInput.Right = false;
            this.playerInput.Left = true;
            //List<float> positions = jump.MoveDifferently(this.playerInput, this.speed, this.xPosition, this.yPosition);
            List<float> positions = new List<float> { this.xPosition, this.yPosition };
            return positions;
        }
    }
}
