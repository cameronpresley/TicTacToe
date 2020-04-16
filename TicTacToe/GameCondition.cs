using System;
using System.Linq;

namespace TicTacToe
{
    public static class GameCondition
    {
        public static bool AllInARow(char symbol, Board board)
        {
            for (var i = 0; i < board.Dimension; i++)
            {
                var areAllCellsInRowSymbol =
                Enumerable
                .Range(0, board.Dimension)
                .Select(x => (row: i, column: x))
                .Select(x => board.GetSymbolAt(x.row, x.column))
                .All(x => x == symbol);
                if (areAllCellsInRowSymbol) return true;
            }
            return false;
        }

        public static bool AllInAColumn(char symbol, Board board)
        {
            for (var i = 0; i < board.Dimension; i++)
            {
                var areAllCellsInColumnSymbol =
                Enumerable
                .Range(0, board.Dimension)
                .Select(x => (column: i, row: x))
                .Select(x => board.GetSymbolAt(x.row, x.column))
                .All(x => x == symbol);
                if (areAllCellsInColumnSymbol) return true;
            }
            return false;
        }

        public static bool AllInADiagonal(char symbol, Board board)
        {
            var isUpperLeftDiagonal =
                Enumerable
                .Range(0, board.Dimension)
                .Select(x => board.GetSymbolAt(x, x))
                .All(x => x == symbol);

            var isUpperRightDiagonal =
                Enumerable
                .Range(0, board.Dimension)
                .Select(x => (row: board.Dimension - 1 - x, column: x))
                .Select(x => board.GetSymbolAt(x.row, x.column))
                .All(x => x == symbol);

            return isUpperLeftDiagonal || isUpperRightDiagonal;
        }
    
        public static bool IsBoardFilled(char emptySymbol, Board board)
        {
            return !Enumerable
            .Range(0, board.Dimension)
            .SelectMany(x => Enumerable.Range(0, board.Dimension).Select(y => (row:x, column:y)))
            .Select(cell => board.GetSymbolAt(cell.row, cell.column))
            .Any(c => c == emptySymbol);
        }
    }
}