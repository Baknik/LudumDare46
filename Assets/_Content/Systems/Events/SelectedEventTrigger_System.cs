using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

[UpdateInGroup(typeof(EventCreation_SystemGroup))]
public class SelectedEventTrigger_System : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, SelectableObject selectable) =>
        {
            if (selectable.Selected)
            {
                selectable.Selected = false;
                EntityManager.AddComponent<Selected>(entity);
            }
        });
    }
}
