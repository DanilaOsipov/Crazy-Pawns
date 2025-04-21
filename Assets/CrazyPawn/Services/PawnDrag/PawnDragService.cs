using CrazyPawn.Gameplay.Interactable;
using CrazyPawn.Gameplay.Pawn;
using CrazyPawn.Services.Input;
using CrazyPawn.Services.Interaction;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using Zenject;

namespace CrazyPawn.Services.PawnDrag
{
    public class PawnDragService : IInitializable, IDisposable
    {
        private readonly InteractionService _interactionService;
        private readonly IInputService _inputService;
        private readonly Camera _camera;

        private Vector3 _dragOffset;
        private Plane _dragPlane;

        public event Action<Pawn> OnPawnDragBegin = delegate { };
        public event Action<Pawn> OnPawnDrag = delegate { };
        public event Action<Pawn> OnPawnDragEnd = delegate { };

        public PawnDragService(InteractionService interactionService, IInputService inputService, Camera camera)
        {
            _interactionService = interactionService;
            _inputService = inputService;
            _camera = camera;
        }

        void IInitializable.Initialize()
        {
            _interactionService.OnMouseOverInteractable += OnBeginInteractionHandler;
        }

        void IDisposable.Dispose()
        {
            _interactionService.OnMouseOverInteractable -= OnBeginInteractionHandler;
        }

        private void OnBeginInteractionHandler(IInteractable interactable)
        {
            if (_inputService.IsMouseDown && interactable is Pawn pawn)
            {
                _dragPlane = new Plane(Vector3.up, pawn.transform.position);
                if (RaycastDragPlane(out var hitPoint))
                {
                    _dragOffset = pawn.transform.position - hitPoint;
                    Drag(pawn).Forget();
                }
            }
        }

        private async UniTaskVoid Drag(Pawn pawn)
        {
            OnPawnDragBegin(pawn);
            while (_inputService.IsMouseHold)
            {
                if (RaycastDragPlane(out var hitPoint))
                    pawn.transform.position = hitPoint + _dragOffset;

                OnPawnDrag(pawn);
                await UniTask.Yield();
            }
            OnPawnDragEnd(pawn);
        }

        private bool RaycastDragPlane(out Vector3 hitPoint)
        {
            Ray ray = _camera.ScreenPointToRay(_inputService.MousePosition);
            if (_dragPlane.Raycast(ray, out float enter))
            {
                hitPoint = ray.GetPoint(enter);
                return true;
            }

            hitPoint = Vector3.zero;
            return false;
        }
    }
}