using CrazyPawn.Gameplay.Connector;
using CrazyPawn.Infrastructure.Factories;
using CrazyPawn.Services.AvailableConnections;
using CrazyPawn.Services.ConnectorSelection;
using CrazyPawn.Services.Interaction;
using System;
using Zenject;

namespace CrazyPawn.Services.ConnectionCreation
{
    public class ConnectionCreationService : IInitializable, IDisposable
    {
        private readonly ConnectorSelectionService _connectorSelectionService;
        private readonly AvailableConnectionsService _availableConnectionsService;
        private readonly InteractionService _interactionService;
        private readonly ConnectionFactory _connectionFactory;

        public ConnectionCreationService(ConnectorSelectionService connectorSelectionService,
                                         AvailableConnectionsService availableConnectionsService,
                                         InteractionService interactionService,
                                         ConnectionFactory connectionFactory)
        {
            _connectorSelectionService = connectorSelectionService;
            _availableConnectionsService = availableConnectionsService;
            _interactionService = interactionService;
            _connectionFactory = connectionFactory;
        }

        void IInitializable.Initialize()
        {
            _connectorSelectionService.OnDeselect += OnDeselectHandler;
        }

        void IDisposable.Dispose()
        {
            _connectorSelectionService.OnDeselect -= OnDeselectHandler;
        }

        private async void OnDeselectHandler(Connector selection)
        {
            if (_interactionService.InteractableUnderMouse is Connector connector
                && _availableConnectionsService.IsConnectionAvailable(selection, connector))
            {
                var connection = await _connectionFactory.Create();
                connection.Initialize(selection, connector);
            }
        }
    }
}