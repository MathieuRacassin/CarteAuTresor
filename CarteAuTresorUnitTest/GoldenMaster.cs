using System;
using System.IO;
using CarteAuTresor;
using CarteAuTresor.Librairie;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarteAuTresorUnitTest
{
    [TestClass]
    public class GoldenMaster
    {
        [TestMethod]
        [DeploymentItem("\\Input.txt")]
        [DeploymentItem("\\Output.txt")]
        public void GoldenMasterTest()
        {
            FileManager fileManager = new FileManager("Input.txt");

            var configuration = fileManager.FileReader();

            var game = GameMap.Create(fileManager);

            game.InitializeElement(fileManager);
            game.Aventuriers.PlaySequences();

            Printer printer = new Printer(game);


            var expected = File.ReadAllText("Output.txt");

            printer.Print().Should().Be(expected);
        }
    }
}
