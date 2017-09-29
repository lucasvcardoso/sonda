using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsProbeCore;

namespace MarsProbe.Tests
{
    [TestFixture]
    class ProbeTests
    {
        [Test]
        public void RotateTestNorthLeft()
        {
            //Arrange
            Probe probe = new Probe(new Position(0,0,'N'));
            //Act
            probe.Rotate('L');
            //Assert
            Assert.AreEqual(CardinalPoints.West, probe.CurrentPosition.CardinalPoint);
        }

        [Test]
        public void RotateTestNorthRight()
        {
            //Arrange
            Probe probe = new Probe(new Position(0, 0, 'N'));
            //Act
            probe.Rotate('R');
            //Assert
            Assert.AreEqual(CardinalPoints.East, probe.CurrentPosition.CardinalPoint);
        }

        [Test]
        public void RotateTestInvalid()
        {
            //Arrange
            Probe probe = new Probe(new Position(0, 0, 'N'));
            //Act
           
            //Assert
            Assert.Throws<ArgumentException>(delegate { probe.Rotate('B'); });
        }

        [Test]
        public void MoveNorthTest()
        {
            //Arrange
            Probe probe = new Probe(new Position(0, 0, 'N'));

            //Act
            probe.Move();

            //Assert
            Assert.AreEqual(1, probe.CurrentPosition.YAxis);
        }

        [Test]
        public void MoveSouthTest()
        {
            //Arrange
            Probe probe = new Probe(new Position(0, 1, 'S'));

            //Act
            probe.Move();

            //Assert
            Assert.AreEqual(0, probe.CurrentPosition.YAxis);
        }

        [Test]
        public void MoveEastTest()
        {
            //Arrange
            Probe probe = new Probe(new Position(0, 0, 'E'));

            //Act
            probe.Move();

            //Assert
            Assert.AreEqual(1, probe.CurrentPosition.XAxis);
        }

        [Test]
        public void MoveWestTest()
        {
            //Arrange
            Probe probe = new Probe(new Position(1, 0, 'W'));

            //Act
            probe.Move();

            //Assert
            Assert.AreEqual(0, probe.CurrentPosition.YAxis);
        }
    }
}
