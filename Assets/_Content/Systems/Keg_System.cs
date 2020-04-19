using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Keg_System : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, Keg keg) =>
        {
            keg.Beer = Mathf.Clamp(keg.Beer - (keg.DrainRate.Value * Time.DeltaTime), 0f, keg.StartingBeer.Value);
            keg.BeerSlider.minValue = 0f;
            keg.BeerSlider.maxValue = keg.StartingBeer.Value;
            keg.BeerSlider.value = keg.Beer;
        });
    }
}
