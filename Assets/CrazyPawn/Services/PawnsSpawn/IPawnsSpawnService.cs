using CrazyPawn.Gameplay.Pawn;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;

namespace CrazyPawn.Services.PawnsSpawn
{
    public interface IPawnsSpawnService
    {
        UniTask<IEnumerable<Pawn>> Spawn();
    }
}