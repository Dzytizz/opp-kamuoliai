using Newtonsoft.Json;
using opp_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_client.Facade
{
    public class InputSubsystem
    {
        public string ProcessInput(ref PlayerInput playerInput)
        {
            string playerInputJSON = JsonConvert.SerializeObject(playerInput);
            playerInput.ResetJump();
            playerInput.ResetUndo();
            return playerInputJSON;
        }
    }
}
