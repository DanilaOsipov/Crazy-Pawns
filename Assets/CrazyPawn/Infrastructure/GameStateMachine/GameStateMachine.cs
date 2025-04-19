using CrazyPawn.Infrastructure.Factories;
using CrazyPawn.Infrastructure.GameStateMachine.States;
using System;
using System.Collections.Generic;
using Zenject;

namespace CrazyPawn.Infrastructure.GameStateMachine
{
    public class GameStateMachine : IInitializable
    {
        private readonly StateFactory _stateFactory;

        private Dictionary<Type, IState> _states;
        private IState _currentState;

        public GameStateMachine(StateFactory stateFactory) => _stateFactory = stateFactory;

        void IInitializable.Initialize()
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(LoadLevelState)] = _stateFactory.Create<LoadLevelState>(),
                [typeof(GameLoopState)] = _stateFactory.Create<GameLoopState>()
            };

            Enter<LoadLevelState>();
        }

        public void Enter<TState>() where TState : class, IState => ChangeState<TState>();

        private void ChangeState<TState>() where TState : class, IState
        {
            _currentState?.Exit();

            var state = GetState<TState>();
            _currentState = state;

            state.Enter();
        }

        private TState GetState<TState>() where TState : class, IState => _states[typeof(TState)] as TState;
    }
}