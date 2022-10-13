using Scenes.BattleVsZombies.Generally;
using Scenes.BattleVsZombies.Store.StaticData.BattleVsZombies;
using UnityEngine;

namespace Scenes.BattleVsZombies.Store.DataProviders.BattleVsZombies
{
    public class ZombiesAttackWaveBoxDataProvider : GameObjectDataProvider
    {
        [SerializeField] private ZombiesAttackStaticData _zombiesAttackStaticData;
        public ZombiesAttackStaticData ZombiesAttackStaticData => _zombiesAttackStaticData;
    }
}
