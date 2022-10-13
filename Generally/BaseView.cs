using Scenes.BattleVsZombies.Interfaces.BaseInitialization;
using UnityEngine;

namespace Scenes.BattleVsZombies.Generally
{
    public abstract class BaseView : MonoBehaviour, IBaseInitializable
    {
        protected GameData GameData { get; private set; }

        public void Construct(GameData gameData)
        {
            GameData = gameData;
        }

        public abstract void Initialize();
    }
}