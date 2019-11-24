using RoversOnTheMars.Constants;
using RoversOnTheMars.Helpers;
using RoversOnTheMars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoversOnTheMars
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("Welcome to the Mars...\n");

                var plateau = PlateauHelper.RetrievePlateauSizeAndCreatePlateau();
                
                var rover = RoverHelper.RetrieveRoverPropertiesAndCreateRover(plateau);
                ControlRoverAndWriteLastPosition(rover);

                var rover2 = RoverHelper.RetrieveRoverPropertiesAndCreateRover(plateau);
                ControlRoverAndWriteLastPosition(rover2);
                
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }
        }

        public static void ControlRoverAndWriteLastPosition(Rover rover)
        {
            Console.WriteLine("Please enter command for the Rover (Ex: LMRRM) :");
            var movementCommand = Console.ReadLine();
            rover.ExecuteMovementCommand(movementCommand);
            if (rover.IsActive)
            {
                Console.WriteLine(Messages.RoverFinalPosition, rover.RoverPosition.PositionX, rover.RoverPosition.PositionY, rover.Direction);
            }
            else
            {
                Console.WriteLine(string.Format(Messages.RoverLost, rover.RoverPosition.PositionX, rover.RoverPosition.PositionY, rover.Direction));
            }
            Console.WriteLine("\n");    
        }
    }
}
