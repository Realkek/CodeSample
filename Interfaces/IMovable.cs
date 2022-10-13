using System;
using System.Collections.Generic;
using Scenes.BattleVsZombies.Generally;
using UnityEngine;

namespace Scenes.BattleVsZombies.Interfaces
{
    public interface IMovable
    {
        public void Move(Transform transform, Vector3 direction, float speed);
    }
}