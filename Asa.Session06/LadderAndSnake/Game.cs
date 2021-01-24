using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LadderAndSnake
{
    public class Game
    {

        readonly List<Player> _players;
        Board _board;
        public Game(int heigth, int width, int ladderCount, int snakeCount)
        {
            _board = new Board(heigth, width, ladderCount, snakeCount);
        }

        public void Join(string name, ColorEnum color)
        {
            //foreach (var item in _players)
            //{
            //    if (item.Name == name) throw new InvalidOperationException("Duplicated player name is not allowed.");
            //}

            //IComparable<T>
            Player newPlayer = new Player(name, color);
            //if (_players.Any(x => x.Name.ToLower().Trim() == name.ToLower().Trim() || x.Color == color))
            //if (_players.Any(x => x.Equals(newPlayer)))
            if (_players.Any(x => x == newPlayer))
            {
                throw new InvalidOperationException("Duplicated player name is not allowed.");
            }
            const int Max_Allowd_Players = 4;
            if (_players.Count >= Max_Allowd_Players)
            {
                throw new InvalidOperationException("Only 4 players can join a game.");
            }
            _players.Add(new Player(name, color));
        }
        public Game()
        {
            _players = new List<Player>();
        }

        bool gameIsFinished;
        public MoveResult Play()
        {
            if (gameIsFinished)
            {
                throw new InvalidOperationException("Game is finished, no more movement is allowed.");
            }
            var currentPlayer = GetCurrentPlayer();
            MoveResult moveresult = currentPlayer.MoveOn(_board);
            moveresult.IsWinner = moveresult.NewPosition == _board.ExitPint;
            gameIsFinished = moveresult.IsWinner;
            return moveresult;
        }

        private Player GetCurrentPlayer()
        {
            throw new NotImplementedException();
        }
        public BoardDataDto GetBoardData() => _board.GetData();
    }
}
