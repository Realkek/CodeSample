using Scenes.BattleVsZombies.Interfaces.BaseInitialization;
using UnityEngine;

namespace Scenes.BattleVsZombies.Generally
{
    public abstract class BaseInitializable : ScriptableObject, IBaseInitializable
    {
        public abstract void Construct(GameData gameData);
        public abstract void Initialize();
    }
}