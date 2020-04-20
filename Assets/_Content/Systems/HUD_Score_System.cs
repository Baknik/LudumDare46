using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class HUD_Score_System : ComponentSystem
{
    private EntityQuery scoreQuery;

    protected override void OnStartRunning()
    {
        this.scoreQuery = Entities.WithAll<Score>().ToEntityQuery();
    }

    protected override void OnUpdate()
    {
        if (this.scoreQuery.CalculateEntityCount() > 0)
        {
            Score score = this.scoreQuery.ToComponentArray<Score>()[0];

            Entities.ForEach((Entity entity, HUD hud) =>
            {
                hud.ScoreText.text = $"Score: {score.Value}";
            });
        }
    }
}
