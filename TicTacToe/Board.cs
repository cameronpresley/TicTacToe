using System;
using System.Text;

namespace TicTacToe
{
    public class Board
    {
        public int Dimension { get; }
        private readonly char[,] _board;

        public Board(int dimension)
        {
            Dimension = dimension;
            _board = new char[dimension, dimension];
            for (var i = 0; i < dimension; i++)
                for (var j = 0; j < dimension; j++)
                    _board[i, j] = '-';
        }

        public Board FillLocation(char symbol, int row, int column)
        {
            ValidateRowAndColumn(row, column);
            if (_board[row, column] != '-') return this;
            _board[row, column] = symbol;
            return this;
        }

        public char GetSymbolAt(int row, int column)
        {
            ValidateRowAndColumn(row, column);
            return _board[row, column];
        }

        private void ValidateRowAndColumn(int row, int column)
        {
            if (row >= Dimension || column >= Dimension) throw new ArgumentException();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < Dimension; i++)
            {
                for (var j = 0; j < Dimension; j++)
                {
                    sb.Append(_board[i, j] + " ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}