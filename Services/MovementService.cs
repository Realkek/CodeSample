using Scenes.BattleVsZombies.Generally;
using Scenes.BattleVsZombies.Interfaces;
using Scenes.BattleVsZombies.Interfaces.BaseInitialization;
using Scenes.BattleVsZombies.Store;
using Scenes.BattleVsZombies.Store.StaticData.Events;
using UnityEngine;

namespace Scenes.BattleVsZombies.Services
{
    [CreateAssetMenu(menuName = "Game/Services/MovementService",
        fileName = "MovementService")]
    public class MovementService : BaseInitializable, ISubscriber, IMovable
    {
        private MainEntitiesStore _mainEntitiesStore;
        private EntityMoveEventData _entityMoveEventData;
        private GameData _gameData;

        public override void Construct(GameData gameData)
        {
            _gameData = gameData;
        }

        public override void Initialize()
        {
            _mainEntitiesStore = _gameData.GetDataProvider<MainEntitiesStore>();
            _entityMoveEventData = _mainEntitiesStore.EntityMoveEventData;
        }
        
        public void Subscribe()
        {
            _entityMoveEventData.EntityMoveRequested += Move;
        }

        public void Unsubscribe()
        {
            _entityMoveEventData.EntityMoveRequested -= Move;
        }

        public void Move(Transform transform, Vector3 direction, float speed)
        {
            transform.Translate(direction * speed);
        }
    }
}