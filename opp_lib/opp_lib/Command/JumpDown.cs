using opp_lib.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Command
{
    public class JumpDown : Command
    {
        Jump jump;
        PlayerInput playerInput;
        float speed;
        float xPosition;
        float yPosition;
        public JumpDown(Jump jump, PlayerInput playerInput, float speed, float xPosition, float yPosition)
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
            this.playerInput.Up = true;
            this.playerInput.Down = false;
            List<float> positions = jump.MoveDifferently(this.playerInput, this.speed, this.xPosition, this.yPosition);
            return positions;
        }
    }
}
