using System;
using UnityEngine;

namespace Scenes.BattleVsZombies.Store.StaticData.Events
{
    [CreateAssetMenu(menuName = "Game/StaticData/EventsData/EntityMoveData",
        fileName = "EntityMoveData")]
    public class EntityMoveEventData : ScriptableObject
    {
        public event Action<Transform, Vector3, float> EntityMoveRequested;

        public void TriggerMoveRequested(Transform transform, Vector3 direction, float speed)
        {
            EntityMoveRequested?.Invoke(transform, direction, speed);
        }
    }
}