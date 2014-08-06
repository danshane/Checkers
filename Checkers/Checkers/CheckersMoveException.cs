using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    /// <summary>
    /// The CheckersMoveException class represents an exception when making a move in Checkers.
    /// </summary>
    public class CheckersMoveException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the CheckersMoveException class.
        /// </summary>
        public CheckersMoveException()
            : base()
        {
        }

        /// <summary>
        /// Initialises a new instance of the CheckersMoveException class with a specified
        /// error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public CheckersMoveException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Initialises a new instance of the CheckersMoveException class with a specified
        /// error message and a reference to the inner exception that is the cause of this
        /// error.
        /// </summary>
        /// <param name="message">The message that describes the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of this error, or
        /// a null reference (Nothing in Visual Basic) if no exception is specified.</param>
        public CheckersMoveException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        /// <summary>
        /// Initialises a new instance of the CheckersMoveException class with serialized
        /// data.
        /// </summary>
        /// <param name="info">The System.Runtime.Serialization.SerializationInfo that holds
        /// the serialized object data about the exception being thrown.</param>
        /// <param name="context">The System.Runtime.Serialization.StreamingContext that
        /// contains contextual information about the source or the destination.</param>
        public CheckersMoveException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }

        #endregion
    }
}
