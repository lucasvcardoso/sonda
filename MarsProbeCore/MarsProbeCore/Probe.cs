using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProbeCore
{
    public class Probe
    {
        public Position InitialPosition { get; set; }
        public Position CurrentPosition { get; set; }

        public Probe(Position position)
        {
            InitialPosition = position;
            CurrentPosition = position;
        }

        public void Move()
        {
            switch (CurrentPosition.CardinalPoint)
            {
                case char cardinal when (CardinalPoints.North.Equals(cardinal)):
                    CurrentPosition.YAxis += 1;
                    break;
                case char cardinal when (CardinalPoints.South.Equals(cardinal)):
                    CurrentPosition.YAxis -= 1;
                    break;
                case char cardinal when (CardinalPoints.East.Equals(cardinal)):
                    CurrentPosition.XAxis += 1;
                    break;
                case char cardinal when (CardinalPoints.West.Equals(cardinal)):
                    CurrentPosition.XAxis -= 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Cardinal point invalid when trying to move.");
            }
        }

        public void Rotate(char rotationSense)
        {
            switch (rotationSense)
            {
                case char rotation when (rotation == RotationSense.Right):
                    if (CardinalPoints.North.Equals(CurrentPosition.CardinalPoint))
                    {
                        CurrentPosition.CardinalPoint = CardinalPoints.East;
                        break;
                    }
                    if (CardinalPoints.East.Equals(CurrentPosition.CardinalPoint))
                    {
                        CurrentPosition.CardinalPoint = CardinalPoints.South;
                        break;
                    }
                    if (CardinalPoints.South.Equals(CurrentPosition.CardinalPoint))
                    {
                        CurrentPosition.CardinalPoint = CardinalPoints.West;
                        break;
                    }
                    if (CardinalPoints.West.Equals(CurrentPosition.CardinalPoint))
                    {
                        CurrentPosition.CardinalPoint = CardinalPoints.North;
                        break;
                    }
                    break;
                case char rotation when (rotation == RotationSense.Left):
                    if (CardinalPoints.North.Equals(CurrentPosition.CardinalPoint))
                    {
                        CurrentPosition.CardinalPoint = CardinalPoints.West;
                        break;
                    }
                    if (CardinalPoints.East.Equals(CurrentPosition.CardinalPoint))
                    {
                        CurrentPosition.CardinalPoint = CardinalPoints.North;
                        break;
                    }
                    if (CardinalPoints.South.Equals(CurrentPosition.CardinalPoint))
                    {
                        CurrentPosition.CardinalPoint = CardinalPoints.East;
                        break;
                    }
                    if (CardinalPoints.West.Equals(CurrentPosition.CardinalPoint))
                    {
                        CurrentPosition.CardinalPoint = CardinalPoints.South;
                        break;
                    }
                    break;                
                default:
                    throw new ArgumentException("Rotation sense is invalid. Probe must rotate L for Left or R for Right");                   
            }
        }
    }
}
