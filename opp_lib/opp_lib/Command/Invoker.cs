using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using opp_lib.Strategy;

namespace opp_lib.Command
{
    public class Invoker
    {
        Jump jump = new Jump();
        List<Command> commands = new List<Command>();

        public List<float> Undo (PlayerInput playerInput, float speed, float xPosition, float yPosition)
        {
            List<float> positions = new List<float>();
            if(commands.Count > 0)
            {
                Command command = commands.Last();
                commands.Remove(command);

                positions = command.Undo();
            }
            return positions;
        }
        public List<float> DoJump(PlayerInput playerInput, float speed, float xPosition, float yPosition)
        {
            List<float> positions = new List<float>();
            if (playerInput.Up)
            {
                Command command = new JumpUp(this.jump, playerInput, speed, xPosition, yPosition);
                positions = command.Execute();
                commands.Add(command);
            }
            else if (playerInput.Right)
            {
                Command command = new JumpRight(this.jump, playerInput, speed, xPosition, yPosition);
                positions = command.Execute();
                commands.Add(command);
            }
            else if (playerInput.Down)
            {
                Command command = new JumpDown(this.jump, playerInput, speed, xPosition, yPosition);
                positions = command.Execute();
                commands.Add(command);
            }
            else if (playerInput.Left)
            {
                Command command = new JumpLeft(this.jump, playerInput, speed, xPosition, yPosition);
                positions = command.Execute();
                commands.Add(command);
            }
            
            return positions;
        }
    }
}
