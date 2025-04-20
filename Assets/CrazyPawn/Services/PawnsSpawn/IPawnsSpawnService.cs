using Cysharp.Threading.Tasks;

namespace CrazyPawn.Services.PawnsSpawn
{
    public interface IPawnsSpawnService
    {
        UniTask Spawn();
    }
}