using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SFX : MonoBehaviour, IComponentData
{
    [HideInInspector]
    public bool PlayGoodSound;
    [HideInInspector]
    public bool PlayBadSound;
    public AudioClip GoodSound;
    public AudioClip BadSound;
    public AudioSource SFXSource;
}
