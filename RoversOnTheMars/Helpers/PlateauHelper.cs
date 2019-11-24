using RoversOnTheMars.Constants;
using RoversOnTheMars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoversOnTheMars.Helpers
{
    public static class PlateauHelper
    {
        private static Plateau CreatePlateau(int axisX, int axisY)
        {
            var plateau = new Plateau(axisX, axisY);
            
            return plateau;
        }

        public static Plateau RetrievePlateauSizeAndCreatePlateau()
        {
            
            int axisX;
            int axisY;
            
            Console.WriteLine("Please enter the size of Plateau that you want to navigate. (Ex: 10 10) :");
            var plateauUpperRightCoordinates = Console.ReadLine();

            while(!ValidatePlatueSize(plateauUpperRightCoordinates, out axisX, out axisY))
            {
                Console.WriteLine("Please enter valid Plateau size. (Ex: 10 10) :");
                plateauUpperRightCoordinates = Console.ReadLine();
            }

            return CreatePlateau(axisX, axisY);
        }

        private static bool ValidatePlatueSize(string plateauSize, out int axisX, out int axisY)
        {
            var coordinates = plateauSize.Split(' ');
                
            if (!String.IsNullOrWhiteSpace(plateauSize) && coordinates.Length == 2 && int.TryParse(coordinates[0], out axisX) && int.TryParse(coordinates[1], out axisY))
            {
                if (axisX > 0 && axisY > 0)
                    return true;
                else
                    return false;
            }

            axisX = 0;
            axisY = 0;
            return false;
        }
    }
}
