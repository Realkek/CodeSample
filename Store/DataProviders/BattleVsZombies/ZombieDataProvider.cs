using Scenes.BattleVsZombies.Generally;
using UnityEngine;

namespace Scenes.BattleVsZombies.Store.DataProviders.BattleVsZombies
{
    public class ZombieDataProvider : GameObjectDataProvider
    {
        [SerializeField] private float _currentMoveSpeed;
        [SerializeField] private Animator _animator;

        public Animator Animator => _animator;

        public float CurrentMoveSpeed
        {
            get => _currentMoveSpeed;
            set => _currentMoveSpeed = value;
        }
    }
}