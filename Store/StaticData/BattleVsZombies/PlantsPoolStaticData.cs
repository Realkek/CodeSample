using System.Collections.Generic;
using Scenes.BattleVsZombies.Store.StaticData.BattleVsZombies.Events;
using UnityEngine;

namespace Scenes.BattleVsZombies.Store.StaticData.BattleVsZombies
{
    [CreateAssetMenu(menuName = "Game/StaticData/BattleVsZombies/PlantsPoolStaticData",
        fileName = "PlantsPoolStaticData")]
    public class PlantsPoolStaticData : ScriptableObject
    {
        [SerializeField] private List<PlantBaseStaticData> _plantsBaseStaticData;
        [SerializeField] private PlantSpawnedEventData _plantSpawnedEventData;
        public List<PlantBaseStaticData> PlantsBaseStaticData => _plantsBaseStaticData;
        public PlantSpawnedEventData PlantSpawnedEventData => _plantSpawnedEventData;
    }
}