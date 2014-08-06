using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Tests
{
    [TestFixture]
    class CheckersGameTests
    {
        [Test]
        public void CanCreateNewGame()
        {
            var game = new CheckersGame();
            Assert.NotNull(game.Pieces);
        }

        [Test]
        public void NewGameHasCorrectStartingPosition()
        {
            var game = new CheckersGame();

            Assert.AreEqual(24, game.Pieces.Count());

            var player1Pieces = from p in game.Pieces
                                where p.Player == Player.Player1
                                select p;

            var player2Pieces = from p in game.Pieces
                                where p.Player == Player.Player2
                                select p;

            Assert.AreEqual(12, player1Pieces.Count());
            Assert.AreEqual(12, player2Pieces.Count());

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

            foreach (var position in player1StartingPositions)
            {
                var piecesInPosition = from p in player1Pieces
                                       where p.Position.Equals(position)
                                       select p;
                
                Assert.NotNull(piecesInPosition);
                Assert.AreEqual(1, piecesInPosition.Count());
            }

            foreach (var position in player2StartingPositions)
            {
                var piecesInPosition = from p in player2Pieces
                                       where p.Position.Equals(position)
                                       select p;

                Assert.NotNull(piecesInPosition);
                Assert.AreEqual(1, piecesInPosition.Count());
            }
        }

        [Test]
        public void Player1CanMakeInitialMove()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Player2CannotMakeInitialMove()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void CanMakeValidBasicMove()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void CannotMakeInvalidBasicMove()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void CanMakeValidJumpMove()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void CannotMakeInvalidJumpMove()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Player1PieceBecomesKingedWhenBasicMovedToLastRow()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Player2PieceBecomesKingedWhenBasicMovedToLastRow()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Player1PieceBecomesKingedWhenJumpMovedToLastRow()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Player2PieceBecomesKingedWhenJumpMovedToLastRow()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void PlayerMustJumpIfJumpPossible()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void PlayerResumesGoIfJumpPossibleAfterJump()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Player1WinsIfNoPlayer2PiecesRemain()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Player2WinsIfNoPlayer1PiecesRemain()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void StalemateIfNoAvailableMoves()
        {
            throw new NotImplementedException();
        }
    }
}
