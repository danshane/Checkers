using Checkers.Movement;
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

        /// <summary>
        /// The player to make the current move.
        /// </summary>
        private Player _currentPlayer = Player.Unknown;

        /// <summary>
        /// An array of available movements for the checkers pieces.
        /// </summary>
        private IPieceMovement[] _availableMovements = new IPieceMovement[] { new BasicPieceMovement() };

        #endregion

        #region Constructor

        /// <summary>
        /// Instantiates a new CheckersGame object with the default arguments.
        /// </summary>
        public CheckersGame()
        {
            this.SetupInitialBoard();
            _currentPlayer = Player.Player1;
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

            foreach (var p in player1StartingPositions)
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
            var moveResult = MoveResult.Unknown;

            if (player == Player.Unknown)
                throw new ArgumentException("An unknown player has been specified.");

            if (pieceToMove == null)
                throw new ArgumentNullException("No piece to move has been specified.");

            if (newPosition == null)
                throw new ArgumentNullException("No new position to move to has been specified.");

            if (player != _currentPlayer)
                throw new CheckersMoveException(String.Format("Incorrect player - it is currently {0}'s move", _currentPlayer.ToString()));

            if (!_pieces.Contains(pieceToMove))
                throw new CheckersMoveException("An piece not currently on the board has been moved.");

            var movement = this.GetPieceMovement(pieceToMove, newPosition);

            if (movement == null)
            {
                throw new CheckersMoveException("The specified move is not valid.");
            }
            else
            {
                var hasPiecesInWay = (from p in _pieces
                                      where p.Position.Equals(newPosition)
                                      select p).Any();

                if (hasPiecesInWay)
                    throw new CheckersMoveException("The specified move is not valid.");

                pieceToMove.Position = newPosition;

                moveResult = GetMoveResult();

                if (moveResult == MoveResult.Player1ToMoveNext)
                    _currentPlayer = Player.Player1;
                else if (moveResult == MoveResult.Player2ToMoveNext)
                    _currentPlayer = Player.Player2;

            }

            return moveResult;
        }

        /// <summary>
        /// Gets the move result, given the current state of the game board.
        /// </summary>
        /// <returns>A move result representing the current state of the game board.</returns>
        private MoveResult GetMoveResult()
        {
            var moveResult = MoveResult.Unknown;

            var nPlayer1Pieces = (from p in _pieces
                                  where p.Player == Player.Player1
                                  select p).Count();

            var nPlayer2Pieces = (from p in _pieces
                                  where p.Player == Player.Player2
                                  select p).Count();

            if (nPlayer1Pieces == 0)
            {
                moveResult = MoveResult.Player2Wins;
            }
            else if (nPlayer2Pieces == 0)
            {
                moveResult = MoveResult.Player1Wins;
            }
            else
            {
                if (_currentPlayer == Player.Player1)
                {
                    if (!HasAvailableMoves(Player.Player2))
                        moveResult = MoveResult.Stalemate;
                    else
                        moveResult = MoveResult.Player2ToMoveNext;
                }
                else if (_currentPlayer == Player.Player2)
                {
                    if (!HasAvailableMoves(Player.Player1))
                        moveResult = MoveResult.Stalemate;
                    else
                        moveResult = MoveResult.Player1ToMoveNext;
                }
            }
            return moveResult;
        }

        /// <summary>
        /// Determines whether the specified player has any available moves.
        /// </summary>
        /// <param name="player">The player to determine the available moves for.</param>
        /// <returns>True if the player has available moves, false otherwise.</returns>
        private bool HasAvailableMoves(Player player)
        {
            var playerPieces = from p in _pieces
                               where p.Player == player
                               select p;

            foreach (var piece in playerPieces)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        foreach (var m in _availableMovements)
                        {
                            var position = new PiecePosition(i, j);
                            if (m.IsValidMovement(piece, position))
                            {
                                var hasPiecesInWay = (from p in _pieces
                                                      where p.Position.Equals(position)
                                                      select p).Any();

                                if (!hasPiecesInWay)
                                {
                                    return true;
                                }
                            }
                        }

                    }

                }
            }

            return false;
        }


        /// <summary>
        /// Gets an IPieceMovement that matches the movement of the specified piece to the
        /// new position, or null if no valid movement can be found.
        /// </summary>
        /// <param name="pieceToMove">The piece to be moved.</param>
        /// <param name="newPosition">The new position of the piece.</param>
        /// <returns>An IPieceMovement representing the movement for the piece or null if no
        /// valid movement can be found.</returns>
        private IPieceMovement GetPieceMovement(CheckersPiece pieceToMove, PiecePosition newPosition)
        {
            IPieceMovement validMovement = null;

            foreach (var m in _availableMovements)
            {
                if (m.IsValidMovement(pieceToMove, newPosition))
                {
                    validMovement = m;
                    break;
                }
            }

            return validMovement;
        }


        #endregion

        #region Properties

        /// <summary>
        /// An enumerable list of currently available pieces in the Checkers game.
        /// </summary>
        public IEnumerable<CheckersPiece> Pieces
        {
            get
            {
                return _pieces;
            }
            internal set
            {
                _pieces = new List<CheckersPiece>(value);
            }
        }

        #endregion
    }
}
