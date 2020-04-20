using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PlaySound_System : ComponentSystem
{
    private EntityQuery sfxQuery;

    protected override void OnStartRunning()
    {
        this.sfxQuery = Entities.WithAll<SFX>().ToEntityQuery();
    }

    protected override void OnUpdate()
    {
        if (this.sfxQuery.CalculateEntityCount() > 0)
        {
            SFX sfx = this.sfxQuery.ToComponentArray<SFX>()[0];

            Entities.ForEach((Entity entity, PlaySound playSound) =>
            {
                sfx.SFXSource.PlayOneShot(playSound.Sound);
            });
        }
    }
}
