using System.Collections.Generic;
using Scenes.BattleVsZombies.Generally;
using Scenes.BattleVsZombies.Store.StaticData.BattleVsZombies;
using UnityEngine;

namespace Scenes.BattleVsZombies.Store.DataProviders.BattleVsZombies
{
    public class ZombiesPoolDataProvider : GameObjectDataProvider
    {
        [SerializeField] private ZombiesPoolStaticData _zombiesPoolStaticData;
        [SerializeField] List<Transform> _entityPlaceTransforms;
        public ZombiesPoolStaticData ZombiesPoolStaticData => _zombiesPoolStaticData;
        public List<Transform> EntityPlaceTransforms => _entityPlaceTransforms;
    }
}