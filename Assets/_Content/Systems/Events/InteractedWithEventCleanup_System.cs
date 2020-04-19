using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

[UpdateInGroup(typeof(EventCleanup_SystemGroup))]
public class InteractedWithEventCleanup_System : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.WithAll<InteractedWith>().ForEach((Entity entity) =>
        {
            EntityManager.RemoveComponent<InteractedWith>(entity);
        });
    }
}
