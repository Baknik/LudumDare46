using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Pizza_System : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, Pizza pizza) =>
        {
            pizza.Amount = Mathf.Clamp(pizza.Amount - (pizza.DrainRate.Value * Time.DeltaTime), 0f, pizza.MaxPizza.Value);
            int numSlicesLeft = Mathf.CeilToInt((pizza.Amount / pizza.MaxPizza.Value) * 8f);
            for (int i=0; i<pizza.Slices.Length; i++)
            {
                if (numSlicesLeft > 0)
                {
                    pizza.Slices[i].gameObject.SetActive(true);
                    numSlicesLeft--;
                }
                else
                {
                    pizza.Slices[i].gameObject.SetActive(false);
                }
            }
        });
    }
}
