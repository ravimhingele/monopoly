using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace monopoly
{
    public class Board
    {
        //private static int size = 0; //задать количество клеток
        //public Square[] board = new Square[size];

        public LinkedList<Square> squares;
        public LinkedListNode<Square> JailSquare = new LinkedListNode<Square>(new Jail());
        public int numOfSquares;

        public Board()
        {
            squares = new LinkedList<Square>();
            squares.AddLast(new GoSquare());
            squares.AddLast(new MultProperty("Medditerranean Avenue", 60, "brown"));
            squares.AddLast(new MultProperty("Baltic Avenue", 60, "brown"));
            squares.AddLast(new TaxSquare("Income Tax", 200));
            squares.AddLast(new RailwayStationSquare("Reading Railroad"));
            squares.AddLast(new MultProperty("Oriental Avenue", 100, "light blue"));
            squares.AddLast(new MultProperty("Vermont Avenue", 100, "light blue"));
            squares.AddLast(new MultProperty("Connecticut Avenue", 120, "light blue"));
            squares.AddLast(JailSquare);
            squares.AddLast(new MultProperty("St. Charles Place", 140, "pink"));
            squares.AddLast(new PublicUtility("Electric company"));
            squares.AddLast(new MultProperty("States Avenue", 140, "pink"));
            squares.AddLast(new MultProperty("Virginia Avenue", 160, "pink"));
            squares.AddLast(new RailwayStationSquare("Pennsylvania Railroad"));
            squares.AddLast(new MultProperty("St. James Place", 180, "orange"));
            squares.AddLast(new MultProperty("Tennessee Avenue", 180, "orange"));
            squares.AddLast(new MultProperty("New York Avenue", 200, "orange"));
            squares.AddLast(new FreeParking());
            squares.AddLast(new MultProperty("Kentucky Avenue", 220, "red"));
            squares.AddLast(new MultProperty("Indiana Avenue", 220, "red"));
            squares.AddLast(new MultProperty("Illinois Avenue", 240, "red"));
            squares.AddLast(new RailwayStationSquare("B. & O. Railroad"));
            squares.AddLast(new MultProperty("Atlantic Avenue", 260, "yellow"));
            squares.AddLast(new MultProperty("Ventnor Avenue", 260, "yellow"));
            squares.AddLast(new PublicUtility("Water works"));
            squares.AddLast(new MultProperty("Marvin Gardens", 280, "yellow"));
            squares.AddLast(new GoToJailSquare());
            squares.AddLast(new MultProperty("Pacific Avenue", 300, "green"));
            squares.AddLast(new MultProperty("North Carolina Avenue", 300, "green"));
            squares.AddLast(new MultProperty("Pennsylvania Avenue", 320, "green"));
            squares.AddLast(new RailwayStationSquare("Short Line"));
            squares.AddLast(new MultProperty("Park Place", 350, "blue"));
            squares.AddLast(new TaxSquare("Luxury Tax", 100));
            squares.AddLast(new MultProperty("Boardwalk", 400, "blue"));
            numOfSquares = squares.Count;
        }


        public static int Draw(Dice dice, Player[] players) // Жеребьёвка
        { //TODO: если совпадает сумма, выпавшва на кубиках?
            Console.WriteLine("Two players in the game. Who will make the first move?");

            Thread.Sleep(800);
            //Console.WriteLine("Player 1 rolls the dice:");
            int f = dice.Roll(players[0]);
            //Console.WriteLine("Player 2 rolls the dice:");
            Thread.Sleep(800);
            int g = dice.Roll(players[1]);


            Thread.Sleep(500);
            if (f > g)
            {
                Console.WriteLine(players[0].name + " GOES FIRST!");
                //Thread.Sleep(900); // TODO: правильно ли устроена задержка по времени? Может надо ее в Program записать?
                return 0;
            }
            else
            {
                Console.WriteLine(players[1].name + " GOES FIRST!");
                //Thread.Sleep(900);
                return 1;
            }
        }
    }
}
