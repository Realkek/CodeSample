using Client;
using ECS.Components.Input;
using ECS.Components.Player;
using ECS.Interfaces;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECS.Systems.Player
{
    public class PlayerMoveSystem : IEcsRunSystem, IEcsBehavioursInputReceiver
    {
        private EcsWorld _ecsWorld;
        private EcsFilter _playerFilter;
        private EcsPool<PlayerMoveComponent> _playerMovePool;
        private EcsPool<PlayerTransformComponent> _playerTransformPool;
        private EcsPool<PlayerKeyboardInputComponent> _playerKeyboardInputPool;

        public void Run(IEcsSystems systems)
        {
            CheckBehaviourInputs(systems);
            foreach (int entity in _playerFilter)
            {
                ref var transformComponent = ref _playerTransformPool.Get(entity);
                ref var keyboardInputComponent = ref _playerKeyboardInputPool.Get(entity);
                ref var moveComponent = ref _playerMovePool.Get(entity);
                MoveByKey(keyboardInputComponent, transformComponent.TransformData);
            }
        }

        public void CheckBehaviourInputs(IEcsSystems systems)
        {
            _ecsWorld ??= systems.GetWorld();
            _playerFilter ??= _ecsWorld.Filter<PlayerTransformComponent>().Inc<PlayerMoveComponent>()
                .Inc<PlayerKeyboardInputComponent>().End();
            _playerTransformPool ??= _ecsWorld.GetPool<PlayerTransformComponent>();
            _playerKeyboardInputPool ??= _ecsWorld.GetPool<PlayerKeyboardInputComponent>();
            _playerMovePool ??= _ecsWorld.GetPool<PlayerMoveComponent>();
        }

        private void MoveByKey(PlayerKeyboardInputComponent playerKeyboardInputComponent, Transform transform)
        {
            if (playerKeyboardInputComponent.CurrentKeyInput != PlayerKeyboardInputComponent.KeyboardInputs.None)
                switch (playerKeyboardInputComponent.CurrentKeyInput)
                {
                    case PlayerKeyboardInputComponent.KeyboardInputs.IsForwardKeyDown:
                        transform.Translate(Vector3.forward * Time.deltaTime, Space.World);
                        break;
                    case PlayerKeyboardInputComponent.KeyboardInputs.IsLeftKeyDown:
                        transform.Translate(Vector3.left * Time.deltaTime, Space.World);
                        break;
                    case PlayerKeyboardInputComponent.KeyboardInputs.IsBackKeyDown:
                        transform.Translate(Vector3.back * Time.deltaTime, Space.World);
                        break;
                    case PlayerKeyboardInputComponent.KeyboardInputs.IsRightKeyDown:
                        transform.Translate(Vector3.right * Time.deltaTime, Space.World);
                        break;
                }
        }
    }
}