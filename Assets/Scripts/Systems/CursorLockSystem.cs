using Leopotam.Ecs;
using UnityEngine;

namespace FPS.Systems
{
    sealed class CursorLockSystem : IEcsInitSystem
    {
        public void Init()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

