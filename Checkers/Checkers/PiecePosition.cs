using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    /// <summary>
    /// The PiecePosition class represents a position on a checkers board.
    /// </summary>
    public class PiecePosition
    {
        #region Internal Member Variables

        /// <summary>
        /// The 0-based X position of the piece.
        /// </summary>
        private int _x = 0;

        /// <summary>
        /// The 0-based Y position of the piece.
        /// </summary>
        private int _y = 0;

        #endregion

        #region Constructors

        /// <summary>
        /// Instantiates a new PiecePosition object with the specified arguments.
        /// </summary>
        /// <param name="x">The 0-based X position of the piece.</param>
        /// <param name="y">The 0-based Y position of the piece.</param>
        public PiecePosition(int x, int y)
        {
            _x = x;
            _y = y;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines whether the specified System.Object is equal to the current
        /// PiecePosition.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the objects are equal, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            var isEqual = base.Equals(obj);

            if (obj is PiecePosition)
            {
                var other = obj as PiecePosition;

                if (((object)other != null) && (this.X == other.X) && (this.Y == other.Y))
                    isEqual = true;
            }

            return isEqual;
        }

        /// <summary>
        /// Determines whether the specified PiecePosition is equal to the current
        /// PiecePosition.
        /// </summary>
        /// <param name="other">The PiecePosition to compare with the current object.</param>
        /// <returns>True if the PiecePositions are equal, false otherwise.</returns>
        public bool Equals(PiecePosition other)
        {
            var isEqual = false;

            if (((object)other != null) && (this.X == other.X) && (this.Y == other.Y))
                isEqual = true;

            return isEqual;
        }

        /// <summary>
        /// Serves as the hash function for the particular type.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            var hashCode = 0;
            hashCode = (hashCode * 397) ^ this.X;
            hashCode = (hashCode * 397) ^ this.Y;

            return hashCode;
        }

        /// <summary>
        /// Returns a string that represents the current PiecePosition.
        /// </summary>
        /// <returns>A string that represents the current PiecePosition.</returns>
        public override string ToString()
        {
            return String.Format("({0},{1})", this.X, this.Y);
        }

        #endregion

        #region Properties

        /// <summary>
        /// The 0-based X position of the piece.
        /// </summary>
        public int X
        {
            get { return _x; }
        }

        /// <summary>
        /// The 0-based Y position of the piece.
        /// </summary>
        public int Y
        {
            get { return _y; }
        }

        #endregion
    }
}
