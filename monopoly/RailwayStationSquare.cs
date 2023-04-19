using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly
{
    internal class RailwayStationSquare : PropertySquare
    {
        public int multipalRR = 1;
        public RailwayStationSquare(string name)
        {
            this.Name = name;
            this.Price = 200;
        }
        public override void LandedOn(Player player, Board board)
        {
            if (isOwned == false)
            {
                player.Buy(this);
            }
            else if (owner != player)
            {
                multipalRR = 0;
                foreach (PropertySquare square in player.property)
                {
                    RailwayStationSquare prop;
                    try
                    {
                        prop = (RailwayStationSquare)square;
                        if (prop.owner != this.owner)
                        {
                            if (multipalRR == 0)
                                multipalRR = 1;
                            else
                                multipalRR *= 2;
                        }
                    }
                    catch { }
                }
                player.Pay(multipalRR * Price, owner);
            }
            else
            {
                Console.WriteLine("The player owns this property!");
            }
        }
    }
}
