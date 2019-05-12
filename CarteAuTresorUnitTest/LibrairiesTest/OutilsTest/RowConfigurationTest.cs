using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using CarteAuTresor.Librairie.Outils;

namespace CarteAuTresorUnitTest.LibrairiesTest.OutilsTest
{
    [TestClass]
    public class RowConfigurationTest
    {
        [TestMethod]
        public void ConstructeurTest()
        {
            var rowConfiguration = new RowConfiguration();

            rowConfiguration.Row.Should().NotBeNull();
        }
    }
}
