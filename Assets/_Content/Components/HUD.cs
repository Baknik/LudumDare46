using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour, IComponentData
{
    public Text MoneyText;
    public Text PartyHappinessText;
    public Text ScoreText;
}
