using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class Pizza : MonoBehaviour, IComponentData
{
    [HideInInspector]
    public float Amount;

    public FloatReference MaxPizza;
    public IntReference ReplaceCost;
    public FloatReference DrainRate;
    public Transform[] Slices;

    private void Start()
    {
        this.Amount = this.MaxPizza.Value;
    }
}
