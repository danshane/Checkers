Checkers
========

The CheckersGame class provides the API for a game of Checkers.

Creating a new instance of the class automatically initialises a new game. To make a move, players
make use of the MovePiece() method.

        /// <summary>
        /// Attempts to move a Checkers piece to the specified position.
        /// </summary>
        /// <param name="player">The player to make the move.</param>
        /// <param name="pieceToMove">The piece to be moved.</param>
        /// <param name="newPosition">The new position to move the piece to.</param>
        /// <returns>The result of making the move.</returns>
        public MoveResult MovePiece(Player player, CheckersPiece pieceToMove, PiecePosition newPosition);
		
The MovePiece method accepts arguments detailing the Player to make a move, the piece to be moved and
the desired new position of the piece. It will return an exception if the move or arguments are invalid,
otherwise it will return a MoveResult indicating which player is to move next - or the result of the game
if no further moves can be made.

The pieces that are currently in play in the game can be found using the Pieces property on the CheckersGame
class which returns an enumerable list of pieces that are still on the board.