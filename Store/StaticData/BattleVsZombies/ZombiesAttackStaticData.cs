using Scenes.BattleVsZombies.Generally;
using Scenes.BattleVsZombies.Store.StaticData.BattleVsZombies.Events;
using UnityEngine;

namespace Scenes.BattleVsZombies.Store.StaticData.BattleVsZombies
{
    [CreateAssetMenu(menuName = "Game/StaticData/BattleVsZombies/ZombiesAttackStaticData",
        fileName = "ZombiesAttackStaticData")]
    public class ZombiesAttackStaticData : BaseObjectStaticData
    {
        [SerializeField] private StartAttackEventData _startAttackEventData;
        public StartAttackEventData StartAttackEventData => _startAttackEventData;
    }
}