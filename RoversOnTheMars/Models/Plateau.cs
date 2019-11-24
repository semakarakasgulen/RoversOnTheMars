using RoversOnTheMars.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoversOnTheMars.Models
{
    public class Plateau
    {
        public Position UpperRightCoordinates;
        public Guid Id;

        public Plateau(int upperAxisX, int upperAxisY)
        {
            UpperRightCoordinates = new Position(upperAxisX, upperAxisY);
            Id = Guid.NewGuid();
        }

        ~Plateau()
        {
            Console.WriteLine(Messages.PlateauDetroyed, Id.ToString());
        }
    }
}
