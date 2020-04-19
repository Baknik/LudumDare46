using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

[UpdateInGroup(typeof(EventCleanup_SystemGroup))]
public class SelectedEventCleanup_System : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.WithAll<Selected>().ForEach((Entity entity) =>
        {
            EntityManager.RemoveComponent<Selected>(entity);
        });
    }
}
