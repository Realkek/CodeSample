using FractalWarriors.Providers;
using Game.Scripts.Providers.Systems;
using LeoEcsPhysics;
using Leopotam.EcsLite;
using Scenes.BattleVsZombies.ECS.Providers;
using Scenes.BattleVsZombies.Generally;
using UnityEngine;

namespace Scenes.BattleVsZombies.ECS
{
    public class EcsInitializer : MonoBehaviour
    {
        private EcsWorld _ecsWorld;
        private EcsSystems _systems;
        private ISystemProvider _initSystemProvider;
        private ISystemProvider _updateSystemProvider;
        private ISystemProvider _fixedUpdateSystemProvider;
        private GameData _sceneData;

        public void Construct(GameData sceneData)
        {
            _sceneData = sceneData;
        }

        public  void Initialize()
        {
            _ecsWorld = new EcsWorld();
            _systems = new EcsSystems(_ecsWorld);
            EcsPhysicsEvents.ecsWorld = _ecsWorld;
            _initSystemProvider = new InitSystemsProvider(_ecsWorld, _sceneData);
            _updateSystemProvider = new UpdateSystemsProvider(_ecsWorld);
            _fixedUpdateSystemProvider = new FixedUpdateSystemsProvider(_ecsWorld);
        }

        public  void Operate()
        {
        }

        public  void FixedOperate()
        {
           
        }

        public void OnDestroy()
        {
            _initSystemProvider.Dispose();
            _updateSystemProvider.Dispose();
            _fixedUpdateSystemProvider.Dispose();

            _ecsWorld.Destroy();
        }
    }
}