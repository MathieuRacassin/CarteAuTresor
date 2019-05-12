using System;
using CarteAuTresor.Librairie;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Collections.Generic;

namespace CarteAuTresorUnitTest.LibrairiesTest
{
    [TestClass]
    public class FileManagerTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var filePath = @"C:\Projects\CarteAuTresor\CarteAuTresorUnitTest\EntreFileManagerTest.txt";
            var fileManager = new FileManager(filePath);


            fileManager.FilePath.Should().NotBeNull();
            fileManager.ConfigurationTable.Should().NotBeNull();
            fileManager.RowCount.Should().Be(3);
        }

        [TestMethod]
        public void FileReaderTest()
        {
            var filePath = @"C:\Projects\CarteAuTresor\CarteAuTresorUnitTest\EntreFileManagerTest.txt";
            var fileManager = new FileManager(filePath);

            var lineCount = fileManager.RowCount;

            fileManager.FileReader();
            
            fileManager.ConfigurationTable.Count.Should().Be(3);
            fileManager.ConfigurationTable[0].Row.Count.Should().Be(5);
            fileManager.ConfigurationTable[1].Row.Count.Should().Be(5);
            fileManager.ConfigurationTable[2].Row.Count.Should().Be(7);


            string c = "C-3-4";
            var characterArray = c.ToCharArray();

            fileManager.ConfigurationTable[0].Row[0].Should().Be(characterArray[0]);
            fileManager.ConfigurationTable[0].Row[1].Should().Be(characterArray[1]);
            fileManager.ConfigurationTable[0].Row[2].Should().Be(characterArray[2]);
            fileManager.ConfigurationTable[0].Row[3].Should().Be(characterArray[3]);
            fileManager.ConfigurationTable[0].Row[4].Should().Be(characterArray[4]);

            c = "M-1-1";
            characterArray = c.ToCharArray();

            fileManager.ConfigurationTable[1].Row[0].Should().Be(characterArray[0]);
            fileManager.ConfigurationTable[1].Row[1].Should().Be(characterArray[1]);
            fileManager.ConfigurationTable[1].Row[2].Should().Be(characterArray[2]);
            fileManager.ConfigurationTable[1].Row[3].Should().Be(characterArray[3]);
            fileManager.ConfigurationTable[1].Row[4].Should().Be(characterArray[4]);

            c = "C-3-2-2";
            characterArray = c.ToCharArray();

            fileManager.ConfigurationTable[2].Row[0].Should().Be(characterArray[0]);
            fileManager.ConfigurationTable[2].Row[1].Should().Be(characterArray[1]);
            fileManager.ConfigurationTable[2].Row[2].Should().Be(characterArray[2]);
            fileManager.ConfigurationTable[2].Row[3].Should().Be(characterArray[3]);
            fileManager.ConfigurationTable[2].Row[4].Should().Be(characterArray[4]);
            fileManager.ConfigurationTable[2].Row[5].Should().Be(characterArray[5]);
            fileManager.ConfigurationTable[2].Row[6].Should().Be(characterArray[6]);
        }

        [TestMethod]
        public void ExtraireStringTest()
        {
            string c = "Test-Extraire-String";
            var characterArray = new List<char>(c.ToCharArray());

            var result = FileManager.ExtraireString(characterArray);

            string[] value = { "Test", "Extraire", "String" };

            result.Count.Should().Be(3);
            result[0].Should().Be(value[0]);

            result[1].Should().Be(value[1]);

            result[2].Should().Be(value[2]);
        }

        [TestMethod]
        public void FileWriteTest()
        {
            var filePath = @"C:\Projects\CarteAuTresor\CarteAuTresorUnitTest\";

            var listToWrite = new List<List<string>>();
            var line = new List<string>() { "C", "2", "3" };
            var line2 = new List<string>() { "C", "Test", "3" };

            listToWrite.Add(line);
            listToWrite.Add(line2);

            FileManager.FileTextWriter(listToWrite, filePath);
        }
    }
}
