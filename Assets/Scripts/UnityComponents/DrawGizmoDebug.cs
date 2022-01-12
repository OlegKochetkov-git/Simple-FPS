using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using FPS.Components;

public class DrawGizmoDebug : MonoBehaviour
{

    public Transform groundCheck;
    public float radius;



    void OnDrawGizmos()
    {
        if(groundCheck == null && radius == 0)
        {
            Debug.Log("NULL in Debag. It's OK");
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(groundCheck.position, radius);

        }
    }
}
