using Leopotam.Ecs;
using FPS.Components.Tags;
using FPS.Components;

namespace FPS.Systems
{
    sealed class FixJitteringSystem : IEcsRunSystem
    {
        readonly EcsFilter<GameObjectData, FixJitteringCameraTag> filter;
        readonly EcsFilter<PlayerData> playerFilter;

        public void Run()
        {
            foreach (var item in filter)
            {
                ref var playerData = ref playerFilter.Get1(item);

                ref var gameObject = ref filter.Get1(item).gameObjectRef;

                gameObject.transform.position = playerData.cameraTransformPosition.position;
            }
        }
    }
}

