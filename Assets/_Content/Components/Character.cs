using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Character : MonoBehaviour, IComponentData
{
    public Transform Arm;
    public Transform Hand;
}
