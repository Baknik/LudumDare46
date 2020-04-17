using UnityEngine;

[System.Serializable]
public sealed class SpriteReference : BaseReference<Sprite, SpriteVariable>
{
    public SpriteReference() : base() { }
    public SpriteReference(Sprite value) : base(value) { }
}