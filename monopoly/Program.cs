using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace monopoly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.ForegroundColor = ConsoleColor.Magenta;

            Board board = new Board();
            Player[] players = new Player[2];
            players[0] = new Player("Player 1", board);
            players[1] = new Player("Player 2", board);

            
            Dice dice = new Dice();


            Program.WriteMonopoly();
            Thread.Sleep(800); 
            Console.WriteLine("Press any key to start..");
            Console.ReadKey();

            Console.Clear();

            int indOfPlayer = Board.Draw(dice, players); //получаем номер игрока, который должен ходить первым
            // изменение игрока: (numOfPlayer + 1) % 2

            Thread.Sleep(800);
            Console.WriteLine("Press any key to start the game..");
            Console.ReadKey();


            int numOfSteps;
            int countMoves = 1;
            

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Player 1:");
                Console.WriteLine("Money: $" + players[0].Money);
                Console.WriteLine("Position: " + players[0].Position.Value.Name);
                Console.WriteLine("Lucky pulls: " + players[0].IdRolls);
                Console.SetCursorPosition(70, 0);
                Console.WriteLine("Player 2:");
                Console.SetCursorPosition(70, 1);
                Console.WriteLine("Money: $" + players[1].Money);
                Console.SetCursorPosition(70, 2);
                Console.WriteLine("Position: " + players[1].Position.Value.Name);
                Console.SetCursorPosition(70, 3);
                Console.WriteLine("Lucky pulls: " + players[1].IdRolls);
                Console.ReadKey();
                Console.WriteLine();

                // проверяем в тюрьме ли игрок
                if (players[indOfPlayer].isInJail == true)
                {
                    players[indOfPlayer].isInJail = false;
                    indOfPlayer = (indOfPlayer + 1) % 2;
                    if (players[indOfPlayer].isInJail == false)
                        Console.WriteLine(players[indOfPlayer].name + " continues his move.");
                    else
                    {
                        players[indOfPlayer].isInJail = false;
                        indOfPlayer = (indOfPlayer + 1) % 2;
                        Console.WriteLine("Both players are in jail. Game continues.");
                    }
                }

                // Начинаем ход
                Console.WriteLine("Move " + countMoves + ":");
                countMoves++;
                numOfSteps = dice.Roll(players[indOfPlayer]);
                // Если игроку 3 раза подряд выпали одинаковые числа на кубиках, он идет в тюрьму
                if (players[indOfPlayer].IdRolls == 3)
                {
                    Console.WriteLine(players[indOfPlayer].name + " is too lucky.");
                    players[indOfPlayer].IdRolls = 0;
                    players[indOfPlayer].GoesToJail(board);
                    indOfPlayer = (indOfPlayer + 1) % 2;
                    continue; 
                }
                Console.WriteLine(players[indOfPlayer].name + " moves " +
                    numOfSteps + " steps forward.");
                while (numOfSteps > 0)
                {
                    if (players[indOfPlayer].Position.Next != null)
                    {
                        players[indOfPlayer].Position = players[indOfPlayer].Position.Next;
                        numOfSteps--;
                    }
                    else
                    {
                        players[indOfPlayer].Position = board.squares.First;
                        players[indOfPlayer].Position.Value.GetBonus(players[indOfPlayer]);
                        numOfSteps--;
                    }
                }
                Console.WriteLine(players[indOfPlayer].name + "'s position is " + players[indOfPlayer].Position.Value.Name);
                players[indOfPlayer].Position.Value.LandedOn(players[indOfPlayer], board);
                if (players[indOfPlayer].IdRolls != 0)
                {
                    Console.WriteLine("Player {0} is very lucky. He continues!", indOfPlayer + 1);
                }
                else
                {
                    indOfPlayer = (indOfPlayer + 1) % 2;
                }


                Console.ReadKey();
                //break;
            }
        }



        private static void WriteMonopoly()
        {
            Console.WriteLine(@" _    _                                  _        ");
            Console.WriteLine(@"| \  / |  __   _   _   __   ____    __  | | _   _ ");
            Console.WriteLine(@"| |\/| | /  \ | \ | | /  \ | ._ \  /  \ | || \_| |");
            Console.WriteLine(@"| |  | || () || |\| || () || |_) || () || | \__  |");
            Console.WriteLine(@"|_|  |_| \__/ |_| \_| \__/ | .__/  \__/ |_|  __| |");
            Console.WriteLine(@"                           |_|              |___/ ");
        }
    }
}
