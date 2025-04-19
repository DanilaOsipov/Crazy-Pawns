using Zenject;
using UnityEngine;

namespace CrazyPawn.Infrastructure.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private CrazyPawnSettings _settings;

        public override void InstallBindings()
        {
            Container.BindInstance(_settings);
        }
    }
}