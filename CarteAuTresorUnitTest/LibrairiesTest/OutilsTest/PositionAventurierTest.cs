using System;
using CarteAuTresor.Librairie;
using CarteAuTresor.Librairie.Outils;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarteAuTresorUnitTest.LibrairiesTest.OutilsTest
{
    [TestClass]
    public class PositionAventurierTest
    {
        [TestMethod]
        public void AvancerTest()
        {
            var positionAventurier = new PositionAventurier()
            {
                X = 15,
                Y = 17,
                Xmax = 20,
                Ymax = 30
            };

            positionAventurier.Avancer(Orientation.Nord);
            positionAventurier.Y.Should().Be(16);

            positionAventurier.Avancer(Orientation.Sud);
            positionAventurier.Y.Should().Be(17);

            positionAventurier.Avancer(Orientation.Est);
            positionAventurier.X.Should().Be(16);

            positionAventurier.Avancer(Orientation.Ouest);
            positionAventurier.X.Should().Be(15);

            positionAventurier = new PositionAventurier()
            {
                X = 15,
                Y = 17,
                Xmax = 20,
                Ymax = 30
            };

            positionAventurier.Gauche(Orientation.Nord);
            positionAventurier.X.Should().Be(14);

            positionAventurier.Gauche(Orientation.Sud);
            positionAventurier.X.Should().Be(15);

            positionAventurier.Gauche(Orientation.Est);
            positionAventurier.Y.Should().Be(16);

            positionAventurier.Gauche(Orientation.Ouest);
            positionAventurier.Y.Should().Be(17);

            positionAventurier = new PositionAventurier()
            {
                X = 15,
                Y = 17,
                Xmax = 20,
                Ymax = 30
            };

            positionAventurier.Droite(Orientation.Nord);
            positionAventurier.X.Should().Be(16);

            positionAventurier.Droite(Orientation.Sud);
            positionAventurier.X.Should().Be(15);

            positionAventurier.Droite(Orientation.Est);
            positionAventurier.Y.Should().Be(18);

            positionAventurier.Droite(Orientation.Ouest);
            positionAventurier.Y.Should().Be(17);

            positionAventurier = new PositionAventurier()
            {
                X = 15,
                Y = 17,
                Xmax = 20,
                Ymax = 30
            };

            positionAventurier.Reculer(Orientation.Nord);
            positionAventurier.Y.Should().Be(18);

            positionAventurier.Reculer(Orientation.Sud);
            positionAventurier.Y.Should().Be(17);

            positionAventurier.Reculer(Orientation.Est);
            positionAventurier.X.Should().Be(14);

            positionAventurier.Reculer(Orientation.Ouest);
            positionAventurier.X.Should().Be(15);



        }
    }
}
