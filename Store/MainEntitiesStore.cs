using Scenes.BattleVsZombies.Generally;
using Scenes.BattleVsZombies.Store.StaticData.Events;
using UnityEngine;

namespace Scenes.BattleVsZombies.Store
{
    public class MainEntitiesStore : GameObjectDataProvider
    {
        [SerializeField] private EntityMoveEventData _entityMoveEventData;
        
        public EntityMoveEventData EntityMoveEventData => _entityMoveEventData;
        
    }
}