using System;
using CarteAuTresor.Librairie;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarteAuTresorUnitTest.LibrairiesTest.OutilsTest
{
    [TestClass]
    public class PositionTest
    {
        [TestMethod]
        public void PositionClassTest()
        {
            var position = new Position()
            {
                X = 1,
                Y = 2
            };

            position.X.Should().Be(1);
            position.Y.Should().Be(2);

        }
    }
}
