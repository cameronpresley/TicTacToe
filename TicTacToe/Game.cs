using System.Collections.Generic;

namespace TicTacToe
{
    public class Game
    {
        public Player CurrentPlayer => _players[(_playerTurn % 2)];
        public Board Board { get; }
        private List<Player> _players;
        private int _playerTurn;
        public Game()
        {
            Board = new Board(3);
            _players = new List<Player>{
                new Player('X'),
                new Player('O'),
            };
            _playerTurn = 0;
        }

        public bool CanChoseLocation(int row, int column) => Board.GetSymbolAt(row, column) == '-';
        public void FillLocation(int row, int column)
        {
            Board.FillLocation(CurrentPlayer.Symbol, row, column);
            NextPlayer();
        }
        private void NextPlayer()
        {
            _playerTurn++;
        }
        public bool IsGameOver() => DidPlayerOneWin() || DidPlayerTwoWin() || IsGameTied();
        private bool DidPlayerOneWin() => DoesSymbolWin('X');
        private bool DidPlayerTwoWin() => DoesSymbolWin('O');
        private bool IsGameTied() => GameCondition.IsBoardFilled('-', Board);

        public bool DoesSymbolWin(char symbol)
            => GameCondition.AllInARow(symbol, Board)
                  || GameCondition.AllInAColumn(symbol, Board)
                  || GameCondition.AllInADiagonal(symbol, Board);

        public string Winner()
        {
            if (DidPlayerOneWin()) return "X's Won!";
            if (DidPlayerTwoWin()) return "O's Won!";
            return "Game was a tie!";
        }
    }
}