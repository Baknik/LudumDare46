using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

[UpdateInGroup(typeof(EventCreation_SystemGroup))]
public class InteractedWithEventTrigger_System : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, Interactable interactable) =>
        {
            if (interactable.InteractedWith)
            {
                interactable.InteractedWith = false;

                EntityManager.AddComponent<InteractedWith>(entity);
            }
        });
    }
}
