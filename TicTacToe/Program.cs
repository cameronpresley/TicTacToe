using System;
using System.Text;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            while (!game.IsGameOver())
            {
                System.Console.WriteLine(game.Board);
                System.Console.WriteLine("It's Player " + game.CurrentPlayer.Symbol + "'s Turn!");
                System.Console.WriteLine("Choose a row (0 based) for the slot");
                var row = Int32.Parse(Console.ReadLine());
                System.Console.WriteLine("Choose a column (0 based) for the slot");
                var column = Int32.Parse(Console.ReadLine());
                if (!game.CanChoseLocation(row, column))
                {
                    System.Console.WriteLine("That slot is already picked, try again!");
                }
                else 
                {
                    game.FillLocation(row, column);
                }
            }
            System.Console.WriteLine(game.Board);
            System.Console.WriteLine(game.Winner());
            System.Console.WriteLine("Game over!");
        }
    }
}
