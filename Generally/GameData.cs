using System;
using System.Collections.Generic;
using System.Linq;
using Scenes.BattleVsZombies.Interfaces;
using Scenes.BattleVsZombies.Interfaces.BaseInitialization;
using UnityEngine;

namespace Scenes.BattleVsZombies.Generally
{
    public class GameData : MonoBehaviour, IAwaker, IDisabler
    {
        [SerializeField] private GameObject _sceneGamePlayContainer;

        private Dictionary<Type, IGameObjectDataProvider> _dataProviders;
        
        public void OnAwake()
        {
            _dataProviders = _sceneGamePlayContainer.GetComponentsInChildren<IGameObjectDataProvider>()
                .ToDictionary(dataProvider => dataProvider.GetType(), dataProvider => dataProvider);
        }

        public T GetDataProvider<T>() where T : GameObjectDataProvider
        {
            _dataProviders.TryGetValue(typeof(T), out var dataProvider);
            return dataProvider as T;
        }

        public void Disable()
        {
            _dataProviders.Clear();
        }
    }
}