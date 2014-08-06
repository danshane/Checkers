using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Movement
{
    /// <summary>
    /// The IPieceMovement provides an interface to a type of movement by a CheckersPiece.
    /// </summary>
    public interface IPieceMovement
    {
        #region Interface Methods

        /// <summary>
        /// Checks to see if the specified piece can be moved to the new position
        /// using this movement.
        /// </summary>
        /// <param name="piece">The piece to be moved.</param>
        /// <param name="newPosition">The position to move it to.</param>
        /// <returns>True if the piece can be moved, false otherwise.</returns>
        bool IsValidMovement(CheckersPiece piece, PiecePosition newPosition);

        #endregion
    }
}
