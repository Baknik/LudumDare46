using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Character_PartyHappiness_System : ComponentSystem
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

            float numCharacters = 0f;
            float totalHappiness = 0f;
            Entities.WithNone<PlayerControlled>().ForEach((Entity entity, Character character) =>
            {
                numCharacters += 1f;
                totalHappiness += character.Happiness;
            });

            partyHappiness.Happiness = Mathf.Clamp(totalHappiness / numCharacters, 0f, partyHappiness.MaxPartyHappiness.Value);
        } 
    }
}
