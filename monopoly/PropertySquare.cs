using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly
{
    public class PropertySquare : Square
    {
        public int Price;
        public bool isOwned = false;
        public Player owner;
        

        public Player ownedBy { get; set; }
        public override void LandedOn(Player player, Board board) { }
    }
}
