using Leopotam.Ecs;
using FPS.Components;
using UnityEngine;

namespace FPS.Systems
{
    sealed class PlayerDragControlSystem : IEcsRunSystem
    {
        readonly EcsFilter<PlayerData, RigidbodyData, DragData> filter;

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var playerData = ref filter.Get1(item);
                ref var dragData = ref filter.Get3(item);

                ref Rigidbody rb = ref filter.Get2(item).rb;

                if (playerData.isGrounded)
                {
                    rb.drag = dragData.groundDrag;
                }
                else
                {
                    rb.drag = dragData.airDrag;
                }
            }       
        }
    }
}

