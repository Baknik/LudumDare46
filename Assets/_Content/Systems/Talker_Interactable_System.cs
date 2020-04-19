using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Talker_Interactable_System : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, Talker talker, Interactable interactable) =>
        {
            if (!interactable.Targeted)
            {
                talker.DialogDisplay.gameObject.SetActive(false);
            }
        });
    }
}
