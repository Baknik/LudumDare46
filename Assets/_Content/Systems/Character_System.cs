using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Character_System : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.WithNone<PlayerControlled>().ForEach((Entity entity, Character character) =>
        {
            character.Happiness = Mathf.Clamp(character.Happiness - (character.HappinessDrainRate * Time.DeltaTime), 0f, character.MaxHappiness.Value);
            
            if (character.Happiness > character.HappinessMehCutoff.Value)
            {
                character.HeadSpriteRenderer.sprite = character.HappyHead;
            }
            else if (character.Happiness <= character.HappinessMehCutoff.Value && character.Happiness > character.HappinessSadCutoff.Value)
            {
                character.HeadSpriteRenderer.sprite = character.MehHead;
            }
            else if (character.Happiness <= character.HappinessSadCutoff.Value)
            {
                character.HeadSpriteRenderer.sprite = character.SadHead;
            }
        });
    }
}
