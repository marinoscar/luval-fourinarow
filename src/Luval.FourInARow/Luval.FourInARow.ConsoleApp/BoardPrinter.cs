using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luval.FourInARow.ConsoleApp
{
    public class BoardPrinter
    {
        protected Game Game { get; private set; }
        protected Board Board { get; private set; }

        public BoardPrinter(Game game)
        {
            Game = game;
            Board = Game.Board;
        }

        public void Start()
        {
            var player2 = false;
            BoardValue? winner = null;
            while (winner == null)
            {
                PrintBoard();
                Console.WriteLine("Player {0} enter column value", player2 ? "2" : "1");
                var val = Console.ReadLine();
                int col = 0;
                int.TryParse(val, out col);
                if (col < 1 || col > 7)
                {
                    WriteInRed("Value needs to be between 1 and 7");
                    Console.ReadKey();
                    continue;
                }
                try
                {
                    Game.Play(col - 1);
                }
                catch (BoardColumnFullException)
                {
                    WriteInRed("Column {0} is full, select another column", col);
                    Console.ReadKey();
                    continue;
                }
                player2 = !player2;
                winner = Game.CheckWinner();
            }
            PrintBoard();
            Console.WriteLine();
            if (winner == BoardValue.None)
            {
                WriteInColor(ConsoleColor.DarkYellow, "The game ended in a draw");
            }
            else
            {
                WriteInColor(ConsoleColor.DarkCyan, "You WON Player {0}", winner == BoardValue.Player1 ? "1" : "2");
            }
            Console.WriteLine();
        }

        private void WriteInRed(string format, params object[] args)
        {
            WriteInColor(ConsoleColor.Red, format, args);
        }

        private void WriteInColor(ConsoleColor color, string format, params object[] args)
        {
            var original = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(string.Format(format, args));
            Console.ForegroundColor = original;
        }

        public void PrintBoard()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("     [1] - [2] - [3] - [4] - [5] - [6] - [7]");
            Console.WriteLine();
            for (int row = 0; row < Board.RowCount; row++)
            {
                Console.WriteLine("     |{0}| - |{1}| - |{2}| - |{3}| - |{4}| - |{5}| - |{6}|",
                    PrVal(Board.Values[row, 0]), PrVal(Board.Values[row, 1]), PrVal(Board.Values[row, 2]),
                    PrVal(Board.Values[row, 3]), PrVal(Board.Values[row, 4]), PrVal(Board.Values[row, 5]),
                    PrVal(Board.Values[row, 6]));
            }
            Console.WriteLine();
        }

        private string PrVal(BoardValue val)
        {
            var res = " ";
            if (val == BoardValue.Player1) return "X";
            if (val == BoardValue.Player2) return "0";
            return res;
        }
    }
}
