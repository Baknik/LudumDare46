using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class InteractedWith_Keg_System : ComponentSystem
{
    private EntityQuery walletQuery;

    protected override void OnStartRunning()
    {
        this.walletQuery = Entities.WithAll<Wallet>().ToEntityQuery();
    }

    protected override void OnUpdate()
    {
        if (this.walletQuery.CalculateEntityCount() > 0)
        {
            Wallet wallet = this.walletQuery.ToComponentArray<Wallet>()[0];

            Entities.WithAll<InteractedWith>().ForEach((Entity entity, Keg keg) =>
            {
                if (wallet.Money >= keg.RefillCost.Value)
                {
                    wallet.Money -= keg.RefillCost.Value;
                    keg.Beer = keg.StartingBeer.Value;
                }
            });
        }
    }
}
