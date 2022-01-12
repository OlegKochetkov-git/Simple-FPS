using UnityEngine;
using Leopotam.Ecs;
using FPS.Components;
using FPS.UnityComponents;

namespace FPS.Systems
{
    sealed class PlayerCheckGroundSystem : IEcsRunSystem
    {
        readonly EcsFilter<PlayerData, GroundData> filter;

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var playerData = ref filter.Get1(item);
                ref var groundData = ref filter.Get2(item);

                playerData.isGrounded = Physics.CheckSphere(groundData.groundCheckSphere.position, groundData.groundDistance, groundData.groundMask);


                #region Debug
                playerData.playerGO.GetComponent<DrawGizmoDebug>().groundCheck = groundData.groundCheckSphere;
                playerData.playerGO.GetComponent<DrawGizmoDebug>().radius = groundData.groundDistance;
                #endregion
            }
        }
    }
}

