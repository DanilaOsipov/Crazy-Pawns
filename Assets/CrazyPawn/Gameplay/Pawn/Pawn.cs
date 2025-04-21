using CrazyPawn.Gameplay.Interactable;
using System.Collections.Generic;
using UnityEngine;

namespace CrazyPawn.Gameplay.Pawn
{
    public class Pawn : MonoBehaviour, IInteractable
    {
        [SerializeField] private MaterialHelper.MaterialHelper _materialHelper;
        [SerializeField] private Connector.Connector[] _connectors;

        public MaterialHelper.MaterialHelper MaterialHelper => _materialHelper;
        public IEnumerable<Connector.Connector> Connectors => _connectors;
    }
}