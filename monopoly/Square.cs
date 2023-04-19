using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly
{
    public abstract class Square
    {
        public string Name;

        public abstract void LandedOn(Player player, Board board);

        public virtual void GetBonus(Player player) { }
    }
}
