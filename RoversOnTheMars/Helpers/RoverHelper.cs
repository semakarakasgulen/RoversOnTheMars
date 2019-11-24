using RoversOnTheMars.Constants;
using RoversOnTheMars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RoversOnTheMars.Helpers
{
    public static class RoverHelper
    {
        public static Rover CreateRover(int positionX,int positionY,char direction, Plateau plateau)
        {
            var rover = new Rover(positionX, positionY, direction, plateau);

            return rover;
        }

        public static Rover RetrieveRoverPropertiesAndCreateRover(Plateau plateau)
        {
            int axisX;
            int axisY;
            char? direction;

            Console.WriteLine("Please enter the position and the direction of Rover on the Platue. (Ex: 1 2 E) :");
            var roverProperties = Console.ReadLine();
            
            while (!ValidateRoverProperties(roverProperties, plateau, out axisX, out axisY, out direction))
            {
                Console.WriteLine("Please enter valid position and the direction of the Rover on the Platue. (Ex: 1 2 E) :");
                roverProperties = Console.ReadLine();
            }

            return CreateRover(axisX, axisY, (char)direction, plateau);
        }

        private static bool ValidateRoverProperties(string roverProperties, Plateau plateau, out int axisX, out int axisY, out char? direction)
        {
            axisX = 0;
            axisY = 0;
            direction = null;
            var properties = roverProperties.Split(' ');

            if (!String.IsNullOrWhiteSpace(roverProperties) && properties.Length == 3 
                && int.TryParse(properties[0], out axisX) && int.TryParse(properties[1], out axisY)
                && Regex.IsMatch(properties[2], @"^(W|E|N|S)$" ))
            {
                if (axisX <= plateau.UpperRightCoordinates.PositionX && axisY <= plateau.UpperRightCoordinates.PositionY)
                {
                    direction = properties[2][0];
                    
                    return true;
                }
                else
                {
                    Console.WriteLine(Messages.InvalidRoverPosition);
                    
                    return false;
                }
            }
            
            return false;
        }
    }
}
