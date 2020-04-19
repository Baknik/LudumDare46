using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class GlobalPostProcessing : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
