using CrazyPawn.Gameplay.Pawn;
using CrazyPawn.Services.PawnDrag;
using System;
using Zenject;

namespace CrazyPawn.Services.ConnectionUpdating
{
    public class ConnectionUpdatingService : IInitializable, IDisposable
    {
        private readonly PawnDragService _pawnDragService;

        public ConnectionUpdatingService(PawnDragService pawnDragService)
        {
            _pawnDragService = pawnDragService;
        }

        void IInitializable.Initialize()
        {
            _pawnDragService.OnPawnDrag += OnPawnDragHandler;
        }

        void IDisposable.Dispose()
        {
            _pawnDragService.OnPawnDrag -= OnPawnDragHandler;
        }

        private void OnPawnDragHandler(Pawn pawn) => pawn.RenderConnections();
    }
}