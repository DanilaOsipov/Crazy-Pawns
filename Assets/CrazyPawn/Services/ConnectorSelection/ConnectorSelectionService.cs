using CrazyPawn.Gameplay.Connector;
using CrazyPawn.Gameplay.Interactable;
using CrazyPawn.Services.Input;
using CrazyPawn.Services.Interaction;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using Zenject;

namespace CrazyPawn.Services.ConnectorSelection
{
    public class ConnectorSelectionService : IInitializable, IDisposable
    {
        private readonly InteractionService _interactionService;
        private readonly IInputService _inputService;

        private const float SIMPLE_CLICK_THRESHOLD = 0.2f;

        private Connector _currentSelection;

        public ConnectorSelectionService(InteractionService interactionService, IInputService inputService)
        {
            _interactionService = interactionService;
            _inputService = inputService;
        }

        public Connector CurrentSelection
        {
            get => _currentSelection;
            set => UpdateSelection(value);
        }

        public event Action<Connector> OnSelect = delegate { };
        public event Action<Connector> OnDeselect = delegate { };

        void IInitializable.Initialize()
        {
            _interactionService.OnMouseOverInteractable += OnMouseOverInteractableHandler;
        }

        void IDisposable.Dispose()
        {
            _interactionService.OnMouseOverInteractable -= OnMouseOverInteractableHandler;
        }

        private void OnMouseOverInteractableHandler(IInteractable interactable)
        {
            if (_inputService.IsMouseDown && interactable is Connector connector)
            {
                CurrentSelection = connector;
                WaitDeselect().Forget();
            }
        }

        private async UniTaskVoid WaitDeselect()
        {
            _interactionService.OnMouseOverInteractable -= OnMouseOverInteractableHandler;

            var pressStartTime = Time.time;

            await UniTask.WaitUntil(() => !_inputService.IsMouseHold);

            var holdDuration = Time.time - pressStartTime;
            var isSimpleClick = holdDuration < SIMPLE_CLICK_THRESHOLD;

            if (isSimpleClick)
            {
                await UniTask.WaitUntil(() => _inputService.IsMouseDown);
                await UniTask.DelayFrame(1);
            }

            CurrentSelection = null;

            _interactionService.OnMouseOverInteractable += OnMouseOverInteractableHandler;
        }

        private void UpdateSelection(Connector value)
        {
            if (_currentSelection == value)
                return;

            var lastSelection = _currentSelection;
            _currentSelection = value;

            if (_currentSelection != null)
                OnSelect(_currentSelection);
            else
                OnDeselect(lastSelection);
        }
    }
}