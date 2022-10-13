using Game.Scripts.ECS.Components.Inputs;
using Leopotam.EcsLite;
using UnityEngine;

namespace Scenes.BattleVsZombies.ECS.Systems.Inputs
{
    public class MouseInputSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var ecsWorld = systems.GetWorld();
            
            var filter = ecsWorld.Filter<MouseInputComponent>().End();
            var playerInputPool = ecsWorld.GetPool<MouseInputComponent>();

            var mousePositionChanged = TryGetMousePosition(out var mousePosition);
            
            foreach (var entity in filter)
            {
                ref var playerInputComponent = ref playerInputPool.Get(entity);

                if (mousePositionChanged)
                {
                    playerInputComponent.InputResult = mousePosition;
                }
            }
        }

        private bool TryGetMousePosition(out Vector3 mousePosition)
        {
            mousePosition = Vector3.zero;

            if (!Input.GetMouseButtonDown(0))
            {
                return false;
            }
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out var hit))
            {
                return false;
            }

            mousePosition = hit.point;
            return true;
        }
    }
}