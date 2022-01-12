using System;
using UnityEngine;

namespace FPS.Components
{
    [Serializable]
    public struct OnSlopeData
    {
        [HideInInspector] public Vector3 slopeMoveDirection;
        [HideInInspector] public RaycastHit slopeHit;
        [HideInInspector] public bool onSlope;

    }
}

