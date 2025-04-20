using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CrazyPawn.Infrastructure.AssetsManagement
{
    public class ResourcesAssetsProvider : IAssetsProvider
    {
        async UniTask<T> IAssetsProvider.Load<T>(string key) => await Resources.LoadAsync<T>(key) as T;
    }
}