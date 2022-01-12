using System;
using UnityEngine;

namespace FPS.Components
{
    [Serializable]
    public struct PlayerData
    {
        public GameObject playerGO;
        public CapsuleCollider capsuleCollider;
        public Transform cameraTransformHolder;
        public Transform cameraTransformPosition;
        public Transform orientation;
        [HideInInspector] public bool isGrounded;
        [HideInInspector] public Vector3 moveDirection;
    }
}

