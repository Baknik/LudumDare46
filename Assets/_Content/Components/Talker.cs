using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class Talker : MonoBehaviour, IComponentData
{
    public Transform DialogDisplay;
    public Text DialogText;
    public string HappyDialog;
    public string MehDialog;
    public string SadDialog;
}
