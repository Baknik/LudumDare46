using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Interactable_System : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, Interactable interactable) =>
        {
            interactable.InteractText.text = interactable.InteractMessage;

            if (!interactable.Targeted)
            {
                interactable.Interacting = false;
            }

            if (interactable.Targeted && !interactable.Interacting)
            {
                interactable.InteractDisplay.gameObject.SetActive(true);
            }
            else
            {
                interactable.InteractDisplay.gameObject.SetActive(false);
            }
        });
    }
}
