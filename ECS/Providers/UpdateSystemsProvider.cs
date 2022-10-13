using Leopotam.EcsLite;
using Scenes.BattleVsZombies.ECS.Systems.Inputs;

namespace Game.Scripts.Providers.Systems
{
    public class UpdateSystemsProvider : ISystemProvider
    {
        private readonly EcsSystems _updateSystems;
        
        public UpdateSystemsProvider(EcsWorld ecsWorld)
        {
            _updateSystems = new EcsSystems(ecsWorld);
            _updateSystems.Add(new MouseInputSystem());
            _updateSystems.Add(new PlayerKeyboardSystem());
            _updateSystems.Init();
        }

        public void Dispose()
        {
            _updateSystems.Destroy();
        }

        public void Operate()
        {
            _updateSystems.Run();
        }
    }
}