using System.Collections.Generic;
using Scenes.BattleVsZombies.Generally;
using UnityEngine;

namespace Scenes.BattleVsZombies.Store.DataProviders
{
    public class ObjectsPoolDataProvider : GameObjectDataProvider
    {
        [SerializeField] private List<Transform> _entityPlacePositions;
        public List<Transform> EntityPlacePositions => _entityPlacePositions;
    }
}