using UnityEngine;
using Leopotam.Ecs;
using FPS.Components;
using FPS.ScriptableObjects;

namespace FPS.Systems
{
    sealed class PlayerJumpSystem : IEcsRunSystem
    {
        readonly StaticData staticData;

        readonly EcsFilter<PlayerData, RigidbodyData, JumpData> filter;

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var playerData = ref filter.Get1(item);
                ref var jumpData = ref filter.Get3(item);

                ref Rigidbody rb = ref filter.Get2(item).rb;

                if (Input.GetKeyDown(staticData.jumpKey) && playerData.isGrounded)
                {
                    rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                    rb.AddForce(playerData.playerGO.transform.up * jumpData.jumpForce, ForceMode.Impulse);
                }
            }
        }
    }
}