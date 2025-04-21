using CrazyPawn.Gameplay.Connector;
using CrazyPawn.Services.AvailableConnections;
using CrazyPawn.Services.ConnectorSelection;
using System;
using Zenject;

namespace CrazyPawn.Services.ConnectionsHighlight
{
    public class ConnectionsHighlightService : IInitializable, IDisposable
    {
        private readonly ConnectorSelectionService _connectorSelectionService;
        private readonly AvailableConnectionsService _availableConnectionsService;
        private readonly CrazyPawnSettings _settings;

        public ConnectionsHighlightService(ConnectorSelectionService connectorSelectionService,
                                           AvailableConnectionsService availableConnectionsService,
                                           CrazyPawnSettings settings)
        {
            _connectorSelectionService = connectorSelectionService;
            _availableConnectionsService = availableConnectionsService;
            _settings = settings;
        }

        void IInitializable.Initialize()
        {
            _connectorSelectionService.OnSelect += OnSelectHandler;
            _connectorSelectionService.OnDeselect += OnDeselectHandler;
        }

        void IDisposable.Dispose()
        {
            _connectorSelectionService.OnSelect -= OnSelectHandler;
            _connectorSelectionService.OnDeselect -= OnDeselectHandler;
        }

        private void OnSelectHandler(Connector selection) => _availableConnectionsService
                .GetAvailableConnections(selection)
                .ForEach(e => e.MaterialHelper.SetMaterial(_settings.ActiveConnectorMaterial));

        private void OnDeselectHandler(Connector selection) => _availableConnectionsService
                .GetAvailableConnections(selection)
                .ForEach(e => e.MaterialHelper.SetDefaultMaterial());
    }
}