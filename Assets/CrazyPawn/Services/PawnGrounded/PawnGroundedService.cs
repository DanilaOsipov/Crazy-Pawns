using CrazyPawn.Gameplay.Pawn;
using CrazyPawn.Services.PawnDrag;
using System;
using UnityEngine;
using Zenject;

namespace CrazyPawn.Services.PawnGrounded
{
    public class PawnGroundedService : IInitializable, IDisposable
    {
        private readonly PawnDragService _pawnDragService;

        private bool _isGrounded;

        public event Action<Pawn, bool> OnGroundedChanged = delegate { };
        public event Action<Pawn, bool> OnPawnDragEnd = delegate { };

        public PawnGroundedService(PawnDragService pawnDragService)
        {
            _pawnDragService = pawnDragService;
        }

        void IInitializable.Initialize()
        {
            _pawnDragService.OnPawnDragBegin += OnPawnDragBeginHandler;
            _pawnDragService.OnPawnDrag += OnPawnDragHandler;
            _pawnDragService.OnPawnDragEnd += OnPawnDragEndHandler;
        }

        void IDisposable.Dispose()
        {
            _pawnDragService.OnPawnDragBegin -= OnPawnDragBeginHandler;
            _pawnDragService.OnPawnDrag -= OnPawnDragHandler;
            _pawnDragService.OnPawnDragEnd -= OnPawnDragEndHandler;
        }

        private void OnPawnDragBeginHandler(Pawn pawn) => _isGrounded = RaycastGround(pawn);

        private void OnPawnDragHandler(Pawn pawn)
        {
            var isGrounded = RaycastGround(pawn);
            if (isGrounded != _isGrounded)
            {
                _isGrounded = isGrounded;
                OnGroundedChanged(pawn, _isGrounded);
            }
        }

        private void OnPawnDragEndHandler(Pawn pawn) => OnPawnDragEnd(pawn, _isGrounded);

        private bool RaycastGround(Pawn pawn)
        {
            var originOffset = Vector3.up * 0.1f;
            const float maxDistance = 0.2f;
            return Physics.Raycast(pawn.transform.position + originOffset, Vector3.down, maxDistance);
        }
    }
}