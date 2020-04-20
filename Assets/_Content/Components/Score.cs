using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour, IComponentData
{
    [HideInInspector]
    public int Value;

    private void Start()
    {
        this.Value = 0;
    }
}
