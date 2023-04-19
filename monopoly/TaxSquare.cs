using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly
{
    internal class TaxSquare : Square
    {
        public int Tax;

        public TaxSquare(string name, int tax)
        {
            Name = name;
            Tax = tax;
        }

        public override void LandedOn(Player player, Board board)
        {
            player.Money -= this.Tax;
            Console.WriteLine(player.name + " paid the tax: - $" + this.Tax);
        }
    }
}
