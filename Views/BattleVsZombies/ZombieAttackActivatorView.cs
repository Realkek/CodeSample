using Scenes.BattleVsZombies.Generally;
using Scenes.BattleVsZombies.Store.DataProviders;
using Scenes.BattleVsZombies.Store.DataProviders.BattleVsZombies;
using Scenes.BattleVsZombies.Store.StaticData.BattleVsZombies.Events;
using UnityEngine;

namespace Scenes.BattleVsZombies.Views.BattleVsZombies
{
    public class ZombieAttackActivatorView : BaseView
    {
        private StartAttackEventData _startAttackEventData;

        public override void Initialize()
        {
            _startAttackEventData = GameData.GetDataProvider<ZombiesAttackWaveBoxDataProvider>()
                .ZombiesAttackStaticData
                .StartAttackEventData;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerDataProvider>())
                _startAttackEventData.TriggerAttackStart();
            gameObject.SetActive(false);
        }
    }
}