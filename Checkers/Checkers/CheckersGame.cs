using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    /// <summary>
    /// The CheckersGame class represents a game of Checkers using English Draughts rules.
    /// </summary>
    public class CheckersGame
    {
        #region Internal Member Variables

        /// <summary>
        /// A list of currently available pieces in the Checkers game.
        /// </summary>
        private List<CheckersPiece> _pieces = new List<CheckersPiece>();

        #endregion

        #region Constructor

        /// <summary>
        /// Instantiates a new CheckersGame object with the default arguments.
        /// </summary>
        public CheckersGame()
        {
            this.SetupInitialBoard();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets up the initial Checkers game board and pieces.
        /// </summary>
        private void SetupInitialBoard()
        {
            _pieces.Clear();

            var player1StartingPositions = new PiecePosition[]
            {
                new PiecePosition(0, 0), new PiecePosition(0, 2), new PiecePosition(0, 4), new PiecePosition(0, 6),
                new PiecePosition(1, 1), new PiecePosition(1, 3), new PiecePosition(1, 5), new PiecePosition(1, 7),
                new PiecePosition(2, 0), new PiecePosition(2, 2), new PiecePosition(2, 4), new PiecePosition(2, 6)
            };

            var player2StartingPositions = new PiecePosition[]
            {
                new PiecePosition(5, 1), new PiecePosition(5, 3), new PiecePosition(5, 5), new PiecePosition(5, 7),
                new PiecePosition(6, 0), new PiecePosition(6, 2), new PiecePosition(6, 4), new PiecePosition(6, 6),
                new PiecePosition(7, 1), new PiecePosition(7, 3), new PiecePosition(7, 5), new PiecePosition(7, 7)
            };

            foreach(var p in player1StartingPositions)
            {
                _pieces.Add(new CheckersPiece(Player.Player1, p));
            }

            foreach (var p in player2StartingPositions)
            {
                _pieces.Add(new CheckersPiece(Player.Player2, p));
            }
        }

        /// <summary>
        /// Attempts to move a Checkers piece to the specified position.
        /// </summary>
        /// <param name="player">The player to make the move.</param>
        /// <param name="pieceToMove">The piece to be moved.</param>
        /// <param name="newPosition">The new position to move the piece to.</param>
        /// <returns>The result of making the move.</returns>
        public MoveResult MovePiece(Player player, CheckersPiece pieceToMove, PiecePosition newPosition)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Properties

        /// <summary>
        /// An enumerable list of currently available pieces in the Checkers game.
        /// </summary>
        public IEnumerable<CheckersPiece> Pieces
        {
            get { return _pieces; }
        }

        #endregion
    }
}
