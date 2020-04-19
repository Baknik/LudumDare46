using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

[UpdateInGroup(typeof(EventCleanup_SystemGroup))]
public class InteractActionEventCleanup_System : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.WithAll<InteractAction>().ForEach((Entity entity) =>
        {
            EntityManager.RemoveComponent<InteractAction>(entity);
        });
    }
}
