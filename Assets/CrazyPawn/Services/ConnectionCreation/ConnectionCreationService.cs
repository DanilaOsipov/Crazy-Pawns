using CrazyPawn.Gameplay.Connector;
using CrazyPawn.Services.AvailableConnections;
using CrazyPawn.Services.ConnectorSelection;
using System;
using Zenject;

namespace CrazyPawn.Services.ConnectionCreation
{
    public class ConnectionCreationService : IInitializable, IDisposable
    {
        private readonly ConnectorSelectionService _connectorSelectionService;
        private readonly AvailableConnectionsService _availableConnectionsService;

        public ConnectionCreationService(ConnectorSelectionService connectorSelectionService,
                                         AvailableConnectionsService availableConnectionsService)
        {
            _connectorSelectionService = connectorSelectionService;
            _availableConnectionsService = availableConnectionsService;
        }

        void IInitializable.Initialize()
        {
            _connectorSelectionService.OnDeselect += OnDeselectHandler;
        }

        void IDisposable.Dispose()
        {
            _connectorSelectionService.OnDeselect -= OnDeselectHandler;
        }

        private void OnDeselectHandler(Connector selection)
        {
            // TODO
        }
    }
}