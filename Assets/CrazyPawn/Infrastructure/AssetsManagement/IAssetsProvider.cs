using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CrazyPawn.Infrastructure.AssetsManagement
{
    public interface IAssetsProvider
    {
        UniTask<T> Load<T>(string key) where T : Object;
    }
}