using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luval.FourInARow
{
    /// <summary>
    /// Implements a board exception
    /// </summary>
    public class BoardException : Exception
    {

        /// <summary>
        /// Creates a new instance
        /// </summary>
        public BoardException()
        {

        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="message">Exception message</param>
        public BoardException(string message) : base(message)
        {

        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public BoardException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
