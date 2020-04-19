using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class InteractedWith_Talker_System : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.WithAll<InteractedWith>().ForEach((Entity entity, Talker talker, Interactable interactable) =>
        {
            talker.DialogText.text = talker.Dialog;
            talker.DialogDisplay.gameObject.SetActive(true);
            interactable.InteractDisplay.gameObject.SetActive(false);
            interactable.Interacting = true;
        });
    }
}
