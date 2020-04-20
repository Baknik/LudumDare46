using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class MatchHappinessToKeg_Character_System : ComponentSystem
{
    private EntityQuery kegQuery;

    protected override void OnStartRunning()
    {
        this.kegQuery = Entities.WithAll<Keg>().ToEntityQuery();
    }

    protected override void OnUpdate()
    {
        if (this.kegQuery.CalculateEntityCount() > 0)
        {
            Keg keg = this.kegQuery.ToComponentArray<Keg>()[0];

            Entities.WithAll<MatchHappinessToKeg>().WithNone<PlayerControlled>().ForEach((Entity entity, Character character) =>
            {
                character.Happiness = (keg.Beer / keg.StartingBeer.Value) * character.MaxHappiness.Value;
            });
        }  
    }
}
