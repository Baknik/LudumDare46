using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Score_System : ComponentSystem
{
    private EntityQuery partyHappinessQuery;

    protected override void OnStartRunning()
    {
        this.partyHappinessQuery = Entities.WithAll<PartyHappiness>().ToEntityQuery();
    }

    protected override void OnUpdate()
    {
        if (this.partyHappinessQuery.CalculateEntityCount() > 0)
        {
            PartyHappiness partyHappiness = this.partyHappinessQuery.ToComponentArray<PartyHappiness>()[0];

            if (partyHappiness.Happiness > 0f)
            {
                Entities.ForEach((Entity entity, Score score) =>
                {
                    score.Value += Mathf.CeilToInt(Time.DeltaTime * 30f);
                });
            }
        }
            
    }
}
