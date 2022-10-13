using System.Collections.Generic;
using System.Linq;
using Scenes.BattleVsZombies.Interfaces.BaseInitialization;
using Scenes.BattleVsZombies.Store.DataProviders;
using Scenes.BattleVsZombies.Store.DataProviders.BattleVsZombies;
using Scenes.BattleVsZombies.Store.StaticData.BattleVsZombies;
using Scenes.BattleVsZombies.Store.StaticData.BattleVsZombies.Events;
using Scenes.BattleVsZombies.Store.StaticData.Events;
using UnityEngine;

namespace Scenes.BattleVsZombies.Services.BattleVsZombies
{
    [CreateAssetMenu(menuName = "Game/Services/BattleVsZombies/PlantsPoolService",
        fileName = "PlantsPoolService")]
    public class PlantsPoolService : ObjectPoolService, ISubscriber
    {
        private PlayerDataProvider _playerDataProvider;
        private PlantsPoolDataProvider _plantsPoolDataProvider;
        private List<PlantBaseStaticData> _gameObjectsStaticData;
        private PlayerInputKeysEventData _playerInputKeysEventData;
        private PlantSpawnedEventData _plantSpawnedEventData;

        public override void Initialize()
        {
            base.Initialize();
            _playerDataProvider = GameData.GetDataProvider<PlayerDataProvider>();
            _plantsPoolDataProvider = GameData.GetDataProvider<PlantsPoolDataProvider>();
            _playerInputKeysEventData =
                _playerDataProvider.PlayerStaticData.PlayerInputKeysEventData;
            _plantSpawnedEventData = _plantsPoolDataProvider.PlantsPoolStaticData.PlantSpawnedEventData;
            _gameObjectsStaticData = _plantsPoolDataProvider.PlantsPoolStaticData.PlantsBaseStaticData;
        }

        public void Subscribe()
        {
            _playerInputKeysEventData.EKeyDown += PlayerInputKeysEventDataOnEKeyDown;
        }

        public void Unsubscribe()
        {
            _playerInputKeysEventData.EKeyDown -= PlayerInputKeysEventDataOnEKeyDown;
        }

        protected override int ChooseNewObjectInstancePositionNumber()
        {
            return EntityPlacePositions.Count;
        }

        private void PlayerInputKeysEventDataOnEKeyDown()
        {
            CurrentPositionNumber = ChooseNewObjectInstancePositionNumber();
            SelectPlant();
            ChooseSpawnPosition();
            SpawnPlant();
        }

        private void SelectPlant()
        {
            var randomNumber = Random.Range(0, _gameObjectsStaticData.Count - 1);
            CurrentPrefab = _gameObjectsStaticData.ElementAtOrDefault(randomNumber)?.Prefab;
        }

        private void ChooseSpawnPosition()
        {
            var playerTransform = _playerDataProvider.transform;
            CurrentSpawnPosition = playerTransform.position + playerTransform.transform.forward;
        }

        private void SpawnPlant()
        {
            EntityPlacePositions.Add(CurrentSpawnPosition);
            PlantDataProvider plant = GetObject() as PlantDataProvider;

            if (plant != null)
                _plantSpawnedEventData.TriggerPlantSpawned(plant);
        }
    }
}