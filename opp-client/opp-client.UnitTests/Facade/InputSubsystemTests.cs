using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using opp_client.Facade;
using opp_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_client.Facade.Tests
{
    [TestClass()]
    public class InputSubsystemTests
    {
        [TestMethod()]
        public void ProcessInput_CreatesInputAndCallsProcessInput_ReturnsJSONOfPlayerInput()
        {
            InputSubsystem inputSubsystem = new InputSubsystem();
            PlayerInput input = new PlayerInput();
            input.Down = true;
            string inputJSON = inputSubsystem.ProcessInput(ref input);

            Assert.AreEqual(inputJSON, "{\"Up\":false,\"Down\":true,\"Left\":false,\"Right\":false,\"ToRun\":false,\"ToWalk\":false,\"ToJump\":false,\"ToUndo\":false,\"ToJumpKeyUp\":true,\"ToUndoKeyUp\":true}");
        }
    }
}