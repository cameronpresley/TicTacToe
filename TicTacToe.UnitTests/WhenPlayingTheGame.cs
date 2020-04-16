using TicTacToe;
using NUnit.Framework;
using System;

namespace TicTacToe.UnitTests
{
    public class WhenPlayingTheGame
    {
        [Test]
        public void AndTheGameStartsThenXIsTheCurrentPlayer()
        {
            var game = new Game();

            Assert.IsTrue(game.CurrentPlayer.Symbol == 'X');
        }

        [Test]
        public void AndXTakesATurnThenOIsTheCurrentPlayer()
        {
            var game = new Game();

            game.FillLocation(0, 0);

            Assert.IsTrue(game.CurrentPlayer.Symbol == 'O');
        }

        [Test]
        public void AndTheBoardIsFilledWithNoWinnerThenTheGameIsOver()
        {
            /*
                    X | O | X
                    X | O | X
                    O | X | O
            */
            var game = new Game();
            game.FillLocation(0, 0);
            game.FillLocation(0, 1);
            game.FillLocation(0, 2);
            game.FillLocation(1, 1);
            game.FillLocation(1, 0);
            game.FillLocation(2, 0);
            game.FillLocation(2, 1);
            game.FillLocation(2, 2);
            game.FillLocation(1, 2);

            Assert.IsTrue(game.IsGameOver());
        }
    }
}