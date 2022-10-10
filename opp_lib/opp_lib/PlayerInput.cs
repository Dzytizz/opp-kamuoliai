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
        public bool ToJog { get; set; }
        public bool ToRun { get; set; }
        public bool ToJump { get; set; }

        public PlayerInput(bool up, bool down, bool left, bool right, bool toJog, bool toRun, bool toJump)
        {
            Up = up;
            Down = down;
            Left = left;
            Right = right;
            ToJog = toJog;
            ToRun = toRun;
            ToJump = toJump;
        }

        public PlayerInput()
        {
            Up = false;
            Down = false;
            Left = false;
            Right = false;
            ToJog = false;
            ToRun = false;
            ToJump = false;
        }

        public bool IsActive()
        {
            return (Up || Down || Left || Right || ToJog || ToRun || ToJump);
        }

        public void Clear()
        {
            Up = false; Down = false; Left = false; Right = false; ToJog = false; ToRun = false; ToJump = false;
        }
    }
}
