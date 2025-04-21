using Zenject;
using UnityEngine;
using CrazyPawn.Services.PawnsSpawn;
using CrazyPawn.Services.Interaction;
using CrazyPawn.Services.PawnDelete;
using CrazyPawn.Services.PawnDrag;
using CrazyPawn.Services.PawnGrounded;

namespace CrazyPawn.Infrastructure.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private CrazyPawnSettings _settings;
        [SerializeField] private InCircleSpawnService _pawnsSpawnService;
        [SerializeField] private Camera _camera;

        public override void InstallBindings()
        {
            Container.BindInstance(_settings);
            Container.Bind<IPawnsSpawnService>().FromInstance(_pawnsSpawnService);
            Container.BindInstance(_camera);
            Container.BindInterfacesAndSelfTo<InteractionService>().AsSingle();
            Container.BindInterfacesAndSelfTo<PawnDragService>().AsSingle();
            Container.BindInterfacesAndSelfTo<PawnGroundedService>().AsSingle();
            Container.BindInterfacesAndSelfTo<PawnDeleteService>().AsSingle();
        }
    }
}