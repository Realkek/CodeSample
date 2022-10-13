using Scenes.BattleVsZombies.Generally;
using Scenes.BattleVsZombies.Store.DataProviders;
using Scenes.BattleVsZombies.Store.StaticData.Events;
using TestCardGame.Scripts.Interfaces.BaseInitialization;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scenes.BattleVsZombies.Services
{
    [CreateAssetMenu(menuName = "Game/Services/PlayerInputHandleService",
        fileName = "PlayerInputHandleService")]
    public class PlayerInputHandleService : BaseInitializable, IUpdatable
    {
        private PlayerDataProvider _playerDataProvider;
        private PlayerInputKeysEventData _playerInputKeysEventData;
        private GameData _gameData;

        public override void Construct(GameData gameData)
        {
            _gameData = gameData;
        }

        public override void Initialize()
        {
            _playerDataProvider = _gameData.GetDataProvider<PlayerDataProvider>();
            _playerInputKeysEventData =
                _playerDataProvider.PlayerStaticData.PlayerInputKeysEventData;
        }

        public void Operate()
        {
            CheckKeysDown();
            CheckKeysReleased();
        }

        private void CheckKeysReleased()
        {
            if (Keyboard.current.wKey.wasReleasedThisFrame)
            {
                _playerInputKeysEventData.TriggerWKeyReleased();
            }

            if (Keyboard.current.aKey.wasReleasedThisFrame)
            {
                _playerInputKeysEventData.TriggerAKeyReleased();
            }

            if (Keyboard.current.sKey.wasReleasedThisFrame)
            {
                _playerInputKeysEventData.TriggerSKeyReleased();
            }

            if (Keyboard.current.dKey.wasReleasedThisFrame)
            {
                _playerInputKeysEventData.TriggerDKeyReleased();
            }

            if (Keyboard.current.spaceKey.wasReleasedThisFrame)
            {
                _playerInputKeysEventData.TriggerSpaceKeyReleased();
            }
        }

        private void CheckKeysDown()
        {
            if (Keyboard.current.wKey.wasPressedThisFrame)
            {
                _playerInputKeysEventData.TriggerWKeyClick();
            }

            if (Keyboard.current.aKey.wasPressedThisFrame)
            {
                _playerInputKeysEventData.TriggerAKeyClick();
            }

            if (Keyboard.current.sKey.wasPressedThisFrame)
            {
                _playerInputKeysEventData.TriggerSKeyClick();
            }

            if (Keyboard.current.dKey.wasPressedThisFrame)
            {
                _playerInputKeysEventData.TriggerDKeyClick();
            }

            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                _playerInputKeysEventData.TriggerSpaceKeyClick();
            }

            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                _playerInputKeysEventData.TriggerEKeyDown();
            }
        }
    }
}