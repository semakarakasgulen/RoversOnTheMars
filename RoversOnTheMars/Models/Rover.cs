using RoversOnTheMars.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RoversOnTheMars.Models
{
    public class Rover
    {
        public Position RoverPosition;
        public char Direction;
        public Guid Id;
        public Plateau PlateauId;
        public bool IsActive;

        public Rover(int positionX, int positionY, char direction, Plateau plateauId)
        {
            Id = Guid.NewGuid();
            RoverPosition = new Position(positionX, positionY);
            Direction = direction;
            this.Land(plateauId);
            IsActive = true;
        }

        public Rover(int positionX, int positionY, char direction)
        {
            Id = Guid.NewGuid();
            RoverPosition = new Position(positionX, positionY);
            Direction = direction;
            IsActive = true;
        }

        public void Land(Plateau plateauId)
        {

            PlateauId = plateauId;
        }

        public void ExecuteMovementCommand(string command)
        {
            if (!Regex.IsMatch(command, @"^(L|R|M)+$"))
            {
                throw new Exception(Messages.InvalidRoverMovementCommand);
            }
            
            var movementCount = command.Length;
            int counter = 0;
            while (counter < movementCount)
            {
                if (!this.IsActive)
                {
                    return;
                }

                PerformSingleMovement(command[counter]);
                counter++;
            }
        }

        public void PerformSingleMovement(char command)
        {

            if (command == MovementCommands.Left)
            {
                TurnLeft();
            }
            else if (command == MovementCommands.Right)
            {
                TurnRigt();
            }
            else if (command == MovementCommands.Move)
            {
                MoveForward();
            }
        }

        private void TurnRigt()
        {
            if (this.Direction == Directions.North)
            {
                this.Direction = Directions.East;
            }

            else if (this.Direction == Directions.East)
            {
                this.Direction = Directions.South;
            }

            else if (this.Direction == Directions.South)
            {
                this.Direction = Directions.West;
            }

            else if (this.Direction == Directions.West)
            {
                this.Direction = Directions.North;
            }
        }

        private void TurnLeft()
        {
            if (this.Direction == Directions.North)
            {
                this.Direction = Directions.West;
            }

            else if (this.Direction == Directions.West)
            {
                this.Direction = Directions.South;
            }

            else if (this.Direction == Directions.South)
            {
                this.Direction = Directions.East;
            }

            else if (this.Direction == Directions.East)
            {
                this.Direction = Directions.North;
            }
        }

        private void MoveForward()
        {
            var currentPosition = new Position(this.RoverPosition.PositionX, this.RoverPosition.PositionY);

            if (this.Direction == Directions.North)
            {
                this.RoverPosition.PositionY += 1;
            }

            else if (this.Direction == Directions.South)
            {
                this.RoverPosition.PositionY -= 1;
            }

            else if (this.Direction == Directions.East)
            {
                this.RoverPosition.PositionX += 1;
            }

            else if (this.Direction == Directions.West)
            {
                this.RoverPosition.PositionX -= 1;
            }

            if (CheckIfRoverIsLost())
            {
                this.IsActive = false;
                this.RoverPosition = currentPosition;
            }
        }

        private bool CheckIfRoverIsLost()
        {
            var isRoverLost = false;
            if (this.RoverPosition.PositionX > this.PlateauId.UpperRightCoordinates.PositionX)
            {
                isRoverLost = true;
            }

            if (this.RoverPosition.PositionY > this.PlateauId.UpperRightCoordinates.PositionY)
            {
                isRoverLost = true;
            }

            return isRoverLost;
        }

        ~Rover()
        {
            Console.WriteLine(Messages.RoverDetroyed, Id.ToString());
        }
    }
}
