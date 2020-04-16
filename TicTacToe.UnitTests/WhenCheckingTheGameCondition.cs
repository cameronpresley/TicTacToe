using System;
using NUnit.Framework;
using TicTacToe;

namespace TicTacToe.UnitTests
{
    [TestFixture]
    public class WhenCheckingTheGameCondition
    {
        [Test]
        public void AndTheBoardHasAllInARowThenTrueIsReturned()
        {
            var board = new BoardBuilder().Fill('x', 0, 0).Fill('x', 0, 1).Fill('x', 0, 2).Create();
            Assert.IsTrue(GameCondition.AllInARow('x', board));
        }

        [Test]
        public void AndTheBoardHasAllInAColumnThenTrueIsReturned()
        {
            var board = new BoardBuilder().Fill('x', 0, 0).Fill('x', 1, 0).Fill('x', 2, 0).Create();
            Console.WriteLine(board);
            Assert.IsTrue(GameCondition.AllInAColumn('x', board));
        }

        [Test]
        public void AndTheBoardHasAnUpperLeftDiagonalFilledThenTrueIsReturned()
        {
            var board = new BoardBuilder().Fill('x', 0, 0).Fill('x', 1, 1).Fill('x', 2, 2).Create();
            Assert.IsTrue(GameCondition.AllInADiagonal('x', board));
        }

        [Test]
        public void AndTheBoardHasAnUpperRightDiagonalFilledThenTrueIsReturned()
        {
            var board = new BoardBuilder().Fill('x', 0, 2).Fill('x', 1, 1).Fill('x', 2, 0).Create();
            Assert.IsTrue(GameCondition.AllInADiagonal('x', board));
        }

        [Test]
        public void AndTheBoardIsFilledThenTrueIsReturned()
        {
            var board = new BoardBuilder().Create();
            for (var i = 0; i < board.Dimension; i++)
            {
                for (var j = 0; j < board.Dimension; j++) {
                    board.FillLocation('x', i, j);
                }
            }
            Console.WriteLine(board);
            Assert.IsTrue(GameCondition.IsBoardFilled('-', board));
        }
    }

    public class BoardBuilder
    {
        private Board _board;
        public BoardBuilder()
        {
            _board = new Board(3);
        }

        public BoardBuilder Fill(char symbol, int row, int column)
        {
            _board.FillLocation(symbol, row, column);
            return this;
        } 

        public Board Create() => _board;
    }
}