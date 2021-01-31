using NUnit.Framework;
using LadderAndSnake;
using System;
using System.Collections.Generic;

namespace LadderAndSnake.Test
{
    [TestFixture]
    class GameTests
    {
        Game _game;
        Board board;

        const int BOARD_HEIGHT = 10;
        const int BOARD_WIDTH = 10;
        const int LADDER_COUNT = 5;
        const int SNAKE_COUNT = 5;

        const int PLAYERS = 4;


        [SetUp]
        public void Setup()
        {
            board = new Board(BOARD_HEIGHT, BOARD_WIDTH, LADDER_COUNT, SNAKE_COUNT);
            _game = new Game(board);

            for (int player = 0; player < PLAYERS; player++)
                _game.Join($"Player {player}", (ColorEnum)player);
        }


        [Test]
        public void Game_JoinCannotAddMoreThan4Players()
        {
            var name = "Ali";
            Assert.That(() => _game.Join(name, ColorEnum.Blue), Throws.InvalidOperationException);
        }

        [Test]
        public void Game_JoinThrowsExceptionInDuplicateNames()
        {
            _game = new Game(board);
            var name = "Ali";
            _game.Join(name, ColorEnum.Blue);
            Assert.That(() => _game.Join(name, ColorEnum.Green), Throws.InvalidOperationException);
        }
    }
}
