using CrazyPawn.Gameplay.Interactable;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CrazyPawn.Gameplay.Connector
{
    public class Connector : MonoBehaviour, IInteractable
    {
        [SerializeField] private MaterialHelper.MaterialHelper _materialHelper;

        private readonly List<Connection.Connection> _connections = new();

        public MaterialHelper.MaterialHelper MaterialHelper => _materialHelper;

        public void Add(Connection.Connection connection) => _connections.Add(connection);

        public void Remove(Connection.Connection connection) => _connections.Remove(connection);

        public bool HasConnection(Connector to) => _connections.Any(e => e.HasConnector(to));

        public void RenderConnections() => _connections.ForEach(e => e.Render());

        public void BreakConnections() => _connections.ToList().ForEach(e => e.Break());
    }
}