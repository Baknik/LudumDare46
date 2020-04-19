using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour, IComponentData
{
    [HideInInspector]
    public int Money;

    public IntReference StartMoney;

    private void Start()
    {
        this.Money = this.StartMoney.Value;
    }
}
