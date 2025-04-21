using CrazyPawn.Services.PawnsCache;
using CrazyPawn.Services.PawnsSpawn;

namespace CrazyPawn.Infrastructure.GameStateMachine.States
{
    public class LoadLevelState : IState
    {
        private readonly IPawnsSpawnService _pawnsSpawnService;
        private readonly GameStateMachine _stateMachine;
        private readonly PawnsCacheService _pawnsCacheService;

        public LoadLevelState(IPawnsSpawnService pawnsSpawnService,
                              GameStateMachine stateMachine,
                              PawnsCacheService pawnsCacheService)
        {
            _pawnsSpawnService = pawnsSpawnService;
            _stateMachine = stateMachine;
            _pawnsCacheService = pawnsCacheService;
        }

        async void IState.Enter()
        {
            _pawnsCacheService.AddRange(await _pawnsSpawnService.Spawn());
            _stateMachine.Enter<GameLoopState>();
        }

        void IState.Exit()
        {
        }
    }
}