using Scenes.BattleVsZombies.Generally;
using Scenes.BattleVsZombies.Store.StaticData.BattleVsZombies;
using UnityEngine;

namespace Scenes.BattleVsZombies.Store.DataProviders.BattleVsZombies
{
    public class PlantsPoolDataProvider : GameObjectDataProvider
    {
        [SerializeField] private PlantsPoolStaticData _plantsPoolStaticData;
        public PlantsPoolStaticData PlantsPoolStaticData => _plantsPoolStaticData;
    }
}