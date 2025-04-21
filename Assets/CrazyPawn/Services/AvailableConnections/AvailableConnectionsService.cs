using CrazyPawn.Gameplay.Connector;
using CrazyPawn.Gameplay.Pawn;
using CrazyPawn.Services.PawnsCache;
using System.Collections.Generic;
using System.Linq;

namespace CrazyPawn.Services.AvailableConnections
{
    public class AvailableConnectionsService
    {
        private readonly PawnsCacheService _pawnsCacheService;

        public AvailableConnectionsService(PawnsCacheService pawnsCacheService)
        {
            _pawnsCacheService = pawnsCacheService;
        }

        public List<Connector> GetAvailableConnections(Connector selection)
        {
            Pawn parentPawn = selection.GetComponentInParent<Pawn>();
            return _pawnsCacheService
                .Pawns
                .Where(pawn => pawn != parentPawn)
                .SelectMany(pawn => pawn.Connectors)
                .Where(connector => !connector.HasConnection(selection))
                .ToList();
        }

        public bool IsConnectionAvailable(Connector start, Connector end) => GetAvailableConnections(start)
                .Contains(end);
    }
}