using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class PartyHappiness : MonoBehaviour, IComponentData
{
    [HideInInspector]
    public float Happiness;

    public FloatReference MaxPartyHappiness;

    private void Start()
    {
        this.Happiness = this.MaxPartyHappiness.Value;
    }
}
