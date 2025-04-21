using CrazyPawn.Gameplay.Connection;
using CrazyPawn.Infrastructure.AssetsManagement;
using Zenject;

namespace CrazyPawn.Infrastructure.Factories
{
    public class ConnectionFactory : GameObjectFactory<Connection>
    {
        private const string CONNECTION_KEY = "Connection";

        public ConnectionFactory(DiContainer container, IAssetsProvider assetsProvider) : base(container, assetsProvider)
        {
        }

        protected override string GetPrefabKey() => CONNECTION_KEY;
    }
}