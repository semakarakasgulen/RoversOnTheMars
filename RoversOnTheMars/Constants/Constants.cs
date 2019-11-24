using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoversOnTheMars.Constants
{
    public static class Messages
    {
        public const string InvalidPlateauSize = "Provided plateau size is invalid. Please provide valid size.";
        public const string InvalidRoverProperties = "Provided rover properties are invalid. Please provide valid properties.";
        public const string InvalidRoverMovementCommand = "The command for the rover movement is invalid. Please enter the combination of L, R and M letters without space.";
        public const string InvalidRoverPosition = "Provided rover positions are invalid. Rover cannot start out of the plateau.";

        public const string RoverDetroyed = "Rover with id {0} is destroyed.";
        public const string PlateauDetroyed = "Plateau with id {0} is destroyed.";

        public const string RoverNotActive = "The Rover is not active.";
        public const string RoverLost = "Rover Lost in space. Lastest position of Rover is ({0}, {1}), {2}";
        public const string RoverFinalPosition = "Rover final position and direction are ({0}, {1}), {2}.";

    }

    public static class MovementCommands
    {
        public const char Left = 'L';
        public const char Right = 'R';
        public const char Move = 'M';
    }

    public static class Directions
    {
        public const char North = 'N';
        public const char South = 'S';
        public const char East = 'E';
        public const char West = 'W';
    }
}
