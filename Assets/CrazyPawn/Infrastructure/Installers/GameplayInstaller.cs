using Zenject;
using UnityEngine;
using CrazyPawn.Services.PawnsSpawn;
using CrazyPawn.Services.Interaction;
using CrazyPawn.Services.PawnDelete;
using CrazyPawn.Services.PawnDrag;
using CrazyPawn.Services.PawnGrounded;
using CrazyPawn.Services.ConnectorSelection;
using CrazyPawn.Services.AvailableConnections;
using CrazyPawn.Services.ConnectionsHighlight;
using CrazyPawn.Services.ConnectionCreation;
using CrazyPawn.Services.PawnsCache;

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
            Container.BindInterfacesAndSelfTo<ConnectorSelectionService>().AsSingle();
            Container.BindInterfacesAndSelfTo<AvailableConnectionsService>().AsSingle();
            Container.BindInterfacesAndSelfTo<PawnsCacheService>().AsSingle();
            Container.BindInterfacesAndSelfTo<ConnectionsHighlightService>().AsSingle();
            Container.BindInterfacesAndSelfTo<ConnectionCreationService>().AsSingle();
        }
    }
}