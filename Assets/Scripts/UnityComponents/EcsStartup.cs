using FPS.ScriptableObjects;
using FPS.Systems;
using LeoEcsPhysics;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Systems;
using UnityEngine;
using Voody.UniLeo;

namespace FPS.UnityComponents {
    sealed class EcsStartup : MonoBehaviour
    {
        [SerializeField] StaticData staticData;

        [SerializeField] EcsUiEmitter uiEmitter;

        EcsWorld world;
        EcsSystems updateSystems;
        EcsSystems fixedUpdateSystem;

        void Start() {
            
            world = new EcsWorld();
            updateSystems = new EcsSystems(world);
            fixedUpdateSystem = new EcsSystems(world);

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(updateSystems);
#endif
            EcsPhysicsEvents.ecsWorld = world;

            updateSystems.ConvertScene();

            updateSystems
                .Add(new PlayerInputSystem())
                .Add(new CursorLockSystem())
                .Add(new FixJitteringSystem())
                .Add(new PlayerLookSystem())
                .Add(new ControlSpeedSystem())

                .Add(new PlayerDragControlSystem())

                .Add(new PlayerCheckGroundSystem())
                .Add(new PlayerJumpSystem())

                .Add(new CheckOnSlopeSystem())
                .Add(new CalculationSlopeDirectionSystem())

                .Add(new CheckSideWallSystem())
                .Add(new WallRunSystem())
                
                .Inject(staticData)
                .InjectUi(uiEmitter)
                .Init();



            fixedUpdateSystem

                .Add(new PlayerMovementSystem())

                .Inject(staticData)
                .Init();
        }

        void Update()
        {
            updateSystems?.Run();
        }

        void FixedUpdate()
        {
            fixedUpdateSystem?.Run();
        }

        void OnDestroy()
        {
            if (fixedUpdateSystem != null)
            {
                fixedUpdateSystem.Destroy();
                fixedUpdateSystem = null;
            }

            if (updateSystems != null)
            {
                updateSystems.Destroy();
                updateSystems = null;

                world.Destroy();
                world = null;
            }          
        }
    }
}