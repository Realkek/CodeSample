using Leopotam.EcsLite;

namespace ECS.Interfaces
{
    public interface IEcsBehavioursInputReceiver
    {
        void CheckBehaviourInputs(IEcsSystems systems);
    }
}