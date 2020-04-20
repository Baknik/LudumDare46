using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class MatchHappinessToPizza_Character_System : ComponentSystem
{
    private EntityQuery pizzaQuery;

    protected override void OnStartRunning()
    {
        this.pizzaQuery = Entities.WithAll<Pizza>().ToEntityQuery();
    }

    protected override void OnUpdate()
    {
        if (this.pizzaQuery.CalculateEntityCount() > 0)
        {
            Pizza pizza = this.pizzaQuery.ToComponentArray<Pizza>()[0];

            Entities.WithAll<MatchHappinessToPizza>().WithNone<PlayerControlled>().ForEach((Entity entity, Character character) =>
            {
                character.Happiness = (pizza.Amount / pizza.MaxPizza.Value) * character.MaxHappiness.Value;
            });
        }  
    }
}
