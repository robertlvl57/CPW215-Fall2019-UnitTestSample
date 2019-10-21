using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestingExample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingExample.Models.Tests
{
    [TestClass()]
    public class SimpleGameTests
    {
        [TestMethod()]
        [DataRow(0)]
        [DataRow(300)]
        [DataRow(150)]
        public void SetGame1_ValidScore_SetsValue(int initialScore)
        {
            SimpleGame g = new SimpleGame();

            g.Game1 = initialScore;

            Assert.AreEqual(initialScore, g.Game1);
        }

        [TestMethod]
        [DataRow(301)]
        [DataRow(-1)]
        [DataRow(null)]
        public void SetGame1_InvalidScore_ThrowsArgumentOutOfRangeException(int? score)
        {
            var g = new SimpleGame();

            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => g.Game1 = score);
        }

        [TestMethod]
        public void TotalScore_ReturnsSumOfAllGames()
        {
            var g = new SimpleGame();

            Assert.AreEqual(0, g.TotalScore);
            g.Game1 = 250;
            g.Game2 = 125;

            Assert.AreEqual(375, g.TotalScore);
        }
    }
}