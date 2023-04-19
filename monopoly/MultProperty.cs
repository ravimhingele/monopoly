using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly
{
    internal class MultProperty : PropertySquare
    {
        public string Color;
        //public string[] buildings = new string[4];

        public MultProperty(string name, int price, string color)
        {
            this.Name = name;
            this.Price = price;
            this.Color = color;
        }
        public override void LandedOn(Player player, Board board)
        {
            if (this.owner == player)
            {
                Console.WriteLine("The player owns this property.");
                return; //TODO: как-нибудь преобразовать эту солянку из if'ов
            }
            if (!this.isOwned && player.Money >= this.Price)
            {
                Console.WriteLine(player.name + " bought " + this.Name + ": -$" + this.Price);
                player.Money -= this.Price;
                player.property.AddLast(this);
                this.isOwned = true;
                this.owner = player;
                return;
            }
            else if (!this.isOwned && player.Money < this.Price)
            {
                Console.WriteLine("Not enough money to buy."); 
                //TODO: если не хватает денег, надо продать свою собственность (только продавать по-умному)
                return;
            }
            if (this.isOwned && player.Money >= this.Price)
            {
                Console.WriteLine("This property is already bought.");
                Console.WriteLine("The player pays the rent to the owner: $" + this.Price);
                this.owner.Money += this.Price;
                player.Money -= this.Price;
            }
            else
            {
                Console.WriteLine("Not enough money to pay the rent.");
                //TODO: хватает денег - продать свою собственность
            }

            //TODO: MultProperty
        }
    }
}
