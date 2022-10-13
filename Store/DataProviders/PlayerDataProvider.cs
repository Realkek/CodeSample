using Scenes.BattleVsZombies.Generally;
using Scenes.BattleVsZombies.Store.StaticData;
using UnityEngine;

namespace Scenes.BattleVsZombies.Store.DataProviders
{
    public class PlayerDataProvider : GameObjectDataProvider
    {
        [SerializeField] private PlayerStaticData playerStaticData;
        [SerializeField] private Animator _animatorData;
        
        public PlayerStaticData PlayerStaticData => playerStaticData;
        public Animator AnimatorData => _animatorData;
    }
}