using System;

namespace Game.Scripts.Providers.Systems
{
    public interface ISystemProvider : IDisposable
    {
        void Operate();
    }
}