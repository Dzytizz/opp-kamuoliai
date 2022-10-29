using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using opp_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace opp_client.Facade
{
    public class Facade
    {
        protected ThemeApplySubsystem ThemeApplySubsystem;
        protected InputSubsystem InputSubsystem;
        protected PlayerPositionUpdateSubsystem PlayerPositionUpdateSubsystem;

        public Facade()
        {
            ThemeApplySubsystem = new ThemeApplySubsystem();
            InputSubsystem = new InputSubsystem();
            PlayerPositionUpdateSubsystem = new PlayerPositionUpdateSubsystem();
        }

        public void ApplyTheme(Form form)
        {
            ThemeApplySubsystem.SetWindowTheme(form);
            ThemeApplySubsystem.UpdateSubControlColors(form);
        }

        public void ProcessMovement(ref PlayerInput playerInput, HubConnection connection, string playerID)
        {
            string playerInputJSON = InputSubsystem.ProcessInput(ref playerInput);
            PlayerPositionUpdateSubsystem.UpdatePlayerPositionRequest(connection, playerID, playerInputJSON);
        }
    }
}
