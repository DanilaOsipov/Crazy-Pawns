using CrazyPawn.Gameplay.Pawn;
using CrazyPawn.Infrastructure.Factories;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace CrazyPawn.Services.PawnsSpawn
{
    public class InCircleSpawnService : MonoBehaviour, IPawnsSpawnService
    {
        [SerializeField] private Transform _circleCenter;

        private CrazyPawnSettings _settings;
        private PawnFactory _pawnFactory;

        [Inject]
        private void Construct(CrazyPawnSettings settings, PawnFactory pawnFactory)
        {
            _settings = settings;
            _pawnFactory = pawnFactory;
        }

        async UniTask<IEnumerable<Pawn>> IPawnsSpawnService.Spawn() => await UniTask.WhenAll(Enumerable
                .Range(0, _settings.InitialPawnCount)
                .Select(_ => SpawnSingle()));

        private async UniTask<Pawn> SpawnSingle()
        {
            var centerPos = _circleCenter.position;
            var pawnDelta = Random.insideUnitCircle * _settings.InitialZoneRadius;
            var pawnPos = centerPos + new Vector3(pawnDelta.x, centerPos.y, pawnDelta.y);

            return await _pawnFactory.Create(pawnPos, Quaternion.identity);
        }
    }
}