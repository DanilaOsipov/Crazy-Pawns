using CrazyPawn.Gameplay.Pawn;
using System.Collections.Generic;

namespace CrazyPawn.Services.PawnsCache
{
    public class PawnsCacheService
    {
        private readonly List<Pawn> _pawns = new();

        public IEnumerable<Pawn> Pawns => _pawns;

        public void AddRange(IEnumerable<Pawn> pawns) => _pawns.AddRange(pawns);

        public void Remove(Pawn pawn) => _pawns.Remove(pawn);
    }
}