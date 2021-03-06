﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using PacMan;

namespace PacManTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void GivenABoardOf3x4_WhenTheGameStarts_TheBoardIsDisplayed()
        {
            var board = new Mock<IDisplayable>();

            var game = new Game(board.Object, It.IsAny<IWriteble>());

            game.Start();
            board.Verify(b => b.Displayed(It.IsAny<IWriteble>()), Times.Once);
            //  Assert.AreEqual(true, );
        }
    }
}
