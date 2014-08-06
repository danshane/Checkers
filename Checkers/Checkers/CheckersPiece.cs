using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    /// <summary>
    /// The CheckersPiece class represents a piece in a game of Checkers.
    /// </summary>
    public class CheckersPiece
    {
        #region Internal Member Variables

        /// <summary>
        /// The player associated with the CheckersPiece.
        /// </summary>
        private Player _player = Player.Unknown;

        /// <summary>
        /// The position of the CheckersPiece.
        /// </summary>
        private PiecePosition _position = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Instantiates a new CheckersPiece object with the specified arguments.
        /// </summary>
        /// <param name="player">The player associated with the CheckersPiece.</param>
        /// <param name="position">The position of the CheckersPiece.</param>
        public CheckersPiece(Player player, PiecePosition position)
        {
            _player = player;
            _position = position;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines whether the specified System.Object is equal to the current
        /// CheckersPiece.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the objects are equal, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            var isEqual = base.Equals(obj);

            if (obj is CheckersPiece)
            {
                var other = obj as CheckersPiece;

                if ((other != null) && (this.Player == other.Player) && (this.Position == other.Position))
                    isEqual = true;
            }

            return isEqual;
        }

        /// <summary>
        /// Determines whether the specified CheckersPiece is equal to the current
        /// CheckersPiece.
        /// </summary>
        /// <param name="other">The CheckersPiece to compare with the current object.</param>
        /// <returns>True if the CheckersPiece are equal, false otherwise.</returns>
        public bool Equals(CheckersPiece other)
        {
            var isEqual = false;

            if ((other != null) && (this.Player == other.Player) && (this.Position == other.Position))
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
            hashCode = (hashCode * 397) ^ this.Player.GetHashCode();
            hashCode = (hashCode * 397) ^ this.Position.GetHashCode();

            return hashCode;
        }
        
        /// <summary>
        /// Returns a string that represents the current CheckersPiece.
        /// </summary>
        /// <returns>A string that represents the current CheckersPiece.</returns>
        public override string ToString()
        {
            return String.Format("Player: {0}, Position: {1}", this.Player, this.Position);
        }

        #endregion

        #region Properties

        /// <summary>
        /// The player associated with the CheckersPiece.
        /// </summary>
        public Player Player
        {
            get { return _player; }
        }

        /// <summary>
        /// The position of the CheckersPiece.
        /// </summary>
        public PiecePosition Position
        {
            get { return _position; }
            set { _position = value; }
        }

        #endregion
    }
}
