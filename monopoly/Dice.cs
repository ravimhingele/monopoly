using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly
{
    public class Dice
    {
        public int res1;
        public int res2;
        private int countOfRolls = 0;
        int val = 0;
        Random random = new Random();

        public int Roll(Player player)
        {
            Console.WriteLine(player.name + " rolls the dice:");
            res1 = random.Next(1, 7);
            PrintTheDice(res1);

            res2 = random.Next(1, 7);
            PrintTheDice(res2);

            countOfRolls++;
            val = res1 + res2;
            if (res1 == res2 && countOfRolls > 2)
            {
                player.IdRolls++;
            }
            if (res1 != res2 && countOfRolls > 2)
            {
                player.IdRolls = 0;
            }
            return val;
        }
        private void PrintTheDice(int res)
        {
            switch (res)
            {
                case 1:
                    
                    Console.WriteLine(" _______");
                    Console.WriteLine("|       |");
                    Console.WriteLine("|   O   |");
                    Console.WriteLine("|       |");
                    Console.WriteLine(" -------");
                    break;
                case 2:
                    Console.WriteLine(" _______");
                    Console.WriteLine("|    O  |");
                    Console.WriteLine("|       |");
                    Console.WriteLine("|  O    |");
                    Console.WriteLine(" -------");
                    break;
                case 3:
                    Console.WriteLine(" _______");
                    Console.WriteLine("| O     |");
                    Console.WriteLine("|   O   |");
                    Console.WriteLine("|     O |");
                    Console.WriteLine(" -------");
                    break;
                case 4:
                    Console.WriteLine(" _______");
                    Console.WriteLine("| O   O |");
                    Console.WriteLine("|       |");
                    Console.WriteLine("| O   O |");
                    Console.WriteLine(" -------");
                    break;
                case 5:
                    Console.WriteLine(" _______");
                    Console.WriteLine("| O   O |");
                    Console.WriteLine("|   O   |");
                    Console.WriteLine("| O   O |");
                    Console.WriteLine(" -------");
                    break;
                case 6:
                    Console.WriteLine(" _______");
                    Console.WriteLine("| O   O |");
                    Console.WriteLine("| O   O |");
                    Console.WriteLine("| O   O |");
                    Console.WriteLine(" -------");
                    break;
            }
        }
    }
}
