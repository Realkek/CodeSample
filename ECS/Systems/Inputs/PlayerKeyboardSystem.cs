using ECS.Components.Input;
using ECS.Interfaces;
using Leopotam.EcsLite;
using UnityEngine.InputSystem;

namespace Scenes.BattleVsZombies.ECS.Systems.Inputs
{
    sealed class PlayerKeyboardSystem : IEcsRunSystem, IEcsBehavioursInputReceiver
    {
        private EcsWorld _ecsWorld;
        private EcsFilter _keyboardFilter;
        private EcsPool<PlayerKeyboardInputComponent> _keyboardInputPool;

        public void Run(IEcsSystems systems)
        {
            CheckBehaviourInputs(systems);
            foreach (int entity in _keyboardFilter)
            {
                PlayerKeyboardInputComponent playerKeyboardInputComponent = _keyboardInputPool.Get(entity);
                HandleKeyboardInput(playerKeyboardInputComponent);
            }
        }

        public void CheckBehaviourInputs(IEcsSystems systems)
        {
            _ecsWorld ??= systems.GetWorld();
            _keyboardFilter ??= _ecsWorld.Filter<PlayerKeyboardInputComponent>().End();
            _keyboardInputPool ??= _ecsWorld.GetPool<PlayerKeyboardInputComponent>();
        }

        private static void HandleKeyboardInput(PlayerKeyboardInputComponent playerKeyboardInputComponent)
        {
            if (Keyboard.current.wKey.wasPressedThisFrame)
                playerKeyboardInputComponent.CurrentKeyInput =
                    PlayerKeyboardInputComponent.KeyboardInputs.IsForwardKeyDown;

            if (Keyboard.current.aKey.wasPressedThisFrame)
                playerKeyboardInputComponent.CurrentKeyInput =
                    PlayerKeyboardInputComponent.KeyboardInputs.IsLeftKeyDown;

            if (Keyboard.current.sKey.wasPressedThisFrame)
                playerKeyboardInputComponent.CurrentKeyInput =
                    PlayerKeyboardInputComponent.KeyboardInputs.IsBackKeyDown;

            if (Keyboard.current.dKey.wasPressedThisFrame)
                playerKeyboardInputComponent.CurrentKeyInput =
                    PlayerKeyboardInputComponent.KeyboardInputs.IsRightKeyDown;
        }
    }
}