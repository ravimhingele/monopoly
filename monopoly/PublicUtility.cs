using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly
{
    internal class PublicUtility : PropertySquare
    {
        public PublicUtility(string name)
        {
            Name = name;
            Price = 150;
        }
        public override void LandedOn(Player player, Board board)
        {
            // TODO: public utility
        }
    }
}
