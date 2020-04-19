using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Movement : MonoBehaviour, IComponentData
{
    [HideInInspector]
    public Vector2 Direction = Vector2.zero; // normalized
    [HideInInspector]
    public Vector2 Velocity;
    [HideInInspector]
    public Vector2 Facing;

    public FloatReference WalkingSpeed;
    public FloatReference VerticalMovementSpeedRatio;
}
