using Leopotam.Ecs;
using FPS.Components;
using FPS.UnityComponents;
using UnityEngine;

namespace FPS.Systems
{
    sealed class PlayerLookSystem : IEcsRunSystem
    { 
        readonly EcsFilter<PlayerData, PlayerInputData> filter;

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var playerData = ref filter.Get1(item);
                ref var playerInput = ref filter.Get2(item);

                playerData.cameraTransformHolder.transform.localRotation = Quaternion.Euler(playerInput.xRotation, playerInput.yRotation, 0f);
                playerData.orientation.transform.rotation = Quaternion.Euler(0f, playerInput.yRotation, 0f);
            }
        }
    }
}