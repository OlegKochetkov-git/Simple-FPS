using FPS.Components;
using FPS.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace FPS.Systems
{
    sealed class CheckSideWallSystem : IEcsRunSystem
    {
        readonly EcsFilter<PlayerData, WallRunData> filter;

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var playerData = ref filter.Get1(item);
                ref var wallRunData = ref filter.Get2(item);

                ref bool wallLeft = ref filter.Get2(item).wallLeft;
                ref bool wallRight = ref filter.Get2(item).wallRight;

                wallLeft = Physics.Raycast(playerData.playerGO.transform.position, -playerData.orientation.right, out wallRunData.leftWallHit, wallRunData.wallDistance);
                wallRight = Physics.Raycast(playerData.playerGO.transform.position, playerData.orientation.right, out wallRunData.rightWallHit, wallRunData.wallDistance);


            }
        }
    }
}