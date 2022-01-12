using System;
using UnityEngine;

namespace FPS.Components
{ 
    [Serializable]
    public struct PlayerInputData
    {
        [HideInInspector] public float horizontalMovement;
        [HideInInspector] public float verticalMovement;
        [HideInInspector] public float mouseX;
        [HideInInspector] public float mouseY;
        [HideInInspector] public float xRotation;
        [HideInInspector] public float yRotation;
    }
}

