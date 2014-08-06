using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Tests
{
    [TestFixture]
    class PiecePositionTests
    {
        [Test]
        public void CanCreateValidPosition()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var position = new PiecePosition(i, j);
                    Assert.NotNull(position);
                }
            }
        }

        [Test]
        public void CannotCreateInvalidPosition()
        {
             Assert.Throws<ArgumentException>(() => new PiecePosition(-1, 0));
             Assert.Throws<ArgumentException>(() => new PiecePosition(0, -1));
             Assert.Throws<ArgumentException>(() => new PiecePosition(-1, -1));
             Assert.Throws<ArgumentException>(() => new PiecePosition(8, 0));
             Assert.Throws<ArgumentException>(() => new PiecePosition(0, 8));
             Assert.Throws<ArgumentException>(() => new PiecePosition(8, 8));
        }
    }
}
