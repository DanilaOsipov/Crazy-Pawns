using CrazyPawn.Gameplay.Pawn;
using CrazyPawn.Infrastructure.AssetsManagement;
using Zenject;

namespace CrazyPawn.Infrastructure.Factories
{
    public class PawnFactory : GameObjectFactory<Pawn>
    {
        private const string PAWN_KEY = "Pawn";

        public PawnFactory(DiContainer container, IAssetsProvider assetsProvider) : base(container, assetsProvider)
        {
        }

        protected override string GetPrefabKey() => PAWN_KEY;
    }
}