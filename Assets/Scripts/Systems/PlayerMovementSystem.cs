using UnityEngine;
using Leopotam.Ecs;
using FPS.Components;

namespace FPS.Systems
{
    sealed class PlayerMovementSystem : IEcsInitSystem, IEcsRunSystem
    {
        readonly EcsFilter<PlayerData, RigidbodyData, OnSlopeData, MovementData> filter;

        public void Init()
        {
            foreach (var item in filter)
            {
                ref Rigidbody rb = ref filter.Get2(item).rb;

                rb.freezeRotation = true;
            }
        }

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var playerData = ref filter.Get1(item);
                ref var onSlopeData = ref filter.Get3(item);
                ref var movementData = ref filter.Get4(item);

                ref Rigidbody rb = ref filter.Get2(item).rb;


                if (playerData.isGrounded && !onSlopeData.onSlope)
                {
                    rb.AddForce(playerData.moveDirection.normalized * movementData.moveSpeed
                        * movementData.movementMultiplier, ForceMode.Acceleration);
                }
                else if (playerData.isGrounded && onSlopeData.onSlope)
                {
                    rb.AddForce(onSlopeData.slopeMoveDirection.normalized * movementData.moveSpeed
                        * movementData.movementMultiplier, ForceMode.Acceleration);
                }
                else
                {
                    rb.AddForce(playerData.moveDirection.normalized * movementData.moveSpeed
                        * movementData.movementMultiplier * movementData.airMultiplier, ForceMode.Acceleration);
                }   
            }
        }
    }
}