using System;
using System.Linq;
using UnityEngine;

namespace CrazyPawn.Gameplay.Connection
{
    public class Connection : MonoBehaviour
    {
        [SerializeField] private LineRenderer _renderer;

        private Connector.Connector[] _connectors;

        public void Initialize(Connector.Connector start, Connector.Connector end)
        {
            _connectors = new[] { start, end };
            Array.ForEach(_connectors, e => e.Add(this));
            _renderer.positionCount = _connectors.Length;
            Render();
        }

        public void Render() => _renderer.SetPositions(_connectors.Select(e => e.transform.position).ToArray());

        public bool HasConnector(Connector.Connector connector) => _connectors.Contains(connector);

        public void Break()
        {
            Array.ForEach(_connectors, e => e.Remove(this));
            Destroy(gameObject);
        }
    }
}