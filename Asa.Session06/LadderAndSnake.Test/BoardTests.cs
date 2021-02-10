using NUnit.Framework;
using LadderAndSnake;

namespace LadderAndSnake.Test
{
    public class BoardTests
    {
        Board _board;

        const int GAME_BOARD_HEIGHT = 10;
        const int GAME_BOARD_WIDTH = 10;
        const int LADDER_COUNT = 5;
        const int SPECIAL_LADDER_COUNT = 2;
        const int SNAKE_COUNT = 5;
        const int SPECIAL_SNAKE_COUNT = 3;

        [SetUp]
        public void Setup()
        {
            _board = new Board(GAME_BOARD_HEIGHT, GAME_BOARD_WIDTH, LADDER_COUNT, SPECIAL_LADDER_COUNT, SNAKE_COUNT, SPECIAL_SNAKE_COUNT);
        }

        [Test]
        public void Board_CalculateNextPosition_Test()
        {
            int currentPosition = 5;
            int diceValue = 6;
            int expectedResult = 11;
            int nextPosition = _board.CalculateNextPosition(currentPosition, diceValue);
            Assert.AreEqual(expectedResult, nextPosition);
        }

        [Test]
        public void Board_CalculateNextPosition_ReturnsZeroForMoreThan100Test()
        {
            int currentPosition = 99;
            int diceValue = 2;
            var newPosition = _board.CalculateNextPosition(currentPosition, diceValue);
            Assert.AreEqual(0, newPosition);
        }

        // This test helped me actually change the code!!
        [Test]
        public void Board_CalculateNextPosition_ThrowsExceptionForLessThan0Test()
        {
            int currentPosition = -2;
            int diceValue = 1;
            Assert.That(
                () => _board.CalculateNextPosition(currentPosition, diceValue),
                Throws.Exception
            );
        }
    }
}