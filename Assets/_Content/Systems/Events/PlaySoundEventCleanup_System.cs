using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

[UpdateInGroup(typeof(EventCleanup_SystemGroup))]
public class PlaySoundEventCleanup_System : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.WithAll<PlaySound>().ForEach((Entity entity) =>
        {
            EntityManager.RemoveComponent<PlaySound>(entity);
        });
    }
}
