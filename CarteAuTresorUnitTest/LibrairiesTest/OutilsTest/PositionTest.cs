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
            var position = new Position(1, 2);
            
            position.X.Should().Be(1);
            position.Y.Should().Be(2);

        }
    }
}
