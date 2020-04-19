using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class HUD_Wallet_System : ComponentSystem
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

            Entities.ForEach((Entity entity, HUD hud) =>
            {
                hud.MoneyText.text = String.Format("Wallet: ${0:n0}", wallet.Money);
            });
        }
    }
}
