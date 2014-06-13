using System;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PacMan;

namespace PacManTests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void GivenABoardOf3x4_ThenPacmanIsAt1X2()
        {
            Board board = new Board(3,4);

            Assert.AreEqual(new Position(1,2),board.PacmanPosition);
        }

      
        [TestMethod]
        public void GivenABoardOf6x6_ThenPacmanIsAtColum3()
        {
            Board board = new Board(6, 6);

            Assert.AreEqual(new Position(3,3), board.PacmanPosition);
        }
        [TestMethod]
        public void GivenABoardOf3x4_ThenPacmanLooksUp()
        {
            Board board = new Board(3, 4);

            Assert.AreEqual(Orientation.Up, board.PacmanOrientation);
        }
        [TestMethod]
        public void GivenAPacmanLookingUp_WhenTurnLeft_ThenPacmanLooksLeft()
        {
            Board board = new Board(3, 4);

            board.Turn(Orientation.Left);

            Assert.AreEqual(Orientation.Left, board.PacmanOrientation);
        }

        [TestMethod]
        public void GivenAPacmanLookingUp_WhenTurnRight_ThenPacmanLooksRight()
        {
            Board board = new Board(3,4);

            board.Turn(Orientation.Right);

            Assert.AreEqual(Orientation.Right, board.PacmanOrientation);
        }

        [TestMethod]
        public void GivenAPacmanLookingUp_WhenTurnDown_ThenPacmanLooksDown()
        {
            Board board = new Board(3, 4);

            board.Turn(Orientation.Down);

            Assert.AreEqual(Orientation.Down, board.PacmanOrientation);
        }
        [TestMethod]
        public void GivenAPacmanLookingUp_WhenTurnUp_ThenPacmanLooksUp()
        {
            Board board = new Board(3, 4);

            board.Turn(Orientation.Up);

            Assert.AreEqual(Orientation.Up, board.PacmanOrientation);
        }


        [TestMethod]
        public void GivenABoardOf3x4AndPacmanAt1x2LookingUp_WhenTurnLeftAndTick_ThenPacmanIsAt0x2()
        {
            //Arange
            Board board = new Board(3,4);

            //Act
            board.Turn(Orientation.Left);
            board.Tick();

            //Assert
            Assert.AreEqual(new Position(0,2), board.PacmanPosition);
        }


        [TestMethod]
        public void GivenABoardOf3x4AndPacmanAt1x2LookingUp_WhenTick_ThenPacmanIsAt1x1AndLooksUp()
        {
            //Arange
            Board board = new Board(3, 4);

            //Act
            board.Tick();

            //Assert
            Assert.AreEqual(new Position(1, 1), board.PacmanPosition);
        }

        [TestMethod]
        public void GivenABoardOf3x4AndPacmanAt1x2LookingUp_WhenTurnRightAndTick_ThenPacmanIsAt2x2()
        {
            //Arange
            Board board = new Board(3, 4);

            //Act
            board.Turn(Orientation.Right);
            board.Tick();

            //Assert
            Assert.AreEqual(new Position(2, 2), board.PacmanPosition);
        }

        [TestMethod]
        public void GivenABoardOf3x4AndPacmanAt1x2LookingUp_WhenTurnDownAndTick_ThenPacmanIsAt1x3()
        {
            //Arange
            Board board = new Board(3, 4);

            //Act
            board.Turn(Orientation.Down);
            board.Tick();

            //Assert
            Assert.AreEqual(new Position(1, 3), board.PacmanPosition);
        }

        [TestMethod]
        public void GivenABoardOf3x4AndPacmanAt1x0_WhenTick_ThenPacmanIsAt1x3()
        {
            //Arange
            Board board = new Board(3, 4);
            board.Tick();
            board.Tick();

            //Act
            board.Tick();

            //Assert
            Assert.AreEqual(new Position(1, 3), board.PacmanPosition);
        }

        [TestMethod]
        public void GivenABoardOf3x4AndPacmanAt1x3_WhenPackmanLooksDownTick_ThenPacmanIsAt1x0()
        {
            //Arange
            Board board = new Board(3, 4);
            board.Turn(Orientation.Down);
            board.Tick();

            //Act
            board.Tick();

            //Assert
            Assert.AreEqual(new Position(1, 0), board.PacmanPosition);
        }
        [TestMethod]
        public void GivenABoardOf3x4AndPacmanAt0x2_WhenPackmanLooksLeftTick_ThenPacmanIsAt2x2()
        {
            //Arange
            Board board = new Board(3, 4);
            board.Turn(Orientation.Left);
            board.Tick();

            //Act
            board.Tick();

            //Assert
            Assert.AreEqual(new Position(2, 2), board.PacmanPosition);
        }

        [TestMethod]
        public void GivenABoardOf3x4AndPacmanAt2x2_WhenPackmanLooksRightTick_ThenPacmanIsAt0x2()
        {
            //Arange
            Board board = new Board(3, 4);
            board.Turn(Orientation.Right);
            board.Tick();

            //Act
            board.Tick();

            //Assert
            Assert.AreEqual(new Position(0, 2), board.PacmanPosition);
        }

        [TestMethod]
        public void GivenABoardOf3x4_WhenTheBoardCallsDisplay_TheOutputIsRender()
        {

            Board board = new Board(3, 4);
            var console = new Mock<IWriteble>();
            board.Displayed(console.Object);
            console.Verify(c=>c.Write(". "),Times.Exactly(11));
            //  Assert.AreEqual(true, );
        }

    }
}
