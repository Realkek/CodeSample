using Game.Scripts.Providers.Systems;
using Leopotam.EcsLite;
using Scenes.BattleVsZombies.Generally;

namespace Scenes.BattleVsZombies.ECS.Providers
{
    public class InitSystemsProvider : ISystemProvider
    {
        private readonly EcsSystems _initSystems;

        public InitSystemsProvider(EcsWorld ecsWorld, GameData sceneData)
        {
            _initSystems = new EcsSystems(ecsWorld);
            _initSystems.Add(new PlayerInitSystem(sceneData.PlayerDataProvider));
            _initSystems.Init();
        }

    }
}