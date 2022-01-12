using UnityEngine;
using Leopotam.Ecs;
using FPS.Components;

namespace FPS.Systems
{
    sealed class CheckOnSlopeSystem : IEcsRunSystem
    {
        readonly EcsFilter<PlayerData, OnSlopeData, PhysicsMaterialData> filter;

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var playerData = ref filter.Get1(item);
                ref var physicsMaterialData = ref filter.Get3(item);

                ref bool onSlope = ref filter.Get2(item).onSlope;
                ref RaycastHit slopeHit = ref filter.Get2(item).slopeHit;

                bool isHitGround = Physics.Raycast(playerData.playerGO.transform.position, Vector3.down, out slopeHit,
                    playerData.capsuleCollider.height / 2 + 0.5f);

                if (isHitGround)
                {
                    if (slopeHit.normal != Vector3.up)
                    {
                        playerData.capsuleCollider.material = physicsMaterialData.friction;
                        onSlope = true;
                    }
                    else
                    {
                        playerData.capsuleCollider.material = physicsMaterialData.noFriction;
                        onSlope = false;
                    }
                }
                else
                {
                    playerData.capsuleCollider.material = physicsMaterialData.noFriction;
                    onSlope = false;
                }
            }
        }
    }
}