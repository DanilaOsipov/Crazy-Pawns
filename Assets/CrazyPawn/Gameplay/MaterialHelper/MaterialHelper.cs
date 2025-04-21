using UnityEngine;

namespace CrazyPawn.Gameplay.MaterialHelper
{
    public class MaterialHelper : MonoBehaviour
    {
        [SerializeField] private Renderer[] _renderers;
        [SerializeField] private Material _defaultMaterial;

        public void SetMaterial(Material material)
        {
            foreach (var renderer in _renderers)
            {
                renderer.material = material;
            }
        }

        public void SetDefaultMaterial() => SetMaterial(_defaultMaterial);
    }
}