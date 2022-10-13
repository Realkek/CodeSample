using Scenes.BattleVsZombies.Generally;
using Scenes.BattleVsZombies.Store.StaticData.Events;
using UnityEngine;

namespace Scenes.BattleVsZombies.Store.StaticData
{
    [CreateAssetMenu(menuName = "Game/StaticData/PlayerStaticData",
        fileName = "PlayerStaticData")]
    public class PlayerStaticData : BaseObjectStaticData
    {
        [SerializeField] private int _moveSpeed;
        [SerializeField] private PlayerInputKeysEventData _playerInputKeysEventData;
        public PlayerInputKeysEventData PlayerInputKeysEventData => _playerInputKeysEventData;
        public int MoveSpeed => _moveSpeed;
    }
}