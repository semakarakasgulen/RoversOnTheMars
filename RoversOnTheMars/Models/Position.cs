using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoversOnTheMars.Models
{
    public class Position
    {
        public int PositionX;
        public int PositionY;

        public Position(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }

        ~Position()
        {
        }
    }
}
