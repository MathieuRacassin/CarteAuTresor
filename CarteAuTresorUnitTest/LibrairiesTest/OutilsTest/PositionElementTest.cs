﻿using System;
using CarteAuTresor.Librairie;
using CarteAuTresor.Librairie.Outils;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarteAuTresorUnitTest.LibrairiesTest.OutilsTest
{
    [TestClass]
    public class PositionElementTest
    {
        [TestMethod]
        public void ConstructeurTest()
        {
            var position = new Position()
            {
                X = 23,
                Y = 22,
            };

            var montagne = new Montagne(position);
            var positionElement = new PositionElement(montagne);

            positionElement.IsMontagne.Should().BeTrue();
            positionElement.Montagne.HasSamePosition(position).Should().BeTrue();

            positionElement = new PositionElement(position);
            positionElement.IsPlaine.Should().BeTrue();
            positionElement.Plaine.HasSamePosition(position).Should().BeTrue();

            var tresor = new Tresor(position, 2);

            positionElement = new PositionElement(tresor);
            positionElement.IsTresor.Should().BeTrue();
            positionElement.Tresor.HasSamePosition(position).Should().BeTrue();
            positionElement.Tresor.NombreTresor.Should().Be(2);

            var positionAventurier = new PositionAventurier()
            {
                X = 15,
                Y = 17,
                Xmax = 20,
                Ymax = 30
            };

            var aventurier = new Aventurier(positionAventurier, "le nom", "S", "ADADG", 0, 5);

            positionElement = new PositionElement(aventurier);
            positionElement.Aventurier.Should().BeSameAs(aventurier);
        }
    }
}
