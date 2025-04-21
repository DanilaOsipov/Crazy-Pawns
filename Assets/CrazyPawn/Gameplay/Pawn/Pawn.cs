using CrazyPawn.Gameplay.Interactable;
using UnityEngine;

namespace CrazyPawn.Gameplay.Pawn
{
    public class Pawn : MonoBehaviour, IInteractable
    {
        [SerializeField] private MaterialHelper.MaterialHelper _materialHelper;

        public MaterialHelper.MaterialHelper MaterialHelper => _materialHelper;
    }
}