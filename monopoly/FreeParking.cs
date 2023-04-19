using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly
{
    internal class FreeParking : Square
    {
        public FreeParking()
        {
            Name = "Free Parking";
        }
        public override void LandedOn(Player player, Board board)
        {
            Console.WriteLine(player.name + " landed on the FREE PARKING!");
        }
    }
}
