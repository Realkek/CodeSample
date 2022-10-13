using Client;
using ECS.Components.Input;
using ECS.Components.Player;
using Game.Scripts.ECS.Components.Inputs;
using Game.Scripts.ECS.Components.Player;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Scenes.BattleVsZombies.Store.DataProviders;
using UnityEngine;

namespace ECS.Systems.Player
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private readonly Transform _transformData;
        private readonly float _moveSpeed;

        private EcsPoolInject<PlayerComponent> _playerPool;
        private EcsPoolInject<PlayerTransformComponent> _transformPool;
        private EcsPoolInject<PlayerMoveComponent> _movementPool;
        private EcsPoolInject<MouseInputComponent> _mouseInputPool;
        private EcsPoolInject<PlayerKeyboardInputComponent> _keyboardInputPool;

        public PlayerInitSystem(PlayerDataProvider playerDataProvider)
        {
            /*_transformData = playerDataProvider.TransformData;
            _moveSpeed = playerDataProvider.MoveSpeed;*/
        }

        public void Init(IEcsSystems systems)
        {
            EcsWorld ecsWorld = systems.GetWorld();
            int playerEntity = ecsWorld.NewEntity();

            _transformPool.Value.Add(playerEntity);
            _movementPool.Value.Add(playerEntity);
            _playerPool.Value.Add(playerEntity);
            _mouseInputPool.Value.Add(playerEntity);
            _keyboardInputPool.Value.Add(playerEntity);

            ref PlayerTransformComponent playerTransformComponent = ref _transformPool.Value.Get(playerEntity);
            playerTransformComponent.TransformData = _transformData;

            ref PlayerComponent playerComponent = ref _playerPool.Value.Get(playerEntity);
            playerComponent.Position = _transformData.position;
            playerComponent.Speed = _moveSpeed;
        }
    }
}