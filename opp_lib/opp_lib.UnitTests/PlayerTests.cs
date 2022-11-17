using Microsoft.VisualStudio.TestTools.UnitTesting;
using opp_lib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.Tests
{
    [TestClass()]
    public class PlayerTests
    {
        private Player player;

        [TestInitialize]
        public void CreatePlayer()
        {
            player = new Player("Test", 0, 0, "Test", 0);
        }

        [DataRow(1f, 2f)]
        [DataRow(10f, 20f)]
        [DataTestMethod()]
        public void SetPositions_SetsPositionsUsingList_PlayerPositionMatchesPositionsListValues(float position1, float position2)
        {
            List<float> positions = new List<float>() { position1, position2 };

            player.SetPositions(positions);

            Assert.AreEqual(player.XPosition, position1);
            Assert.AreEqual(player.YPosition, position2);
        }

        [TestMethod()]
        public void SetPositions_SetsOnly1Position_PlayerPositionsDontChange()
        {
            float startX = player.XPosition;
            float startY = player.YPosition;

            List<float> positions = new List<float>() { 15f };

            player.SetPositions(positions);

            Assert.AreEqual(player.XPosition, startX);
            Assert.AreEqual(player.YPosition, startY);
        }

        [DataRow(true, false ,false, false)]
        [DataRow(false, true, false, false)]
        [DataRow(false, false, true, false)]
        [DataRow(false, false, false, true)]
        [DataRow(true, false, true ,false)]
        [DataRow(true, false, false, true)]
        [DataRow(false, true, true, false)]
        [DataRow(false, true, false, true)]
        [DataTestMethod()]
        public void UpdatePosition_TestsWalkCalculation_CalculatedValuesMatchExpectedValues(bool up, bool down, bool right, bool left)
        {
            PlayerInput input = new PlayerInput();

            input.Up = up;
            input.Down = down;
            input.Right = right;
            input.Left = left;
            input.ToWalk = true;

            player.UpdatePosition(input);

            // movement calculation
            float speed = player.Speed;
            float newX = -1, newY = -1;
            int horizontalMultiplier = 0, verticalMultiplier = 0;
            if (input.Left) horizontalMultiplier = -1;
            if (input.Right) horizontalMultiplier = 1;
            if (input.Up) verticalMultiplier = -1;
            if (input.Down) verticalMultiplier = 1;
            if (input.IsPlusMovement())
            {
                newX = (speed / 2) * horizontalMultiplier;
                newY = (speed / 2) * verticalMultiplier;
            }
            else if (input.isDiagonalMovement())
            {
                newX = (float)Math.Sqrt(speed)/2 * horizontalMultiplier;
                newY = (float)Math.Sqrt(speed)/2 * verticalMultiplier;
            }

            Assert.AreEqual(player.XPosition, newX, 0.001);
            Assert.AreEqual(player.YPosition, newY, 0.001);
        }

        [DataRow(true, false, false, false)]
        [DataRow(false, true, false, false)]
        [DataRow(false, false, true, false)]
        [DataRow(false, false, false, true)]
        [DataRow(true, false, true, false)]
        [DataRow(true, false, false, true)]
        [DataRow(false, true, true, false)]
        [DataRow(false, true, false, true)]
        [DataTestMethod()]
        public void UpdatePosition_TestsRunCalculation_CalculatedValuesMatchExpectedValues(bool up, bool down, bool right, bool left)
        {
            PlayerInput input = new PlayerInput();

            input.Up = up;
            input.Down = down;
            input.Right = right;
            input.Left = left;
            input.ToRun = true;

            player.UpdatePosition(input);

            // movement calculation
            float speed = player.Speed;
            float newX = -1, newY = -1;
            int horizontalMultiplier = 0, verticalMultiplier = 0;
            if (input.Left) horizontalMultiplier = -1;
            if (input.Right) horizontalMultiplier = 1;
            if (input.Up) verticalMultiplier = -1;
            if (input.Down) verticalMultiplier = 1;
            if (input.IsPlusMovement())
            {
                newX = (speed * 2) * horizontalMultiplier;
                newY = (speed * 2) * verticalMultiplier;
            }
            else if (input.isDiagonalMovement())
            {
                newX = (float)Math.Sqrt(speed) * 2 * horizontalMultiplier;
                newY = (float)Math.Sqrt(speed) * 2 * verticalMultiplier;
            }

            Assert.AreEqual(player.XPosition, newX, 0.001);
            Assert.AreEqual(player.YPosition, newY, 0.001);
        }


        [DataRow(true, false, false, false)]
        [DataRow(false, true, false, false)]
        [DataRow(false, false, true, false)]
        [DataRow(false, false, false, true)]
        [DataTestMethod()]
        public void UpdatePosition_TestsJumpCalculation_CalculatedValuesMatchExpectedValues(bool up, bool down, bool right, bool left)
        {
            PlayerInput input = new PlayerInput();

            input.Up = up;
            input.Down = down;
            input.Right = right;
            input.Left = left;
            input.ToJump = true;

            player.UpdatePosition(input);

            // movement calculation
            float speed = player.Speed;
            float newX = -1, newY = -1;
            int horizontalMultiplier = 0, verticalMultiplier = 0;
            if (input.Left) horizontalMultiplier = -1;
            if (input.Right) horizontalMultiplier = 1;
            if (input.Up) verticalMultiplier = -1;
            if (input.Down) verticalMultiplier = 1;

            newX = (speed * speed) * horizontalMultiplier;
            newY = (speed * speed) * verticalMultiplier;
       
            Assert.AreEqual(player.XPosition, newX, 0.001);
            Assert.AreEqual(player.YPosition, newY, 0.001);
        }


        [DataRow(true, false, false, false)]
        [DataRow(false, true, false, false)]
        [DataRow(false, false, true, false)]
        [DataRow(false, false, false, true)]
        [DataRow(true, false, true, false)]
        [DataRow(true, false, false, true)]
        [DataRow(false, true, true, false)]
        [DataRow(false, true, false, true)]
        [DataTestMethod()]
        public void UpdatePosition_TestsJogCalculation_CalculatedValuesMatchExpectedValues(bool up, bool down, bool right, bool left)
        {
            PlayerInput input = new PlayerInput();

            input.Up = up;
            input.Down = down;
            input.Right = right;
            input.Left = left;

            player.UpdatePosition(input);

            // movement calculation
            float speed = player.Speed;
            float newX = -1, newY = -1;
            int horizontalMultiplier = 0, verticalMultiplier = 0;
            if (input.Left) horizontalMultiplier = -1;
            if (input.Right) horizontalMultiplier = 1;
            if (input.Up) verticalMultiplier = -1;
            if (input.Down) verticalMultiplier = 1;
            if (input.IsPlusMovement())
            {
                newX = (speed) * horizontalMultiplier;
                newY = (speed) * verticalMultiplier;
            }
            else if (input.isDiagonalMovement())
            {
                newX = (float)Math.Sqrt(speed) * horizontalMultiplier;
                newY = (float)Math.Sqrt(speed) * verticalMultiplier;
            }

            Assert.AreEqual(player.XPosition, newX, 0.001);
            Assert.AreEqual(player.YPosition, newY, 0.001);
        }

        [TestMethod()]
        public void Display_GeneratesBasePlayerObject_OvalPictureBoxWithTeamColorBackground()
        {
            string teamColor = "Red";
            OvalPictureBox opb = player.Display(teamColor);
            Assert.AreEqual(opb.BackColor, Color.FromName(teamColor));
        }
    }
}