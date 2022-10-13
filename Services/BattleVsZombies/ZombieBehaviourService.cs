using System.Collections.Generic;
using Scenes.BattleVsZombies.Generally;
using Scenes.BattleVsZombies.Interfaces.BaseInitialization;
using Scenes.BattleVsZombies.Store;
using Scenes.BattleVsZombies.Store.DataProviders.BattleVsZombies;
using Scenes.BattleVsZombies.Store.StaticData.BattleVsZombies.Events;
using Scenes.BattleVsZombies.Store.StaticData.Events;
using UnityEngine;

namespace Scenes.BattleVsZombies.Services.BattleVsZombies
{
    [CreateAssetMenu(menuName = "Game/Services/BattleVsZombies/ZombieBehaviourService",
        fileName = "ZombieBehaviourService")]
    public class ZombieBehaviourService : BaseInitializable, ISubscriber, IUpdatableFixed
    {
        private MainEntitiesStore _mainEntitiesStore;
        private ZombiesPoolDataProvider _zombiesPoolDataProvider;
        private EntityMoveEventData _entityMoveEventData;
        private ZombieSpawnedEventData _zombieSpawnedEventData;
        private GameData _gameData;
        private List<ZombieDataProvider> _zombies;

        public override void Construct(GameData gameData)
        {
            _gameData = gameData;
        }

        public override void Initialize()
        {
            _mainEntitiesStore = _gameData.GetDataProvider<MainEntitiesStore>();
            _zombiesPoolDataProvider = _gameData.GetDataProvider<ZombiesPoolDataProvider>();
            _entityMoveEventData = _mainEntitiesStore.EntityMoveEventData;
            _zombieSpawnedEventData = _zombiesPoolDataProvider.ZombiesPoolStaticData.ZombieSpawnedEventData;
            _zombies = new List<ZombieDataProvider>();
        }

        public void Subscribe()
        {
            _zombieSpawnedEventData.ZombieSpawned += AddNewZombies;
        }

        public void Unsubscribe()
        {
            _zombieSpawnedEventData.ZombieDespawned -= AddNewZombies;
        }

        public void FixedOperate()
        {
            MoveZombies();
        }

        private void AddNewZombies(GameObjectDataProvider gameObjectDataProvider)
        {
            gameObjectDataProvider.TryGetComponent<ZombieDataProvider>(out var zombie);
            _zombies.Add(zombie);
        }

        private void MoveZombies()
        {
            foreach (var zombie in _zombies)
            {
                _entityMoveEventData.TriggerMoveRequested(zombie.transform, Vector3.forward, zombie.CurrentMoveSpeed);
            }
        }
    }
}