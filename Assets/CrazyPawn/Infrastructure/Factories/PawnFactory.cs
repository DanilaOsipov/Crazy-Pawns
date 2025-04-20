using CrazyPawn.Gameplay.Pawn;
using CrazyPawn.Infrastructure.AssetsManagement;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CrazyPawn.Infrastructure.Factories
{
    public class PawnFactory
    {
        private const string PAWN_KEY = "Pawn";

        private readonly DiContainer _container;
        private readonly IAssetsProvider _assetsProvider;

        public PawnFactory(DiContainer container, IAssetsProvider assetsProvider)
        {
            _container = container;
            _assetsProvider = assetsProvider;
        }

        public async UniTask<Pawn> Create(Vector3 at)
        {
            var prefab = await _assetsProvider.Load<GameObject>(PAWN_KEY);
            return _container
                .InstantiatePrefab(prefab, at, Quaternion.identity, null)
                .GetComponent<Pawn>();
        }
    }
}