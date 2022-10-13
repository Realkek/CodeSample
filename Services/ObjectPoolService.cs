using System.Collections.Generic;
using Scenes.BattleVsZombies.Generally;
using Scenes.BattleVsZombies.Interfaces.BaseInitialization;
using UnityEngine;

namespace Scenes.BattleVsZombies.Services
{
    public class ObjectPoolService : BaseInitializable, IInitializable
    {
        protected List<Vector3> EntityPlacePositions;
        protected GameData GameData;
        protected GameObjectDataProvider CurrentPrefab;
        protected Transform CurrentContainerTransform;
        protected int CurrentPositionNumber;
        protected Vector3 CurrentSpawnPosition; 
        
        [SerializeField] private int _maxCurrentObjectsCount;
        
        private Queue<GameObjectDataProvider> _inactiveObjects;
        private List<GameObjectDataProvider> _activeObjects = new();

        public override void Construct(GameData gameData)
        {
            GameData = gameData;
        }

        public override void Initialize()
        {
            _inactiveObjects = new Queue<GameObjectDataProvider>();
            _activeObjects = new List<GameObjectDataProvider>();
        }

        protected virtual int ChooseNewObjectInstancePositionNumber()
        {
            return Random.Range(0, EntityPlacePositions.Count);
        }

        protected GameObjectDataProvider GetObject()
        {
            if (_inactiveObjects.Count + _activeObjects.Count < _maxCurrentObjectsCount)
                AddObjects();
            if (_inactiveObjects.Count > 0)
            {
                GameObjectDataProvider activeObject = _inactiveObjects?.Dequeue();
                _activeObjects.Add(activeObject);
                ActivateGameObject(activeObject);
                return activeObject;
            }

            return null;
        }

        private void AddObjects()
        {
            var newObject = Instantiate(CurrentPrefab, EntityPlacePositions[CurrentPositionNumber],
                Quaternion.identity,
                CurrentContainerTransform);
            _inactiveObjects.Enqueue(newObject);
        }

        private void ReturnToPool(GameObjectDataProvider objectToReturn)
        {
            DeactivateGameObject(objectToReturn);
            _inactiveObjects.Enqueue(objectToReturn);
            _activeObjects.Remove(objectToReturn);
        }

        private void ActivateGameObject(GameObjectDataProvider gameObjectDataProvider) =>
            gameObjectDataProvider.gameObject.SetActive(true);

        private void DeactivateGameObject(GameObjectDataProvider gameObjectDataProvider) =>
            gameObjectDataProvider.gameObject.SetActive(false);
    }
}