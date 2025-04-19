using CrazyPawn.Infrastructure.GameStateMachine.States;
using Zenject;

namespace CrazyPawn.Infrastructure.Installers
{
    public class StateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<LoadLevelState>().AsSingle().NonLazy();
            Container.Bind<GameLoopState>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<GameStateMachine.GameStateMachine>().AsSingle();
        }
    }
}