using CrazyPawn.Infrastructure.Factories;
using CrazyPawn.Services.Input;
using Zenject;

namespace CrazyPawn.Infrastructure.Installers
{
    public class InfrastructureInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
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
        }
    }
}