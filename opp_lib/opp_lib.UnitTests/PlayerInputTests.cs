using Microsoft.VisualStudio.TestTools.UnitTesting;
using opp_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Tests
{
    [TestClass()]
    public class PlayerInputTests
    {
        private PlayerInput playerInput;

        [TestInitialize]
        public void CreatePlayerInput()
        {
            playerInput = new PlayerInput();
        }

        [TestMethod()]
        public void PlayerInput_UsesConstructorWithProperties_ValuesAreSetProperly()
        {
            PlayerInput playerInputWithValues = new PlayerInput(true, false, true, false, true, false, true, true, true, true);
            Assert.AreEqual(playerInputWithValues.Up, true);
            Assert.AreEqual(playerInputWithValues.Down, false);
            Assert.AreEqual(playerInputWithValues.Left, true);
            Assert.AreEqual(playerInputWithValues.Right, false);
            Assert.AreEqual(playerInputWithValues.ToRun, true);
            Assert.AreEqual(playerInputWithValues.ToWalk, false);
        }

        [TestMethod()]
        public void ResetJump_SetsToJumpTrueAndResets_ToJumpIsFalse()
        {
            playerInput.ToJump = true;
            playerInput.ResetJump();

            Assert.IsFalse(playerInput.ToJump);
        }

        [TestMethod()]
        public void ResetUndo_SetsToUndoTrueAndResets_ToUndoIsFalse()
        {
            playerInput.ToUndo = true;
            playerInput.ResetUndo();

            Assert.IsFalse(playerInput.ToUndo);
        }

        [TestMethod()]
        public void IsActive_ChecksIfNotActiveSetsValueAndChecksIfActive_NotActiveBeforeSetButActiveAfterSet()
        {
            Assert.IsFalse(playerInput.IsActive());
            playerInput.Left = true;
            Assert.IsTrue(playerInput.IsActive());
        }

        [TestMethod()]
        public void Clear_SetsValueAndTriesToClearIt_ValueIsFalse()
        {
            playerInput.Left = true;
            playerInput.Clear();
            Assert.IsFalse(playerInput.Left);
        }
    }
}