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
        int current = 0;

        public List<float> Undo (PlayerInput playerInput, float speed, float xPosition, float yPosition)
        {
            List<float> positions = new List<float>();
            if (current > 0)
            {
                Command command = commands[--current] as Command;
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
                current++;
            }
            else if (playerInput.Right)
            {
                Command command = new JumpUp(this.jump, playerInput, speed, xPosition, yPosition);
                positions = command.Execute();
                commands.Add(command);
                current++;
            }
            else if (playerInput.Down)
            {
                Command command = new JumpUp(this.jump, playerInput, speed, xPosition, yPosition);
                positions = command.Execute();
                commands.Add(command);
                current++;
            }
            else if (playerInput.Left)
            {
                Command command = new JumpUp(this.jump, playerInput, speed, xPosition, yPosition);
                positions = command.Execute();
                commands.Add(command);
                current++;
            }
            
            return positions;
        }
    }
}
