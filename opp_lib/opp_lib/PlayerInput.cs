using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib
{
    public class PlayerInput
    {
        public bool Up { get; set; }
        public bool Down { get; set; }
        public bool Left { get; set; }
        public bool Right { get; set; }

        public PlayerInput(bool up, bool down, bool left, bool right)
        {
            Up = up;
            Down = down;
            Left = left;
            Right = right;
        }

        public PlayerInput()
        {
            Up = false;
            Down = false;
            Left = false;
            Right = false;
        }

        public bool IsActive()
        {
            return (Up || Down || Left || Right);
        }

        public void Clear()
        {
            Up = false; Down = false; Left = false; Right = false;
        }
    }
}
