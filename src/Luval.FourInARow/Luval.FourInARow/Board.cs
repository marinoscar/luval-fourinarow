namespace Luval.FourInARow
{
    public class Board
    {
        /// <summary>
        /// Gets the board values
        /// </summary>
        public BoardValue[,] Values { get; set; }

        /// <summary>
        /// Gets the last Player
        /// </summary>
        public BoardValue LastPlayer { get; private set; }

        /// <summary>
        /// Gets the number of columns in the board
        /// </summary>
        public int ColumnCount => 7;
        /// <summary>
        /// Gets the number of rows in the board
        /// </summary>
        public int RowCount => 6;

        /// <summary>
        /// Triggered when a chip is placed in the board
        /// </summary>
        public event EventHandler<BoardChipPlacedEventArgs> ChipPlaced;

        /// <summary>
        /// Creates a new instance of the board
        /// </summary>
        public Board()
        {
            LastPlayer = BoardValue.None;
            Values = new BoardValue[6, 7] {
                { BoardValue.None,BoardValue.None,BoardValue.None,BoardValue.None,BoardValue.None,BoardValue.None,BoardValue.None },
                { BoardValue.None,BoardValue.None,BoardValue.None,BoardValue.None,BoardValue.None,BoardValue.None,BoardValue.None },
                { BoardValue.None,BoardValue.None,BoardValue.None,BoardValue.None,BoardValue.None,BoardValue.None,BoardValue.None },
                { BoardValue.None,BoardValue.None,BoardValue.None,BoardValue.None,BoardValue.None,BoardValue.None,BoardValue.None },
                { BoardValue.None,BoardValue.None,BoardValue.None,BoardValue.None,BoardValue.None,BoardValue.None,BoardValue.None },
                { BoardValue.None,BoardValue.None,BoardValue.None,BoardValue.None,BoardValue.None,BoardValue.None,BoardValue.None },
            };
        }

        /// <summary>
        /// Sets the next available chip in the slot in the column
        /// </summary>
        /// <param name="columnIndex">The column index to allocate the chip</param>
        /// <exception cref="BoardException">When the column index is invalid</exception>
        /// <exception cref="BoardColumnFullException">When the column index is full</exception>
        public void NextChip(int columnIndex)
        {
            if (columnIndex < 0 && columnIndex > ColumnCount) throw new BoardException("Invalid column index");
            var rowIndex = GetRowIndex(columnIndex);
            if (LastPlayer == BoardValue.None)
            {
                SetPlayer(rowIndex, columnIndex, BoardValue.Player1);
                LastPlayer = BoardValue.Player1;
                return;
            }
            if (LastPlayer == BoardValue.Player2)
            {
                SetPlayer(rowIndex, columnIndex, BoardValue.Player1);
                LastPlayer = BoardValue.Player1;
                return;
            }
            SetPlayer(rowIndex, columnIndex, BoardValue.Player2);
            LastPlayer = BoardValue.Player2;
        }

        /// <summary>
        /// Checks if the board is already full of chips
        /// </summary>
        /// <returns><see langword="true"/> if the board is full otherwise <see langword="false"/></returns>
        public bool IsBoardFull()
        {
            for (int row = 0; row < RowCount; row++)
            {
                for (int col = 0; col < ColumnCount; col++)
                {
                    if(Values[row,col] == BoardValue.None) return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Triggers the event and pass the arguments
        /// </summary>
        /// <param name="value">The value for the slot</param>
        /// <param name="rowIndex">Slot row index</param>
        /// <param name="columnIndex">Slot column index</param>
        protected virtual void OnChipPlaced(BoardValue value, int rowIndex, int columnIndex)
        {
            ChipPlaced?.Invoke(this, new BoardChipPlacedEventArgs(value, rowIndex, columnIndex));
        }

        private void SetPlayer(int rowIndex, int columnIndex, BoardValue value)
        {
            Values[rowIndex, columnIndex] = value;
            LastPlayer = value;
            OnChipPlaced(value, rowIndex, columnIndex);
        }

        private int GetRowIndex(int columnIndex)
        {
            for (int i = RowCount - 1; i >= 0; i--)
            {
                if (Values[i, columnIndex] == (int)BoardValue.None) return i;
            }
            throw new BoardColumnFullException();
        }
    }

    public class BoardChipPlacedEventArgs : EventArgs
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="value">The value for the slot</param>
        /// <param name="rowIndex">Slot row index</param>
        /// <param name="columnIndex">Slot column index</param>
        internal BoardChipPlacedEventArgs(BoardValue value, int rowIndex, int columnIndex)
        {
            Value = value;
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
        }

        /// <summary>
        /// Gets the row index
        /// </summary>
        public int RowIndex { get; private set; }
        /// <summary>
        /// Gets the column index
        /// </summary>
        public int ColumnIndex { get; private set; }
        /// <summary>
        /// Gets the slot value
        /// </summary>
        public BoardValue Value { get; private set; }
    }

    /// <summary>
    /// Board valid values
    /// </summary>
    public enum BoardValue
    {
        None = 0,
        Player1 = 'X',
        Player2 = 'O'
    }

}
