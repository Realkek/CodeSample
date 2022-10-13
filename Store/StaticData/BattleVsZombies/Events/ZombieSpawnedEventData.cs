using System;
using Scenes.BattleVsZombies.Store.DataProviders.BattleVsZombies;
using UnityEngine;

namespace Scenes.BattleVsZombies.Store.StaticData.BattleVsZombies.Events
{
    [CreateAssetMenu(menuName = "Game/StaticData/BattleVsZombies/EventsData/ZombieSpawnedEventData",
        fileName = "ZombieSpawnedEventData")]
    public class ZombieSpawnedEventData : ScriptableObject
    {
        public event Action<ZombieDataProvider> ZombieSpawned;
        public event Action<ZombieDataProvider> ZombieDespawned;

        public void TriggerZombieSpawned(ZombieDataProvider zombieDataProvider)
        {
            ZombieSpawned?.Invoke(zombieDataProvider);
        }

        public void TriggerZombieDespawned(ZombieDataProvider zombieDataProvider)
        {
            ZombieDespawned?.Invoke(zombieDataProvider);
        }
    }
}