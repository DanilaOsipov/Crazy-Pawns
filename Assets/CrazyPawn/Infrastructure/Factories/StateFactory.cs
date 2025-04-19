using CrazyPawn.Infrastructure.GameStateMachine.States;
using Zenject;

namespace CrazyPawn.Infrastructure.Factories
{
    public class StateFactory
    {
        private readonly DiContainer _container;

        public StateFactory(DiContainer container) => _container = container;

        public T Create<T>() where T : IState => _container.Resolve<T>();
    }
}