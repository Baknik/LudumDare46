using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class InteractedWith_Keg_System : ComponentSystem
{
    private EntityQuery walletQuery;
    private EntityQuery sfxQuery;

    protected override void OnStartRunning()
    {
        this.walletQuery = Entities.WithAll<Wallet>().ToEntityQuery();
        this.sfxQuery = Entities.WithAll<SFX>().ToEntityQuery();
    }

    protected override void OnUpdate()
    {
        if (this.walletQuery.CalculateEntityCount() > 0 && this.sfxQuery.CalculateEntityCount() > 0)
        {
            Wallet wallet = this.walletQuery.ToComponentArray<Wallet>()[0];
            SFX sfx = this.sfxQuery.ToComponentArray<SFX>()[0];

            Entities.WithAll<InteractedWith>().ForEach((Entity entity, Keg keg) =>
            {
                if (wallet.Money >= keg.RefillCost.Value)
                {
                    wallet.Money -= keg.RefillCost.Value;
                    keg.Beer = keg.StartingBeer.Value;
                    sfx.PlayGoodSound = true;
                }
                else
                {
                    sfx.PlayBadSound = true;
                }
            });
        }
    }
}
