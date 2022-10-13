using System;
using UnityEngine;

namespace Scenes.BattleVsZombies.Store.StaticData.Events
{
    [CreateAssetMenu(menuName = "Game/StaticData/EventsData/PlayerInputKeysEventData",
        fileName = "PlayerInputKeysEventData")]
    public class PlayerInputKeysEventData : ScriptableObject
    {
        public event Action WKeyDown;
        public event Action AKeyDown;
        public event Action SKeyDown;
        public event Action DKeyDown;
        public event Action SpaceKeyDown;
        public event Action WKeyReleased;
        public event Action AKeyReleased;
        public event Action SKeyReleased;
        public event Action DKeyReleased;
        public event Action SpaceKeyReleased;
        public event Action EKeyDown;
        public void TriggerEKeyDown() => EKeyDown?.Invoke();
        public void TriggerSpaceKeyClick() => SpaceKeyDown?.Invoke();
        public void TriggerWKeyClick() => WKeyDown?.Invoke();
        public void TriggerAKeyClick() => AKeyDown?.Invoke();
        public void TriggerSKeyClick() => SKeyDown?.Invoke();
        public void TriggerDKeyClick() => DKeyDown?.Invoke();
        public void TriggerSpaceKeyReleased() => SpaceKeyReleased?.Invoke();
        public void TriggerWKeyReleased() => WKeyReleased?.Invoke();
        public void TriggerAKeyReleased() => AKeyReleased?.Invoke();
        public void TriggerSKeyReleased() => SKeyReleased?.Invoke();
        public void TriggerDKeyReleased() => DKeyReleased?.Invoke();
    }
}