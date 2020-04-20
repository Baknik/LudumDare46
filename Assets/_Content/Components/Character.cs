using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Character : MonoBehaviour, IComponentData
{
    [HideInInspector]
    public float Happiness;

    public Transform Arm;
    public Transform Hand;
    public FloatReference MaxHappiness;
    public SpriteRenderer HeadSpriteRenderer;
    public Sprite PlayerHead;
    public Sprite HappyHead;
    public Sprite MehHead;
    public Sprite SadHead;
    public float HappinessDrainRate;
    public FloatReference HappinessMehCutoff;
    public FloatReference HappinessSadCutoff;

    private void Start()
    {
        this.Happiness = this.MaxHappiness.Value;
    }
}
