using CrazyPawn.Services.PawnsSpawn;

namespace CrazyPawn.Infrastructure.GameStateMachine.States
{
    public class LoadLevelState : IState
    {
        private readonly IPawnsSpawnService _pawnsSpawnService;
        private readonly GameStateMachine _stateMachine;

        async void IState.Enter()
        {
            await _pawnsSpawnService.Spawn();
            _stateMachine.Enter<GameLoopState>();
        }

        void IState.Exit()
        {
        }
    }
}