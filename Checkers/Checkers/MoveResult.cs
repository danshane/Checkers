using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    /// <summary>
    /// An enumeration of the possible results of a Move.
    /// </summary>
    public enum MoveResult
    {
        Unknown,
        Player1ToMoveNext,
        Player2ToMoveNext,
        Player1Wins,
        Player2Wins,
        Stalemate,
    }
}
