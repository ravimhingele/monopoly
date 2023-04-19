using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly
{
    public class Player
    {
        public string name { get; set; }
        public int Money;
        public LinkedList<PropertySquare> property = new LinkedList<PropertySquare>(); //TODO: <Square>
        public LinkedListNode<Square> Position;
        public bool isInJail = false;
        public int IdRolls = 0; //количество раз, когда подряд выпало по 2 одинаковых числа на кубиках
        public bool isWinner = false;



        public Player() { }
        public Player (string name, Board board)
        {
            this.name = name;
            this.Position = board.squares.First;
            this.Money = 1500;
        }

        public void Pay(int summ, Player owner)
        { //TODO: несколько раз вызывать эту функцию, если игроку все еще не хватает денег
            if (this.Money >= summ)
            {
                this.Money -= summ;
                owner.Money += summ;
                Console.WriteLine();
            }
            else
            {
                int diff = summ - this.Money;
                int mindiff = 2000;
                PropertySquare toSell = new PropertySquare();
                foreach (PropertySquare square in this.property)
                {
                    if (square.Price >= diff && square.Price - diff < mindiff)
                    {
                        mindiff = square.Price - diff;
                        toSell = square;
                    }
                }
                if (toSell != null)
                {
                    Sell(toSell);
                    this.Money -= summ;
                }
                else
                    Console.WriteLine(this.name + "went bankrupt. Game over!");
                //TODO: окончание игры (отдельный класс игра с полем isOver), тогда игра будет заканчиваться 
            }
        }

        public void Buy(PropertySquare prop)
        {
            if (this.Money >= prop.Price)
            {
                property.AddLast(prop);
                Money -= prop.Price;
                prop.owner = this;
                prop.isOwned = true;
                Console.WriteLine(this.name + " bought " + prop.Name + ": -$" + prop.Price);
            }
        }

        public void Sell(PropertySquare square)
        {
            Money += square.Price;
            square.owner = null;
            square.isOwned = false;
            property.Remove(square);
        }

        public void GoesToJail(Board board)
        {
            Console.WriteLine("Goes to Jail!");
            Position = board.JailSquare;
            isInJail = true;
        }
    }
}
