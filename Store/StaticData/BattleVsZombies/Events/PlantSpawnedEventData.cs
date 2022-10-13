using System;
using Scenes.BattleVsZombies.Store.DataProviders.BattleVsZombies;
using UnityEngine;

namespace Scenes.BattleVsZombies.Store.StaticData.BattleVsZombies.Events
{
    [CreateAssetMenu(menuName = "Game/StaticData/BattleVsZombies/EventsData/PlantSpawnedEventData",
        fileName = "PlantSpawnedEventData")]
    public class PlantSpawnedEventData : ScriptableObject
    {
        
        private event Action<PlantDataProvider> PlantSpawned;
        private event Action<PlantDataProvider> PlantDespawned;

        public void TriggerPlantSpawned(PlantDataProvider plantDataProvider)
        {
            PlantSpawned?.Invoke(plantDataProvider);
        }

        public void TriggerPlantDespawned(PlantDataProvider plantDataProvider)
        {
            PlantDespawned?.Invoke(plantDataProvider);
        }
    }
}