using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly
{
    internal class GoSquare : Square
    { 
        public GoSquare()
        {
            this.Name = "GO";
        }
        
        public override void LandedOn(Player player, Board board)
        {
            Console.WriteLine(player.name + " is on the Go square.");
        }

        public override void GetBonus(Player player)
        {
            player.Money += 200;
            Console.WriteLine(player.name + " gets a bonus!");
        }
    }
}
