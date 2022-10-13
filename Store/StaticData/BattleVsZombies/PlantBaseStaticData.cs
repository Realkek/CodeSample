using Scenes.BattleVsZombies.Store.DataProviders.BattleVsZombies;
using UnityEngine;

namespace Scenes.BattleVsZombies.Store.StaticData.BattleVsZombies
{
    [CreateAssetMenu(menuName = "Game/StaticData/BattleVsZombies/PlantBaseStaticData",
        fileName = "PlantBaseStaticData")]
    public class PlantBaseStaticData : ScriptableObject
    {
        [SerializeField] private PlantDataProvider _prefab;

        public PlantDataProvider Prefab => _prefab;
    }
}