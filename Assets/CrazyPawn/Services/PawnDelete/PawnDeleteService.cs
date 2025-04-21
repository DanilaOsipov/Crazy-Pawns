using CrazyPawn.Gameplay.Pawn;
using CrazyPawn.Services.PawnGrounded;
using CrazyPawn.Services.PawnsCache;
using System;
using Zenject;

namespace CrazyPawn.Services.PawnDelete
{
    public class PawnDeleteService : IInitializable, IDisposable
    {
        private readonly PawnGroundedService _pawnGroundedService;
        private readonly CrazyPawnSettings _settings;
        private readonly PawnsCacheService _pawnsCacheService;

        public PawnDeleteService(PawnGroundedService pawnGroundedService,
                                 CrazyPawnSettings settings,
                                 PawnsCacheService pawnsCacheService)
        {
            _pawnGroundedService = pawnGroundedService;
            _settings = settings;
            _pawnsCacheService = pawnsCacheService;
        }

        void IInitializable.Initialize()
        {
            _pawnGroundedService.OnGroundedChanged += OnGroundedChangedHandler;
            _pawnGroundedService.OnPawnDragEnd += OnPawnDragEndHandler;
        }

        void IDisposable.Dispose()
        {
            _pawnGroundedService.OnGroundedChanged -= OnGroundedChangedHandler;
            _pawnGroundedService.OnPawnDragEnd -= OnPawnDragEndHandler;
        }

        private void OnGroundedChangedHandler(Pawn pawn, bool isGrounded)
        {
            if (isGrounded) pawn.MaterialHelper.SetDefaultMaterial();
            else pawn.MaterialHelper.SetMaterial(_settings.DeleteMaterial);
        }

        private void OnPawnDragEndHandler(Pawn pawn, bool isGrounded)
        {
            if (!isGrounded)
            {
                _pawnsCacheService.Remove(pawn);
                UnityEngine.Object.Destroy(pawn.gameObject);
            }
        }
    }
}