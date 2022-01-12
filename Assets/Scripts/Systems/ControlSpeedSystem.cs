using UnityEngine;
using Leopotam.Ecs;
using FPS.Components;
using FPS.ScriptableObjects;

namespace FPS.Systems
{
    sealed class ControlSpeedSystem : IEcsRunSystem
    {
        readonly StaticData staticData;

        readonly EcsFilter<PlayerData, MovementData, SprintingData> filter;

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var playerData = ref filter.Get1(item);
                ref var movementData = ref filter.Get2(item);
                ref var sprintingData = ref filter.Get3(item);

                if (Input.GetKey(staticData.springKey) && playerData.isGrounded)
                {
                    movementData.moveSpeed = Mathf.Lerp(movementData.moveSpeed, sprintingData.sprintSpeed, sprintingData.acceleration *
                        Time.deltaTime);
                }
                else
                {
                    movementData.moveSpeed = Mathf.Lerp(movementData.moveSpeed, sprintingData.walkSpeed, sprintingData.acceleration *
                        Time.deltaTime);
                }
            }
        }
    }
}