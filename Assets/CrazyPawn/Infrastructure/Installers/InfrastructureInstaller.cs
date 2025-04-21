using CrazyPawn.Infrastructure.AssetsManagement;
using CrazyPawn.Infrastructure.Factories;
using CrazyPawn.Services.Input;
using Zenject;

namespace CrazyPawn.Infrastructure.Installers
{
    public class InfrastructureInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ResourcesAssetsProvider>().AsSingle().NonLazy();
            BindServices();
            BindFactories();
        }

        private void BindServices()
        {
            Container.BindInterfacesTo<UnityInputService>().AsSingle().NonLazy();
        }

        private void BindFactories()
        {
            Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<PawnFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<ConnectionFactory>().AsSingle();
        }
    }
}