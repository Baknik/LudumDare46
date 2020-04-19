using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class Keg : MonoBehaviour, IComponentData
{
    [HideInInspector]
    public float Beer;

    public FloatReference StartingBeer;
    public IntReference RefillCost;
    public FloatReference DrainRate;
    public Slider BeerSlider;

    private void Start()
    {
        this.Beer = this.StartingBeer.Value;
    }
}
