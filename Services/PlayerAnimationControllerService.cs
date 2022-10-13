using System.Collections;
using System.Collections.Generic;
using Scenes.BattleVsZombies.Generally;
using Scenes.BattleVsZombies.Interfaces.BaseInitialization;
using Scenes.BattleVsZombies.Store.DataProviders;
using Scenes.BattleVsZombies.Store.StaticData;
using Scenes.BattleVsZombies.Store.StaticData.Events;
using TestCardGame.Scripts.Interfaces.BaseInitialization;
using UnityEngine;

namespace Scenes.BattleVsZombies.Scripts.Services
{
    [CreateAssetMenu(menuName = "Game/Services/PlayerAnimationControllerService",
        fileName = "PlayerAnimationControllerService")]
    public class PlayerAnimationControllerService : BaseInitializable, ISubscriber
    {
        private readonly Queue<bool> _keyClicksQueue = new Queue<bool>();
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Jump = Animator.StringToHash("Jump");
        private static readonly int Grounded = Animator.StringToHash("Grounded");

        private const float JumpBreakTime = 0.5f;
        private const float StartMoveSpeedValue = 0f;
        private const byte EmptyClicksQueueCount = 0;
        private const byte MinimumValuableClicksCount = 1;
        private GameData _gameData;
        private PlayerDataProvider _playerDataProvider;
        private PlayerInputKeysEventData _playerInputKeysEventData;
        private PlayerStaticData _playerStaticData;
      
        private const string Name = "SomeGuy";

        public override void Construct(GameData gameData)
        {
            _gameData = gameData;
        }

        public override void Initialize()
        {
            _playerDataProvider = _gameData.GetDataProvider<PlayerDataProvider>();
            _playerInputKeysEventData = _playerDataProvider.PlayerStaticData.PlayerInputKeysEventData;
            _playerStaticData = _playerDataProvider.PlayerStaticData;
        }

        public void Subscribe()
        {
            _playerInputKeysEventData.WKeyDown += PlayerInputKeysEventDataMovementKeyDown;
            _playerInputKeysEventData.AKeyDown += PlayerInputKeysEventDataMovementKeyDown;
            _playerInputKeysEventData.SKeyDown += PlayerInputKeysEventDataMovementKeyDown;
            _playerInputKeysEventData.DKeyDown += PlayerInputKeysEventDataMovementKeyDown;
            _playerInputKeysEventData.WKeyReleased += PlayerInputKeysEventDataOnAnyKeyReleased;
            _playerInputKeysEventData.AKeyReleased += PlayerInputKeysEventDataOnAnyKeyReleased;
            _playerInputKeysEventData.SKeyReleased += PlayerInputKeysEventDataOnAnyKeyReleased;
            _playerInputKeysEventData.DKeyReleased += PlayerInputKeysEventDataOnAnyKeyReleased;
            _playerInputKeysEventData.SpaceKeyDown += PlayerInputSpaceKeyEventDataOnAnyKeyKeyDown;
        }

        public void Unsubscribe()
        {
            _playerInputKeysEventData.WKeyDown -= PlayerInputKeysEventDataMovementKeyDown;
            _playerInputKeysEventData.AKeyDown -= PlayerInputKeysEventDataMovementKeyDown;
            _playerInputKeysEventData.SKeyDown -= PlayerInputKeysEventDataMovementKeyDown;
            _playerInputKeysEventData.DKeyDown -= PlayerInputKeysEventDataMovementKeyDown;
            _playerInputKeysEventData.WKeyReleased -= PlayerInputKeysEventDataOnAnyKeyReleased;
            _playerInputKeysEventData.AKeyReleased -= PlayerInputKeysEventDataOnAnyKeyReleased;
            _playerInputKeysEventData.SKeyReleased -= PlayerInputKeysEventDataOnAnyKeyReleased;
            _playerInputKeysEventData.DKeyReleased -= PlayerInputKeysEventDataOnAnyKeyReleased;
            _playerInputKeysEventData.SpaceKeyDown -= PlayerInputSpaceKeyEventDataOnAnyKeyKeyDown;
        }

        private void PlayerInputKeysEventDataMovementKeyDown()
        {
            _keyClicksQueue.Enqueue(true);
            if (_keyClicksQueue.Count > MinimumValuableClicksCount) return;
            _playerDataProvider.AnimatorData.SetFloat(Speed, _playerStaticData.MoveSpeed);
        }

        private void PlayerInputKeysEventDataOnAnyKeyReleased()
        {
            _keyClicksQueue?.Dequeue();
            if (_keyClicksQueue?.Count == EmptyClicksQueueCount)
                StopMovementAnimation();
        }

        private void StopMovementAnimation()
        {
            _keyClicksQueue.Clear();
            _playerDataProvider.AnimatorData.SetFloat(Speed, StartMoveSpeedValue);
        }

        private void PlayerInputSpaceKeyEventDataOnAnyKeyKeyDown()
        {
            _gameData.StartCoroutine(TickJump());
        }

        private IEnumerator TickJump()
        {
            LaunchJumpState();
            yield return new WaitForSeconds(JumpBreakTime);
            BackToGroundState();
        }

        private void BackToGroundState()
        {
            _playerDataProvider.AnimatorData.SetBool(Jump, false);
            _playerDataProvider.AnimatorData.SetBool(Grounded, true);
        }

        private void LaunchJumpState()
        {
            _playerDataProvider.AnimatorData.SetBool(Grounded, false);
            _playerDataProvider.AnimatorData.SetBool(Jump, true);
        }
    }
}