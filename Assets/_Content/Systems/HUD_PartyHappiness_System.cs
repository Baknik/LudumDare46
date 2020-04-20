using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class HUD_PartyHappiness_System : ComponentSystem
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

            Entities.ForEach((Entity entity, HUD hud) =>
            {
                hud.PartyHappinessText.text = $"Party Happiness: {(int)(partyHappiness.Happiness)}%";
            });
        }
    }
}
