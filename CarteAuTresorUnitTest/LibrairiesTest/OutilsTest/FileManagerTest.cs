﻿using System;
using CarteAuTresor.Librairie;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Collections.Generic;
using System.IO;

namespace CarteAuTresorUnitTest.LibrairiesTest
{
    [TestClass]
    public class FileManagerTest
    {
        //[TestMethod]
        //[DeploymentItem("\\EntreFileManagerTest.txt")]
        //public void FileReader_should_read_each_line()
        //{
        //    var filePath = "EntreFileManagerTest.txt";
        //    var fileManager = new FileManager(filePath);

        //    fileManager.FileReader();
            
        //    //fileManager.ConfigurationTable.Count.Should().Be(3);
        //    //fileManager.ConfigurationTable[0].Row.Count.Should().Be(3);
        //    //fileManager.ConfigurationTable[1].Row.Count.Should().Be(3);
        //    //fileManager.ConfigurationTable[2].Row.Count.Should().Be(4);


        //    string lineValue = "C-3-4";
        //    var splitLine = lineValue.Split('-');

        //    fileManager.GetMapConfiguration[0].GetElementAt(0).Should().Be(splitLine[0]);
        //    fileManager.GetMapConfiguration[0].GetElementAt(1).Should().Be(splitLine[1]);
        //    fileManager.GetMapConfiguration[0].GetElementAt(2).Should().Be(splitLine[2]);

        //    lineValue = "M-1-1";
        //    splitLine = lineValue.Split('-');

        //    fileManager.GetMapConfiguration[1].GetElementAt(0).Should().Be(splitLine[0]);
        //    fileManager.GetMapConfiguration[1].GetElementAt(1).Should().Be(splitLine[1]);
        //    fileManager.GetMapConfiguration[1].GetElementAt(2).Should().Be(splitLine[2]);

        //    lineValue = "C-3-2-2";
        //    splitLine = lineValue.Split('-');

        //    fileManager.GetMapConfiguration[2].GetElementAt(0).Should().Be(splitLine[0]);
        //    fileManager.GetMapConfiguration[2].GetElementAt(1).Should().Be(splitLine[1]);
        //    fileManager.GetMapConfiguration[2].GetElementAt(2).Should().Be(splitLine[2]);
        //    fileManager.GetMapConfiguration[2].GetElementAt(3).Should().Be(splitLine[3]);
        //}


        [TestMethod]
        [DeploymentItem("\\Sortie.txt")]
        public void FileWriteTest()
        {
            FileInfo fileInfo = new FileInfo("Sortie.txt");

            var listToWrite = new List<List<string>>();
            var line = new List<string>() { "C", "2", "3" };
            var line2 = new List<string>() { "C", "Test", "3" };

            listToWrite.Add(line);
            listToWrite.Add(line2);

            FileManager.FileTextWriter(listToWrite, fileInfo.DirectoryName);
        }
    }
}
