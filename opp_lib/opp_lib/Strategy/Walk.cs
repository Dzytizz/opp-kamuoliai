﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Strategy
{
    public class Walk : MovementMode
    {
        public override List<float> MoveDifferently(PlayerInput playerInput, float speed, float xPosition, float yPosition)
        {
            List<float> positions = new List<float>();
            if (playerInput.Up && playerInput.Right)
            {
                xPosition += speed / 2 / 1.414f;
                yPosition -= speed / 2 / 1.414f;
            }
            else if (playerInput.Down && playerInput.Right)
            {
                xPosition += speed / 2 / 1.414f;
                yPosition += speed / 2 / 1.414f;
            }
            else if (playerInput.Down && playerInput.Left)
            {
                xPosition -= speed / 2 / 1.414f;
                yPosition += speed / 2 / 1.414f;
            }
            else if (playerInput.Up && playerInput.Left)
            {
                xPosition -= speed / 2 / 1.414f;
                yPosition -= speed / 2 / 1.414f;
            }

            else if (playerInput.Up)
            {
                yPosition -= speed / 2;
            }
            else if (playerInput.Right)
            {
                xPosition += speed / 2;
            }
            else if (playerInput.Down)
            {
                yPosition += speed / 2;
            }
            else if (playerInput.Left)
            {
                xPosition -= speed / 2;
            }

            positions.Add(xPosition);
            positions.Add(yPosition);
            return positions;
        }
    }
}
