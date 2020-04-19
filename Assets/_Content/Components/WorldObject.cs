using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class WorldObject : MonoBehaviour, IComponentData
{
    public BoxCollider BaseCollider;
}
