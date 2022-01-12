using System;
using UnityEngine;

namespace FPS.Components
{
    [Serializable]
    public struct GroundData
    {
        public Transform groundCheckSphere;
        public LayerMask groundMask;
        public float groundDistance;
    }
}