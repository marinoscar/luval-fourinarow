namespace Luval.FourInARow
{
    public class Game
    {
        /// <summary>
        /// Gets the game board
        /// </summary>
        public Board Board { get; private set; }

        /// <summary>
        /// Creates a new instance of the game
        /// </summary>
        public Game()
        {
            Board = new Board();
            Board.ChipPlaced += Board_ChipPlaced;
        }

        private void Board_ChipPlaced(object? sender, BoardChipPlacedEventArgs e)
        {

        }

        /// <summary>
        /// Sets the chip in the available slot for the column index
        /// </summary>
        /// <param name="columnIndex">The column to place the chip</param>
        public void Play(int columnIndex)
        {
            Board.NextChip(columnIndex);
        }

        public BoardValue? CheckWinner()
        {
            var isFull = Board.IsBoardFull();
            if (isFull) return BoardValue.None;
            if (!isFull && DidPlayerWon(BoardValue.Player1)) return BoardValue.Player1;
            if (!isFull && DidPlayerWon(BoardValue.Player2)) return BoardValue.Player2;
            return null;
        }

        private bool DidPlayerWon(BoardValue player)
        {
            if (BoardValue.None == player) throw new ArgumentException("Value cannot be None", nameof(player));
            return HorizontalWin(player) 
                || VerticalWin(player) 
                || RightDown(player) 
                || RightUp(player);
        }

        private bool HorizontalWin(BoardValue player)
        {
            var count = 0;
            for (int row = 0; row < Board.RowCount; row++)
            {
                for (int col = 0; col < Board.ColumnCount; col++)
                {
                    if (Board.Values[row, col] != BoardValue.None // no empty row 
                        && Board.Values[row, col] == player //current is player value
                        )
                    {
                        count = 1;
                        var searchCol = col + 1;
                        while (count < 4 && NextMatch(player, row, searchCol))
                        {
                            count++;
                            searchCol++;
                        }
                        if (count >= 4) return true;
                    }
                }
            }
            return false;
        }

        private bool VerticalWin(BoardValue player)
        {
            var count = 0;
            for (int row = 0; row < Board.RowCount; row++)
            {
                for (int col = 0; col < Board.ColumnCount; col++)
                {
                    if (Board.Values[row, col] != BoardValue.None // no empty row 
                        && Board.Values[row, col] == player //current is player value
                        )
                    {
                        count = 1;
                        var searchRow = row + 1;
                        while (count < 4 && NextMatch(player, searchRow, col))
                        {
                            count++;
                            searchRow++;
                        }
                        if (count >= 4) return true;
                    }
                }
            }
            return false;
        }

        private bool RightDown(BoardValue player)
        {
            var count = 0;
            for (int row = 0; row < Board.RowCount; row++)
            {
                for (int col = 0; col < Board.ColumnCount; col++)
                {
                    if (Board.Values[row, col] != BoardValue.None // no empty row ray
                        && Board.Values[row, col] == player //current is player value
                        )
                    {
                        count = 1;
                        var searchRow = row + 1;
                        var searchCol = col + 1;
                        while(count < 4 && NextMatch(player, searchRow, searchCol))
                        {
                            count++;
                            searchRow++;
                            searchCol++;
                        }
                        if (count >= 4) return true;

                    }
                }
            }
            return false;
        }

        private bool NextMatch(BoardValue player, int row, int col)
        {
            return  row < Board.RowCount && col < Board.ColumnCount && Board.Values[row, col] == player;
        }

        private bool RightUp(BoardValue player)
        {
            var count = 0;
            for (int row = 0; row < Board.RowCount; row++)
            {
                for (int col = 0; col < Board.ColumnCount; col++)
                {
                    if (Board.Values[row, col] != BoardValue.None // no empty row ray
                        && Board.Values[row, col] == player //current is player value
                        )
                    {
                        count = 1;
                        var searchRow = row - 1;
                        var searchCol = col + 1;
                        while (count < 4 && NextMatch(player, searchRow, searchCol))
                        {
                            count++;
                            searchRow--;
                            searchCol++;
                        }
                        if (count >= 4) return true;

                    }
                }
            }
            return false;
        }
    }
}