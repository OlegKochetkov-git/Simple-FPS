using UnityEngine;
using Leopotam.Ecs;
using FPS.Components;

namespace FPS.Systems
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        readonly EcsFilter<PlayerData, PlayerInputData, MouseData> filter;

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var playerData = ref filter.Get1(item);
                ref var playerInputData = ref filter.Get2(item);
                ref var mouseData = ref filter.Get3(item);


                playerInputData.horizontalMovement = Input.GetAxisRaw("Horizontal");
                playerInputData.verticalMovement = Input.GetAxisRaw("Vertical");
                playerInputData.mouseX = Input.GetAxisRaw("Mouse X");
                playerInputData.mouseY = Input.GetAxisRaw("Mouse Y");

                playerData.moveDirection = playerData.orientation.forward * playerInputData.verticalMovement +
                    playerData.orientation.right * playerInputData.horizontalMovement;

                playerInputData.yRotation += playerInputData.mouseX * mouseData.sensX * mouseData.multiplier;
                playerInputData.xRotation -= playerInputData.mouseY * mouseData.sensY * mouseData.multiplier;

                playerInputData.xRotation = Mathf.Clamp(playerInputData.xRotation, -90f, 90);
            }
        }
    }
}