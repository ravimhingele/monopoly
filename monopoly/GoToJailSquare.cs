using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly
{
    internal class GoToJailSquare : Square
    {
        public GoToJailSquare()
        {
            Name = "Go to Jail";
        }
        public override void LandedOn(Player player, Board board)
        {
            Console.WriteLine(player.name + " landed on the unlucky square.");
            player.GoesToJail(board);
        }
    }
}
