using TicTacToe;
using NUnit.Framework;

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
        }
    }
}