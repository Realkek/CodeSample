using System;
using UnityEngine;

namespace Scenes.BattleVsZombies.Store.StaticData.BattleVsZombies.Events
{
    [CreateAssetMenu(menuName = "Game/StaticData/BattleVsZombies/EventsData/StartAttackEventData",
        fileName = "StartAttackEventData")]
    public class StartAttackEventData : ScriptableObject
    {
        public event Action AttackStarted; 
        public void TriggerAttackStart() => AttackStarted?.Invoke();
    }
}
