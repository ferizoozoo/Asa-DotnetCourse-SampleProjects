using System;
using LadderAndSnake;

namespace LadderAndSnake.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(10, 10, 5, 3, 5, 2);
            Game game = new Game(board);

            game.Join("A", ColorEnum.Blue);
            game.Join("B", ColorEnum.Green);
            game.Join("C", ColorEnum.Red);
            game.Join("D", ColorEnum.Yellow);

            game.PlayGame();
        }
    }
}
