using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsProbeCore;

namespace MarsProbe.Tests
{
    [TestFixture]
    class FileUtilTests
    {
        private string _path = "";

        [OneTimeSetUp]
        public void Init()
        {
            _path = @"C:\tmp\FileUtilUnitTestsFile.txt";
            List<string> lines = new List<string>
            {
                @"5;5",
                @"1;2;N",
                @"LMLMLMLMM",
                @"3;3;E",
                @"MMRMMRMRRM"
            };
            File.WriteAllLines(_path, lines);
        }

        [TearDown]
        public void Dispose()
        {
            _path = @"C:\tmp\FileUtilUnitTestsFile.txt";
            string[] lines = File.ReadAllLines(_path);
            lines[0] = @"5;5";
            File.WriteAllLines(_path, lines);
        }

        [Test]
        public void GetGridTest()
        {
            //Arrange
            FileUtil fileUtil = new FileUtil(_path);
            //Act
            Grid grid = fileUtil.GetGrid();
            //Assert
            Assert.AreEqual(5, grid.height, "Testing grid height");
            Assert.AreEqual(5, grid.width, "Testing grid width");
        }

        [Test]
        public void GetGridCachingTest()
        {
            //Arrange
            FileUtil fileUtil = new FileUtil(_path);

            //Act
            Grid grid = fileUtil.GetGrid();
            string[] lines = File.ReadAllLines(_path);
            lines[0] = @"2;2";
            File.WriteAllLines(_path, lines);
            Grid cacheGrid = fileUtil.GetGrid();

            //Assert
            Assert.AreEqual(5, grid.height, "Testing grid height first run");
            Assert.AreEqual(5, grid.width, "Testing grid width first run");

            Assert.AreEqual(5, cacheGrid.height, "Testing grid height second (cache) run");
            Assert.AreEqual(5, cacheGrid.width, "Testing grid width (cache) run");
        }

        [Test]
        public void GetProbesFromInputFileTest()
        {
            //Arrange
            FileUtil fileUtil = new FileUtil(_path);

            Position expectedPosition1 = new Position(1, 2, 'N');
            Grid expectedGrid1 = new Grid(5, 5);
            char[] expectedCommands1 = { 'L','M','L','M','L','M','L','M','M' };

            Position expectedPosition2 = new Position(3, 3, 'E');
            Grid expectedGrid2 = new Grid(5, 5);
            char[] expectedCommands2 = { 'M', 'M', 'R', 'M', 'M', 'R', 'M', 'R', 'R', 'M' };

            //Act
            List<Probe> resultProbes = fileUtil.GetProbesFromInputFile();

            //Assert
            Assert.AreEqual(expectedPosition1.YAxis, resultProbes[0].CurrentPosition.YAxis);
            Assert.AreEqual(expectedPosition1.XAxis, resultProbes[0].CurrentPosition.XAxis);
            Assert.AreEqual(expectedPosition1.CardinalPoint, resultProbes[0].CurrentPosition.CardinalPoint);

            Assert.AreEqual(expectedPosition2.YAxis, resultProbes[1].CurrentPosition.YAxis);
            Assert.AreEqual(expectedPosition2.XAxis, resultProbes[1].CurrentPosition.XAxis);
            Assert.AreEqual(expectedPosition2.CardinalPoint, resultProbes[1].CurrentPosition.CardinalPoint);

            Assert.AreEqual(expectedGrid1.height, resultProbes[0].Grid.height);
            Assert.AreEqual(expectedGrid1.width, resultProbes[0].Grid.width);

            Assert.AreEqual(expectedGrid2.height, resultProbes[1].Grid.height);
            Assert.AreEqual(expectedGrid2.width, resultProbes[1].Grid.width);

            Assert.That(resultProbes[0].CommandList, Is.EqualTo(expectedCommands1));
            Assert.That(resultProbes[1].CommandList, Is.EqualTo(expectedCommands2));
        }
    }
}
