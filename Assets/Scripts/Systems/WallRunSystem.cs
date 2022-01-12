using FPS.Components;
using FPS.ScriptableObjects;
using Leopotam.Ecs;
using UnityEngine;

namespace FPS.Systems
{
    sealed class WallRunSystem : IEcsRunSystem
    {
        readonly StaticData staticData;
        readonly EcsFilter<PlayerData, WallRunData, RigidbodyData> filter;

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var playerData = ref filter.Get1(item);
                ref var wallRunData = ref filter.Get2(item);

                ref Rigidbody rb = ref filter.Get3(item).rb;

                wallRunData.canWallRun = !Physics.Raycast(playerData.playerGO.transform.position, Vector3.down, wallRunData.minimumJumpHeight);

                if (wallRunData.canWallRun)
                {
                    if (wallRunData.wallLeft)
                    {
                        StartWallRun(rb, playerData.playerGO, wallRunData.leftWallHit, wallRunData.wallRunGravity, wallRunData.wallRunJumpForce);
                    }
                    else if(wallRunData.wallRight)
                    {
                        StartWallRun(rb, playerData.playerGO, wallRunData.rightWallHit, wallRunData.wallRunGravity, wallRunData.wallRunJumpForce);  
                    }
                    else
                    {
                        StopWallRun(rb);
                    }
                }
                else
                {
                    StopWallRun(rb);
                }
            }
        }


        void StartWallRun(Rigidbody rb, GameObject playerGO, RaycastHit sideWallHit, float wallRunGravity, float wallRunJumpForce)
        {
            rb.useGravity = false;

            rb.AddForce(Vector3.down * wallRunGravity, ForceMode.Force);

            if (Input.GetKeyDown(staticData.jumpKey))
            {
                Vector3 wallRunJumpDirection = playerGO.transform.up + sideWallHit.normal;
                rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                rb.AddForce(wallRunJumpDirection * wallRunJumpForce * 100f, ForceMode.Force);
            }
        }

        void StopWallRun(Rigidbody rb)
        {
            rb.useGravity = true;
        }
    }
}