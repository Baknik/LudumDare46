using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

[UpdateInGroup(typeof(EventCreation_SystemGroup))]
public class PlaySoundEventTrigger_System : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, SFX sfx) =>
        {
            if (sfx.PlayGoodSound)
            {
                sfx.PlayGoodSound = false;
                EntityManager.AddComponentData(entity, new PlaySound()
                {
                    Sound = sfx.GoodSound
                });
            }
            else if (sfx.PlayBadSound)
            {
                sfx.PlayBadSound = false;
                EntityManager.AddComponentData(entity, new PlaySound()
                {
                    Sound = sfx.BadSound
                });
            }
        });
    }
}
