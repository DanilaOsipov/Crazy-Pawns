using Zenject;
using UnityEngine;
using CrazyPawn.Services.PawnsSpawn;

namespace CrazyPawn.Infrastructure.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private CrazyPawnSettings _settings;
        [SerializeField] private InCircleSpawnService _pawnsSpawnService;

        public override void InstallBindings()
        {
            Container.BindInstance(_settings);
            Container.Bind<IPawnsSpawnService>().FromInstance(_pawnsSpawnService);
        }
    }
}