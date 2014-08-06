using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Movement
{
    /// <summary>
    /// The BasicPieceMovement class represents the movement of a piece diagonally forward by
    /// one square.
    /// </summary>
    class BasicPieceMovement : IPieceMovement
    {
        public bool IsValidMovement(CheckersPiece piece, PiecePosition newPosition)
        {
            var isValid = false;

            if ((newPosition.X >= 0) && (newPosition.X < 8) && (newPosition.Y >= 0) && (newPosition.Y < 8))
            {
                if (piece.Player == Player.Player1)
                {
                    if ((Math.Abs(newPosition.X - piece.Position.X) == 1)
                        && ((newPosition.Y - piece.Position.Y) == 1))
                        isValid = true;
                }
                else if(piece.Player == Player.Player2)
                {
                    if ((Math.Abs(newPosition.X - piece.Position.X) == 1)
                        && ((newPosition.Y - piece.Position.Y) == -1))
                        isValid = true;
                }
            }
            
            return isValid;
        }
    }
}
