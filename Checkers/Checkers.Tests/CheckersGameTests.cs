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
            var game = new CheckersGame();

            var piecePosition = new PiecePosition(2, 0);
            var destinationPosition = new PiecePosition(3, 1);

            var pieceToMove = (from p in game.Pieces
                               where p.Player == Player.Player1
                               && p.Position.Equals(piecePosition)
                               select p).FirstOrDefault();

            Assert.NotNull(pieceToMove);

            var moveResult = game.MovePiece(Player.Player1, pieceToMove, destinationPosition);

            Assert.AreEqual(MoveResult.Player2ToMoveNext, moveResult);
        }

        [Test]
        public void Player2CannotMakeInitialMove()
        {
            var game = new CheckersGame();

            var piecePosition = new PiecePosition(5, 1);
            var destinationPosition = new PiecePosition(4, 0);

            var pieceToMove = (from p in game.Pieces
                               where p.Player == Player.Player2
                               && p.Position.Equals(piecePosition)
                               select p).FirstOrDefault();

            Assert.NotNull(pieceToMove);

            Assert.Throws<CheckersMoveException>(() => game.MovePiece(Player.Player2, pieceToMove, destinationPosition));
        }

        [Test]
        public void CannotMoveWithoutSpecifyingAPlayer()
        {
            var game = new CheckersGame();

            var piecePosition = new PiecePosition(2, 0);
            var destinationPosition = new PiecePosition(3, 1);

            var pieceToMove = (from p in game.Pieces
                               where p.Player == Player.Player1
                               && p.Position.Equals(piecePosition)
                               select p).FirstOrDefault();

            Assert.NotNull(pieceToMove);

            Assert.Throws<ArgumentException>(() => game.MovePiece(Player.Unknown, pieceToMove, destinationPosition));
        }

        [Test]
        public void CannotMoveWithoutSpecifyingAPiece()
        {
            var game = new CheckersGame();

            var destinationPosition = new PiecePosition(3, 1);

            Assert.Throws<ArgumentNullException>(() => game.MovePiece(Player.Player1, null, destinationPosition));
        }

        [Test]
        public void CannotMoveWithoutSpecifyingANewPosition()
        {
            var game = new CheckersGame();

            var piecePosition = new PiecePosition(2, 0);

            var pieceToMove = (from p in game.Pieces
                               where p.Player == Player.Player1
                               && p.Position.Equals(piecePosition)
                               select p).FirstOrDefault();

            Assert.NotNull(pieceToMove);

            Assert.Throws<ArgumentNullException>(() => game.MovePiece(Player.Player1, pieceToMove, null));

        }

        [Test]
        public void CannotMoveAPieceNotInPlay()
        {
            var game = new CheckersGame();

            var destinationPosition = new PiecePosition(3, 1);

            var pieceToMove = new CheckersPiece(Player.Player1, new PiecePosition(4, 4));

            Assert.Throws<CheckersMoveException>(() => game.MovePiece(Player.Player1, pieceToMove, destinationPosition));

        }

        [Test]
        public void CanMakeValidBasicMove()
        {
            var game = new CheckersGame();

            var gamePieces = new CheckersPiece[]
            {
                new CheckersPiece(Player.Player1, new PiecePosition(0, 0)),
                new CheckersPiece(Player.Player2, new PiecePosition(7, 7)),
            };

            game.Pieces = gamePieces;

            var destPosition1 = new PiecePosition(1, 1);
            var destPosition2 = new PiecePosition(6, 6);

            var moveResult = game.MovePiece(Player.Player1, gamePieces[0], destPosition1);
            Assert.AreEqual(destPosition1, gamePieces[0].Position);
            Assert.AreEqual(MoveResult.Player2ToMoveNext, moveResult);

            moveResult = game.MovePiece(Player.Player2, gamePieces[1], new PiecePosition(6, 6));
            Assert.AreEqual(destPosition2, gamePieces[1].Position);
            Assert.AreEqual(MoveResult.Player1ToMoveNext, moveResult);
        }

        [Test]
        public void CannotMakeInvalidBasicMove()
        {
            var game = new CheckersGame();

            var originalPosition1 = new PiecePosition(0, 0);
            var originalPosition2 = new PiecePosition(7, 7);
            var gamePieces = new CheckersPiece[]
            {
                new CheckersPiece(Player.Player1, originalPosition1),
                new CheckersPiece(Player.Player2,originalPosition2),
            };

            game.Pieces = gamePieces;

            var destPosition1 = new PiecePosition(0, 1);
            var destPosition2 = new PiecePosition(7, 6);

            Assert.Throws<CheckersMoveException>(() => game.MovePiece(Player.Player1, gamePieces[0], destPosition1));
            Assert.AreEqual(originalPosition1, gamePieces[0].Position);
        }

        [Test]
        public void CannotMoveOntoExistingPiece()
        {
            var game = new CheckersGame();

            var gamePieces = new CheckersPiece[]
            {
                new CheckersPiece(Player.Player1, new PiecePosition(0, 0)),
                new CheckersPiece(Player.Player2, new PiecePosition(1, 1)),
            };

            game.Pieces = gamePieces;
            
            Assert.Throws<CheckersMoveException>(() => game.MovePiece(Player.Player1, gamePieces[0], new PiecePosition(1, 1)));
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
