using System;
using UnityEngine;

namespace FPS.Components
{
    [Serializable]
    public struct PhysicsMaterialData
    {
        public PhysicMaterial friction;
        public PhysicMaterial noFriction;
    }
}