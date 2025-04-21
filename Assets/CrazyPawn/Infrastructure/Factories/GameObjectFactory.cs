using CrazyPawn.Infrastructure.AssetsManagement;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CrazyPawn.Infrastructure.Factories
{
    public abstract class GameObjectFactory<TComponent>
    {
        private readonly DiContainer _container;
        private readonly IAssetsProvider _assetsProvider;

        protected GameObjectFactory(DiContainer container, IAssetsProvider assetsProvider)
        {
            _container = container;
            _assetsProvider = assetsProvider;
        }

        public async UniTask<TComponent> Create() => await Create(Vector3.zero, Quaternion.identity);

        public async UniTask<TComponent> Create(Vector3 position, Quaternion rotation)
        {
            var prefab = await _assetsProvider.Load<GameObject>(GetPrefabKey());
            return _container
                .InstantiatePrefab(prefab, position, rotation, null)
                .GetComponent<TComponent>();
        }

        protected abstract string GetPrefabKey();
    }
}