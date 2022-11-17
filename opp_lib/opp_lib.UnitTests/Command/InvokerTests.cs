using Microsoft.VisualStudio.TestTools.UnitTesting;
using opp_lib.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Command.Tests
{
    [TestClass()]
    public class InvokerTests
    {
        private Invoker invoker;
        private PlayerInput input;

        [TestInitialize]
        public void CreateInvokerAndPlayer()
        {
            invoker = new Invoker();
            input = new PlayerInput();
        }

        [DataRow(true, false, false, false)]
        [DataRow(false, true, false, false)]
        [DataRow(false, false, true, false)]
        [DataRow(false, false, false, true)]
        [DataTestMethod]
        public void Undo_JumpsTwiceReturnsOnce_ReturnPositionShouldBeFirstJumpPosition(bool up, bool down, bool left, bool right)
        {
            input.Up = up;
            input.Down = down;
            input.Left = left;
            input.Right = right;

            float speed = 5;
            List<float> positions = invoker.DoJump(input, speed, 0, 0);
            float oldX = positions[0];
            float oldY = positions[1];
            positions = invoker.DoJump(input, speed, oldX, oldY);
            positions = invoker.Undo(input, speed, positions[0], positions[1]);

            Assert.AreEqual(positions[0], oldX);
            Assert.AreEqual(positions[1], oldY);
        }

        [DataRow(true, false, false, false)]
        [DataRow(false, true, false, false)]
        [DataRow(false, false, true, false)]
        [DataRow(false, false, false, true)]
        [DataTestMethod()]
        public void DoJump_JumpsInAllDirections_CalculatedPositionsMatchActualJumpPositions(bool up, bool down, bool left, bool right)
        {
            input.Up = up;
            input.Down = down;
            input.Left = left;
            input.Right = right;

            // calculation
            float speed = 5;
            float newX = -1, newY = -1;
            int horizontalMultiplier = 0, verticalMultiplier = 0;
            if (input.Left) horizontalMultiplier = -1;
            if (input.Right) horizontalMultiplier = 1;
            if (input.Up) verticalMultiplier = -1;
            if (input.Down) verticalMultiplier = 1;
            newX = (speed * speed) * horizontalMultiplier;
            newY = (speed * speed) * verticalMultiplier;

            List<float> positions = invoker.DoJump(input, speed, 0 ,0);

            Assert.AreEqual(positions[0], newX);
            Assert.AreEqual(positions[1], newY);
        }
    }
}