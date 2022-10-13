using Scenes.BattleVsZombies.Generally;
using Scenes.BattleVsZombies.Store.StaticData.BattleVsZombies.Events;
using UnityEngine;

namespace Scenes.BattleVsZombies.Store.StaticData.BattleVsZombies
{
    [CreateAssetMenu(menuName = "Game/StaticData/BattleVsZombies/ZombiesPoolStaticData",
        fileName = "ZombiesPoolStaticData")]
    public class ZombiesPoolStaticData : BaseObjectStaticData
    {
        [SerializeField] private ZombieBaseStaticData _zombieBaseStaticData;
        [SerializeField] private ZombieSpawnedEventData _zombieSpawnedEventData;
        public ZombieBaseStaticData ZombieBaseStaticData => _zombieBaseStaticData;
        public ZombieSpawnedEventData ZombieSpawnedEventData => _zombieSpawnedEventData;
    }
}