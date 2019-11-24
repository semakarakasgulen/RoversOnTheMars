using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoversOnTheMars.Models;

namespace RoverOnTheMarsUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PlateauTest()
        {
            var plateau = new Plateau(5, 5);
            Assert.IsNotNull(plateau); 
        }

        [TestMethod]
        public void ControlRoverTest()
        {
            var expectedPositionXAfterMovement = 1;
            var expectedPositionYAfterMovement = 3;
            var expectedDirectionAfterMovement = 'N';
            var plateau = new Plateau(5, 5);
            var rover = new Rover(1, 2, 'N', plateau);
            rover.ExecuteMovementCommand("LMLMLMLMM");
            Assert.IsTrue(rover.IsActive);
            Assert.AreEqual(rover.RoverPosition.PositionX , expectedPositionXAfterMovement);
            Assert.AreEqual(rover.RoverPosition.PositionY , expectedPositionYAfterMovement);
            Assert.AreEqual(rover.Direction, expectedDirectionAfterMovement);
        }

        [TestMethod]
        public void ControlRoverTest2()
        {
            var expectedPositionXAfterMovement = 5;
            var expectedPositionYAfterMovement = 1;
            var expectedDirectionAfterMovement = 'E';
            var plateau = new Plateau(5, 5);
            var rover = new Rover(3, 3, 'E', plateau);
            rover.ExecuteMovementCommand("MMRMMRMRRM");
            Assert.IsTrue(rover.IsActive);
            Assert.AreEqual(rover.RoverPosition.PositionX, expectedPositionXAfterMovement);
            Assert.AreEqual(rover.RoverPosition.PositionY, expectedPositionYAfterMovement);
            Assert.AreEqual(rover.Direction, expectedDirectionAfterMovement);
        }

        [TestMethod]
        public void ControlRoverLostTest()
        {
            var expectedLastPositionXAfterMovement = 5;
            var expectedLastPositionYAfterMovement = 3;
            var expectedLastDirectionAfterMovement = 'E';
            var plateau = new Plateau(5, 5);
            var rover = new Rover(3, 3, 'E', plateau);
            rover.ExecuteMovementCommand("MMMRM");
            Assert.IsFalse(rover.IsActive);
            Assert.AreEqual(rover.RoverPosition.PositionX, expectedLastPositionXAfterMovement);
            Assert.AreEqual(rover.RoverPosition.PositionY, expectedLastPositionYAfterMovement);
            Assert.AreEqual(rover.Direction, expectedLastDirectionAfterMovement);
        }
    }
}
