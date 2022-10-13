using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Scenes.BattleVsZombies.Interfaces.BaseInitialization;
using Scenes.BattleVsZombies.Store.DataProviders.BattleVsZombies;
using Scenes.BattleVsZombies.Store.StaticData.BattleVsZombies.Events;
using UnityEngine;

namespace Scenes.BattleVsZombies.Services.BattleVsZombies
{
    [CreateAssetMenu(menuName = "Game/Services/BattleVsZombies/ZombiesPoolService",
        fileName = "ZombiesPoolService")]
    public class ZombiesPoolService : ObjectPoolService, ISubscriber, IDisabler
    {
        private ZombiesPoolDataProvider _zombiesPoolDataProvider;
        private ZombiesAttackWaveBoxDataProvider _zombiesAttackWaveBoxDataProvider;
        private StartAttackEventData _startAttackEventData;
        private const float ZombieSpawnInterval = 2.5f;
        private ZombieSpawnedEventData _zombieSpawnedEventData;
        private List<Transform> _entityPlaceTransforms;

        public override void Initialize()
        {
            base.Initialize();

            _entityPlaceTransforms = new List<Transform>();
            _zombiesPoolDataProvider = GameData.GetDataProvider<ZombiesPoolDataProvider>();
            _zombiesAttackWaveBoxDataProvider = GameData.GetDataProvider<ZombiesAttackWaveBoxDataProvider>();
            CurrentPrefab = _zombiesPoolDataProvider.ZombiesPoolStaticData.ZombieBaseStaticData.Prefab;
            _startAttackEventData = _zombiesAttackWaveBoxDataProvider.ZombiesAttackStaticData.StartAttackEventData;
            _zombieSpawnedEventData = _zombiesPoolDataProvider.ZombiesPoolStaticData.ZombieSpawnedEventData;
            CurrentContainerTransform = _zombiesPoolDataProvider.transform;
            _entityPlaceTransforms = _zombiesPoolDataProvider.EntityPlaceTransforms;
            GetZombiePlacePositions();
        }

        private void GetZombiePlacePositions()
        {
            foreach (var elementPosition in _entityPlaceTransforms.Select(entityPlaceTransform =>
                         entityPlaceTransform.position))
                EntityPlacePositions.Add(elementPosition);
        }

        public void Disable()
        {
            GameData.StopAllCoroutines();
        }

        public void Subscribe()
        {
            _startAttackEventData.AttackStarted += OnAttackStarted;
        }

        public void Unsubscribe()
        {
            _startAttackEventData.AttackStarted -= OnAttackStarted;
        }

        private void OnAttackStarted()
        {
            GameData.StartCoroutine(ZombieSpawner());
        }

        private IEnumerator ZombieSpawner()
        {
            while (true)
            {
                CurrentPositionNumber = ChooseNewObjectInstancePositionNumber();
                ZombieDataProvider zombie = GetObject() as ZombieDataProvider;
                if (zombie != null)
                    _zombieSpawnedEventData.TriggerZombieSpawned(zombie);
                yield return new WaitForSeconds(ZombieSpawnInterval);
            }
        }
    }
}