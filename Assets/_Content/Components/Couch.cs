using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class Couch : MonoBehaviour, IComponentData
{
    [HideInInspector]
    public double LastMoneyGrabTime;

    public DoubleReference MoneyCooldown;
    public int MinMoneyFound;
    public int MaxMoneyFound;

    private void Start()
    {
        this.LastMoneyGrabTime = 0d;
    }
}
