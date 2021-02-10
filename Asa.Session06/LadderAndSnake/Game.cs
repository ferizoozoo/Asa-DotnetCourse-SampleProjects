using System;
using System.Linq;
using System.Collections.Generic;

namespace LadderAndSnake
{
    public class Game
    {
        readonly List<Player> _players;
        Board _board;
        bool gameIsFinished;
        private int currentPlayerIndex = 0;
         
        public Game(Board board)
        {
            _board = board;
            _players = new List<Player>();
        }

        public void Join(string name, ColorEnum color)
        {
            const int Max_Allowed_Players = 4;

            Player newPlayer = new Player(name, color);

            if (_players.Any(x => x == newPlayer))
                throw new InvalidOperationException("Duplicated player name is not allowed.");

            if (_players.Count >= Max_Allowed_Players)
                throw new InvalidOperationException("Only 4 players can join a game.");

            _players.Add(new Player(name, color));
        }
        
        private MoveResult Play()
        {
            var currentPlayer = GetCurrentPlayer();
            MoveResult moveresult = currentPlayer.MoveOn(_board);

            if (_board.CheckSpecialSnake(moveresult.NewPosition))
                currentPlayer.ChangeLives(-1);

            if (currentPlayer.Lives == 0)
                _players.Remove(currentPlayer);

            moveresult.IsWinner = moveresult.NewPosition == _board.ExitPoint;
            currentPlayerIndex = currentPlayerIndex == _players.Count - 1 ? 0 : currentPlayerIndex + 1; 
            gameIsFinished = moveresult.IsWinner;

            return moveresult;
        }

        public void PlayGame()
        {
            do
            {
                if (_players.Count == 0)
                    throw new Exception("Game finished with no one winning!");
                Play();
            } while (!gameIsFinished);
        }

        private Player GetCurrentPlayer() => _players[currentPlayerIndex];

        public BoardDataDto GetBoardData() => _board.GetData();
    }
}
