using System;
using LWareTest.Enums;
using LWareTest.Exceptions;
using LWareTest.Interfaces;
using LWareTest.Models;
using LWareTest.Objects;

namespace LWareTest.Services
{
    public class LwRoverService: ILwRoverService
    {
        private readonly LwRover _rover;
        public LwRoverService()
        {
            _rover = new LwRover();
        }
        
        
        public PositionDetails GetPosition()
        {
            if (RoverCurrentPosition.CurrentDirection == 0)
            {
                SetInitialPosition();
            }
            var currentPosition = new PositionDetails(RoverCurrentPosition.CurrentDirection, RoverCurrentPosition.XPosition, RoverCurrentPosition.YPosition);
            currentPosition.CurrentDirectionValue = currentPosition.CurrentDirection.ToString();
            currentPosition.GridNumber = currentPosition.YPosition * -1 * _rover.GetParentSurface().Height +
                                         currentPosition.XPosition;
            currentPosition.LastStatusTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            return currentPosition;
        }

        public void UpdatePosition(string commands)
        {
            if (RoverCurrentPosition.CurrentDirection == 0)
            {
                SetInitialPosition();
            }
            var roverCommands = commands.Split(",");
            foreach (var command in roverCommands)
            {
                int n;
                if (int.TryParse(command, out n))
                {
                    if (n > _rover.GetParentSurface().Height || n > _rover.GetParentSurface().Width)
                    {
                        throw new OutOfBoundsException("Rover is out of parent surface");
                    }
                    MoveBy(n);
                } else
                {
                    TurnTo(Helpers.EnumHelper.ToEnum<Turns>(command));
                }
            }
        }
        
        public void SetInitialPosition()
        {
            RoverCurrentPosition.CurrentDirection = Directions.South;
            RoverCurrentPosition.XPosition = 1;
            RoverCurrentPosition.YPosition = 0;
            RoverCurrentPosition.CurrentDirectionValue = Directions.South.ToString();
        }

        private void MoveBy(int distance)
        {
            switch (RoverCurrentPosition.CurrentDirection)
            {
                case Directions.North:
                    RoverCurrentPosition.YPosition += distance;
                    break;
                case Directions.South:
                    RoverCurrentPosition.YPosition -= distance;
                    break;
                case Directions.West:
                    RoverCurrentPosition.XPosition -= distance;
                    break;
                case Directions.East:
                    RoverCurrentPosition.XPosition += distance;
                    break;
            }
        }

        private void TurnTo(Turns turnTo)
        {
            switch (RoverCurrentPosition.CurrentDirection)
            {
                case Directions.North:
                    RoverCurrentPosition.CurrentDirection = turnTo == Turns.Left ? Directions.West : Directions.East;
                    break;
                case Directions.South:
                    RoverCurrentPosition.CurrentDirection = turnTo == Turns.Left ? Directions.East : Directions.West;
                    break;
                case Directions.West:
                    RoverCurrentPosition.CurrentDirection = turnTo == Turns.Left ? Directions.South : Directions.North;
                    break;
                case Directions.East:
                    RoverCurrentPosition.CurrentDirection = turnTo == Turns.Left ? Directions.North : Directions.South;
                    break;
            }
        }

    }
}