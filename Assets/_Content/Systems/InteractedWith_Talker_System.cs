using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class InteractedWith_Talker_System : ComponentSystem
{
    private EntityQuery sfxQuery;

    protected override void OnStartRunning()
    {
        this.sfxQuery = Entities.WithAll<SFX>().ToEntityQuery();
    }

    protected override void OnUpdate()
    {
        Entities.WithAll<InteractedWith>().ForEach((Entity entity, Talker talker, Interactable interactable, Character character) =>
        {
            if (character.Happiness > character.HappinessMehCutoff.Value)
            {
                talker.DialogText.text = $"\"{talker.HappyDialog}\"";
            }
            else if (character.Happiness <= character.HappinessMehCutoff.Value && character.Happiness > character.HappinessSadCutoff.Value)
            {
                talker.DialogText.text = $"\"{talker.MehDialog}\"";
            }
            else
            {
                talker.DialogText.text = $"\"{talker.SadDialog}\"";
            }
            
            talker.DialogDisplay.gameObject.SetActive(true);
            interactable.InteractDisplay.gameObject.SetActive(false);
            interactable.Interacting = true;

            if (this.sfxQuery.CalculateEntityCount() > 0)
            {
                SFX sfx = this.sfxQuery.ToComponentArray<SFX>()[0];
                if (EntityManager.HasComponent<FillHappinessOnTalk>(entity))
                {
                    sfx.PlayGoodSound = true;
                    character.Happiness = character.MaxHappiness.Value;
                }
            }
        });
    }
}
