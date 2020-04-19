using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SelectableObject : MonoBehaviour, IComponentData
{
    [HideInInspector]
    public bool Selected;

    private void Start()
    {
        this.Selected = false;
    }

    public void Select()
    {
        this.Selected = true;
    }
}