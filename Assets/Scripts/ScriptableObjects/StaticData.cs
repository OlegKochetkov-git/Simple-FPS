using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.ScriptableObjects
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        public GameObject playerPrefab;
        public KeyCode jumpKey;
        public KeyCode springKey;
    }
}
