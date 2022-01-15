using Xunit;

namespace Luval.FourInARow.Tests
{
    public class When_Using_The_Game
    {
        [Fact]
        public void It_Should_Detect_A_Downward_Diagonal_Winner()
        {
            var game = new Game();
            game.Board.Values = new BoardValue[6, 7] {
                { BoardValue.Player1,BoardValue.None,   BoardValue.None,   BoardValue.None,   BoardValue.None,BoardValue.None,BoardValue.None },
                { BoardValue.None,   BoardValue.Player1,BoardValue.None,   BoardValue.None,   BoardValue.None,BoardValue.None,BoardValue.None },
                { BoardValue.None,   BoardValue.None,   BoardValue.Player1,BoardValue.None,   BoardValue.None,BoardValue.None,BoardValue.None },
                { BoardValue.None,   BoardValue.None,   BoardValue.None,   BoardValue.Player1,BoardValue.None,BoardValue.None,BoardValue.None },
                { BoardValue.None,   BoardValue.None,   BoardValue.None,   BoardValue.None,   BoardValue.None,BoardValue.None,BoardValue.None },
                { BoardValue.None,   BoardValue.None,   BoardValue.None,   BoardValue.None,   BoardValue.None,BoardValue.None,BoardValue.None }
            };
            var win = game.CheckWinner();
            Assert.True(win == BoardValue.Player1);
            game.Board.Values = new BoardValue[6, 7] {
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.Player1,     BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.Player1,     BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.Player1,     BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.Player1 }
            };
            win = game.CheckWinner();
            Assert.True(win == BoardValue.Player1);
            game.Board.Values = new BoardValue[6, 7] {
                { BoardValue.None,      BoardValue.None,        BoardValue.Player1,     BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.Player1,     BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.Player1,     BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.Player1,     BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
            };
            win = game.CheckWinner();
            Assert.True(win == BoardValue.Player1);
        }

        [Fact]
        public void It_Should_Detect_A_Upward_Diagonal_Winner()
        {
            var game = new Game();
            game.Board.Values = new BoardValue[6, 7] {
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.Player1,     BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.Player1,     BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.Player1,     BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.Player1,   BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
            };
            var win = game.CheckWinner();
            Assert.True(win == BoardValue.Player1);
            game.Board.Values = new BoardValue[6, 7] {
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.Player1 },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.Player1,     BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.Player1,     BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.Player1,     BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
            };
            win = game.CheckWinner();
            Assert.True(win == BoardValue.Player1);
            game.Board.Values = new BoardValue[6, 7] {
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.Player1,     BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.Player1,     BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.Player1,     BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.Player1,     BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
            };
            win = game.CheckWinner();
            Assert.True(win == BoardValue.Player1);
        }

        [Fact]
        public void It_Should_Detect_A_Horizontal_Winner()
        {
            var game = new Game();
            game.Board.Values = new BoardValue[6, 7] {
                { BoardValue.Player1,   BoardValue.Player1,     BoardValue.Player1,     BoardValue.Player1,     BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
            };
            var win = game.CheckWinner();
            Assert.True(win == BoardValue.Player1);
            game.Board.Values = new BoardValue[6, 7] {
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.Player1,     BoardValue.Player1,     BoardValue.Player1,     BoardValue.Player1 },
            };
            win = game.CheckWinner();
            Assert.True(win == BoardValue.Player1);
            game.Board.Values = new BoardValue[6, 7] {
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.Player1,     BoardValue.Player1,     BoardValue.Player1,     BoardValue.Player1,     BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
            };
            win = game.CheckWinner();
            Assert.True(win == BoardValue.Player1);
        }

        [Fact]
        public void It_Should_Detect_A_Vertical_Winner()
        {
            var game = new Game();
            game.Board.Values = new BoardValue[6, 7] {
                { BoardValue.Player1,   BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.Player1,   BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.Player1,   BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.Player1,   BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,      BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
            };
            var win = game.CheckWinner();
            Assert.True(win == BoardValue.Player1);
            game.Board.Values = new BoardValue[6, 7] {
                { BoardValue.None,   BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,   BoardValue.None,        BoardValue.None,        BoardValue.Player1,     BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,   BoardValue.None,        BoardValue.None,        BoardValue.Player1,     BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,   BoardValue.None,        BoardValue.None,        BoardValue.Player1,     BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,   BoardValue.None,        BoardValue.None,        BoardValue.Player1,     BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,   BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None,        BoardValue.None },
            };
            win = game.CheckWinner();
            Assert.True(win == BoardValue.Player1);
            game.Board.Values = new BoardValue[6, 7] {
                { BoardValue.None,   BoardValue.None,        BoardValue.None,        BoardValue.None,     BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,   BoardValue.None,        BoardValue.None,        BoardValue.None,     BoardValue.None,        BoardValue.None,        BoardValue.None },
                { BoardValue.None,   BoardValue.None,        BoardValue.None,        BoardValue.None,     BoardValue.None,        BoardValue.None,        BoardValue.Player1 },
                { BoardValue.None,   BoardValue.None,        BoardValue.None,        BoardValue.None,     BoardValue.None,        BoardValue.None,        BoardValue.Player1 },
                { BoardValue.None,   BoardValue.None,        BoardValue.None,        BoardValue.None,     BoardValue.None,        BoardValue.None,        BoardValue.Player1 },
                { BoardValue.None,   BoardValue.None,        BoardValue.None,        BoardValue.None,     BoardValue.None,        BoardValue.None,        BoardValue.Player1 },
            };
            win = game.CheckWinner();
            Assert.True(win == BoardValue.Player1);
        }
    }
}