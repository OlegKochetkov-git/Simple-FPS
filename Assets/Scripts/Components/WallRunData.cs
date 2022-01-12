using System;
using UnityEngine;

namespace FPS.Components
{
    [Serializable]
    public struct WallRunData
    {
        [HideInInspector] public RaycastHit leftWallHit;
        [HideInInspector] public RaycastHit rightWallHit;
        [HideInInspector] public bool wallLeft;
        [HideInInspector] public bool wallRight;
        [HideInInspector] public bool canWallRun;
        public float wallDistance;
        public float minimumJumpHeight;
        public float wallRunGravity;
        public float wallRunJumpForce;
    }
}

