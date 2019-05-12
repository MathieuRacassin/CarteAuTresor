using System;
using CarteAuTresor;
using CarteAuTresor.Librairie;
using CarteAuTresor.Librairie.Outils;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarteAuTresorUnitTest
{
    [TestClass]
    public class CarteTest
    {
        [TestMethod]
        public void ConstructeurTest()
        {
            var filePath = @"C:\Projects\CarteAuTresor\CarteAuTresorUnitTest\EntreCarteTest.txt";
            var fileManager = new FileManager(filePath);
            fileManager.FileReader();

            //var carte = new Carte(10,15);
            //carte.CreerCarteAuTresor();
            //carte.CarteAuTresor.Length.Should().Be(150);
            //carte.AxeHorizontale.Should().Be(15);
            //carte.AxeVerticale.Should().Be(10);

            ////var carte = Carte.ConfigurerCarteAuTresor(fileManager);
            //carte.CreerCarteAuTresor();
            //carte.ConfigurerMontagne(fileManager);
            //carte.ConfigurerTresor(fileManager);
            //carte.ConfigurerAventurier(fileManager);
        }

        [TestMethod]
        public void CreerCarteAuTresorTest()
        {
            var filePath = @"C:\Projects\CarteAuTresor\CarteAuTresorUnitTest\EntreCarteTest.txt";
            var fileManager = new FileManager(filePath);
            fileManager.FileReader();

            var carte = Carte.CreerCarteAuTresor(fileManager);

            carte.AxeHorizontale.Should().Be(10);
            carte.AxeVerticale.Should().Be(10);
            carte.CarteAuTresor.Should().NotBeNull();
            carte.CarteAuTresor.Length.Should().Be(100);
        }

        [TestMethod]
        public void ConfigurerCarteAuTresorTest()
        {
            var filePath = @"C:\Projects\CarteAuTresor\CarteAuTresorUnitTest\EntreCarteTest.txt";
            var fileManager = new FileManager(filePath);
            fileManager.FileReader();

            var carte = Carte.CreerCarteAuTresor(fileManager);
            carte.ConfigurerCarteAuTresor();

            foreach (var positionElement in carte.CarteAuTresor)
            {
                positionElement.IsPlaine.Should().BeTrue();
                positionElement.Plaine.Should().NotBeNull();
            }
        }

        [TestMethod]
        public void ConfigurerMontagneTest()
        {
            var filePath = @"C:\Projects\CarteAuTresor\CarteAuTresorUnitTest\EntreCarteTest.txt";
            var fileManager = new FileManager(filePath);
            fileManager.FileReader();

            var carte = Carte.CreerCarteAuTresor(fileManager);
            carte.ConfigurerCarteAuTresor();
            carte.ConfigurerMontagne(fileManager);

            carte.CarteAuTresor[2, 3].Montagne.Should().NotBeNull();
            carte.CarteAuTresor[2, 3].IsMontagne.Should().BeTrue();
        }

        [TestMethod]
        public void ConfigurerTresorTest()
        {
            var filePath = @"C:\Projects\CarteAuTresor\CarteAuTresorUnitTest\EntreCarteTest.txt";
            var fileManager = new FileManager(filePath);
            fileManager.FileReader();

            var carte = Carte.CreerCarteAuTresor(fileManager);
            carte.ConfigurerCarteAuTresor();
            carte.ConfigurerTresor(fileManager);

            carte.CarteAuTresor[4, 5].Tresor.Should().NotBeNull();
            carte.CarteAuTresor[4, 5].IsTresor.Should().BeTrue();
            carte.CarteAuTresor[4, 5].Tresor.NombreTresor.Should().Be(6);
        }

        [TestMethod]
        public void ConfigurerAventurierTest()
        {
            var filePath = @"C:\Projects\CarteAuTresor\CarteAuTresorUnitTest\EntreCarteTest.txt";
            var fileManager = new FileManager(filePath);
            fileManager.FileReader();

            var carte = Carte.CreerCarteAuTresor(fileManager);
            carte.ConfigurerCarteAuTresor();
            carte.ConfigurerAventurier(fileManager);

            carte.CarteAuTresor[1, 1].Aventurier.Should().NotBeNull();
            carte.CarteAuTresor[1, 1].Aventurier.Nom.Should().Be("Indiana");
            carte.CarteAuTresor[1, 1].Aventurier.Orientation.Should().Be(Orientation.Sud);
            carte.CarteAuTresor[1, 1].Aventurier.Sequence.Should().Be("AADADA");
            carte.CarteAuTresor[1, 1].Aventurier.NombreTour.Should().Be(6);
            carte.CarteAuTresor[1, 1].Aventurier.NombreTresor.Should().Be(0);
        }

    }
}
