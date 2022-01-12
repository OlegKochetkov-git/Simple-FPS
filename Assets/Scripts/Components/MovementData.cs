using System;
using UnityEngine;

namespace FPS.Components
{
    [Serializable]
    public struct MovementData
    {
        [HideInInspector] public float moveSpeed;
        public float movementMultiplier;
        public float airMultiplier;
    }
}