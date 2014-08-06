using Checkers.Movement;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Tests.Movement
{
    [TestFixture]
    class BasicPieceMovementTests
    {
        [Test]
        public void CanDetermineValidBasicMovements()
        {
            var movement = new BasicPieceMovement();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var player1Piece = new CheckersPiece(Player.Player1, new PiecePosition(i, j));
                    var player2Piece = new CheckersPiece(Player.Player2, new PiecePosition(i, j));

                    if ((i - 1) >= 0)
                    {
                        if ((j + 1) < 8)
                            Assert.True(movement.IsValidMovement(player1Piece, new PiecePosition(i - 1, j + 1)));

                        if ((j - 1) >= 0)
                            Assert.True(movement.IsValidMovement(player2Piece, new PiecePosition(i - 1, j - 1)));
                    }

                    if ((i + 1) < 8)
                    {
                        if ((j + 1) < 8)
                            Assert.True(movement.IsValidMovement(player1Piece, new PiecePosition(i + 1, j + 1)));

                        if ((j - 1) >= 0)
                            Assert.True(movement.IsValidMovement(player2Piece, new PiecePosition(i + 1, j - 1)));
                    }

                }
            }

        }

        [Test]
        public void CanDetermineInvalidBasicMovements()
        {
            var movement = new BasicPieceMovement();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var player1Piece = new CheckersPiece(Player.Player1, new PiecePosition(i, j));
                    var player2Piece = new CheckersPiece(Player.Player2, new PiecePosition(i, j));

                    for (int x = 0; x < 8; x++)
                    {
                        for (int y = 0; y < 8; y++)
                        {
                            if ((x != (i + 1)) && (x != (i - 1)) && (y != (j + 1)))
                                Assert.False(movement.IsValidMovement(player1Piece, new PiecePosition(x, y)));

                            if ((x != (i + 1)) && (x != (i - 1)) && (y != (j - 1)))
                                Assert.False(movement.IsValidMovement(player2Piece, new PiecePosition(x, y)));
                        }
                    }
                }
            }
        }
    }
}
