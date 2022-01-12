using UnityEngine;
using Leopotam.Ecs;
using FPS.Components;

namespace FPS.Systems
{
    sealed class CalculationSlopeDirectionSystem : IEcsRunSystem
    {
        readonly EcsFilter<PlayerData, OnSlopeData> filter;
        public void Run()
        {
            foreach (var item in filter)
            {
                ref var playerData = ref filter.Get1(item);
                ref var onSlopeData = ref filter.Get2(item);

                onSlopeData.slopeMoveDirection = Vector3.ProjectOnPlane(playerData.moveDirection, onSlopeData.slopeHit.normal);
            }
        }
    }
}