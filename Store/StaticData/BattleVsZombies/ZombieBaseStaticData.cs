using Scenes.BattleVsZombies.Store.DataProviders.BattleVsZombies;
using UnityEngine;

namespace Scenes.BattleVsZombies.Store.StaticData.BattleVsZombies
{
    [CreateAssetMenu(menuName = "Game/StaticData/BattleVsZombies/ZombieBaseStaticData",
        fileName = "ZombieBaseStaticData")]
    public class ZombieBaseStaticData : ScriptableObject
    {
        [SerializeField] private ZombieDataProvider _prefab;
        [SerializeField] private float _movementSpeed;

        public ZombieDataProvider Prefab => _prefab;
        public float MovementSpeed => _movementSpeed;
    }
}