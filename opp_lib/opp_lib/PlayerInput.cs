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
        public bool ToRun { get; set; }
        public bool ToWalk { get; set; }
        public bool ToJump { get; set; }
        public bool ToUndo { get; set; }
        public bool ToJumpKeyUp { get; set; }

        public PlayerInput(bool up, bool down, bool left, bool right, bool toRun, bool toWalk, bool toJump, bool toJumpKeyUp, bool toUndo)
        {
            Up = up;
            Down = down;
            Left = left;
            Right = right;
            ToRun = toRun;
            ToWalk = toWalk;
            ToJump = toJump;
            ToJumpKeyUp = toJumpKeyUp;
            ToUndo = toUndo;
        }
        public PlayerInput()
        {
            Up = false;
            Down = false;
            Left = false;
            Right = false;
            ToRun = false;
            ToWalk = false;
            ToJump = false;
            ToUndo = false;
            ToJumpKeyUp = true;
        }
        public void ResetJump()
        {
            if (ToJump) ToJump = false;
        }

        public bool IsActive()
        {
            return (Up || Down || Left || Right || ToUndo);
        }

        public void Clear()
        {
            Up = false; Down = false; Left = false; Right = false; ToRun = false; ToWalk = false; ToJump = false; ToUndo = false;
        }
    }
}
