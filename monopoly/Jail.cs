using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly
{
    internal class Jail : Square
    {
        public Jail()
        {
            Name = "Jail";
        }
        
        public override void LandedOn(Player player, Board board)
        {
            if (player.isInJail == false)
            {
                Console.WriteLine(player.name + " is visiting someone in Jail.");
            }
        }
    }
}
