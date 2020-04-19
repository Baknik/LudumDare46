using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour, IComponentData
{
    [HideInInspector]
    public bool Targeted;
    [HideInInspector]
    public bool InteractedWith;
    [HideInInspector]
    public bool Interacting;

    public float MaxInteractionDistance = 1f;
    public int InteractionPriority = 0;
    public Transform InteractDisplay;
    public Text InteractText;
    public string InteractMessage;

    private void Start()
    {
        this.Targeted = false;
        this.InteractedWith = false;
        this.Interacting = false;
    }
}
