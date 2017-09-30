﻿using NUnit.Framework;
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
            Probe probe = new Probe(new Position(0,0,'N'), new Grid(3,3));
            //Act
            probe.Rotate('L');
            //Assert
            Assert.AreEqual(CardinalPoints.West, probe.CurrentPosition.CardinalPoint, "Rotating left from North");
        }

        [Test]
        public void RotateTestNorthRight()
        {
            //Arrange
            Probe probe = new Probe(new Position(0, 0, 'N'), new Grid(3, 3));
            //Act
            probe.Rotate('R');
            //Assert
            Assert.AreEqual(CardinalPoints.East, probe.CurrentPosition.CardinalPoint, "Rotating right from North");
        }

        [Test]
        public void RotateTestInvalid()
        {
            //Arrange
            Probe probe = new Probe(new Position(0, 0, 'N'), new Grid(3, 3));
                       
            //Act and Assert
            Assert.Throws<ArgumentException>(delegate { probe.Rotate('B'); }, "Testing rotation to a direction that is not L or R");
        }

        [Test]
        public void MoveNorthTest()
        {
            //Arrange
            Probe probe = new Probe(new Position(0, 0, 'N'), new Grid(3, 3));

            //Act
            probe.Move();

            //Assert
            Assert.AreEqual(1, probe.CurrentPosition.YAxis, "Moving North");
        }

        [Test]
        public void MoveSouthTest()
        {
            //Arrange
            Probe probe = new Probe(new Position(0, 1, 'S'), new Grid(3, 3));

            //Act
            probe.Move();

            //Assert
            Assert.AreEqual(0, probe.CurrentPosition.YAxis, "Moving South");
        }

        [Test]
        public void MoveEastTest()
        {
            //Arrange
            Probe probe = new Probe(new Position(0, 0, 'E'), new Grid(3, 3));

            //Act
            probe.Move();

            //Assert
            Assert.AreEqual(1, probe.CurrentPosition.XAxis, "Moving East");
        }

        [Test]
        public void MoveWestTest()
        {
            //Arrange
            Probe probe = new Probe(new Position(1, 0, 'W'), new Grid(3, 3));

            //Act
            probe.Move();

            //Assert
            Assert.AreEqual(0, probe.CurrentPosition.YAxis, "Moving West");
        }

        [Test]
        public void MoveInvalid()
        {
            //Arrange
            Probe probe = new Probe(new Position(1, 0, 'B'), new Grid(3, 3));
           
            //Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(delegate { probe.Move(); }, "Moving to an invalid direction");
        }
    }
}
