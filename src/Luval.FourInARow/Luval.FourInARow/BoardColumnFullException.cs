using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luval.FourInARow
{
    /// <summary>
    /// Exception for when a board column is full
    /// </summary>
    public class BoardColumnFullException : BoardException
    {
        public BoardColumnFullException() : base("The board column is full")
        {

        }
    }
}
