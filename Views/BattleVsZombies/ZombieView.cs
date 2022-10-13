using Scenes.BattleVsZombies.Generally;
using Scenes.BattleVsZombies.Store;
using Scenes.BattleVsZombies.Store.StaticData.Events;

namespace Scenes.BattleVsZombies.Views.BattleVsZombies
{
    public class ZombieView : BaseView
    {
        private MainEntitiesStore _mainEntitiesStore;
        private EntityMoveEventData _entityMoveEventData;

        public override void Initialize()
        {
            _mainEntitiesStore = GameData.GetDataProvider<MainEntitiesStore>();
            _entityMoveEventData = _mainEntitiesStore.EntityMoveEventData;
        }
    }
}