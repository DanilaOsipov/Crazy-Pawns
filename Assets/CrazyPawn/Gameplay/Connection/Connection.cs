using UnityEngine;

namespace CrazyPawn.Gameplay.Connection
{
    public class Connection : MonoBehaviour
    {
        private Connector.Connector _start;
        private Connector.Connector _end;

        public void Initialize(Connector.Connector start, Connector.Connector end)
        {
            _start = start;
            _end = end;
        }
    }
}