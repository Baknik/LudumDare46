using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

[UpdateInGroup(typeof(EventCreation_SystemGroup))]
public class InteractActionEventTrigger_System : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, Input input) =>
        {
            if (input.InteractInput)
            {
                input.InteractInput = false;

                EntityManager.AddComponent<InteractAction>(entity);
            }
        });
    }
}
