using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Movement_Character_System : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, Movement movement, Character character) =>
        {
            // Facing
            float headX;
            float buckleX;
            if (movement.Facing.x > 0f) // right
            {
                character.transform.localScale = new Vector3(1f, character.transform.localScale.y, character.transform.localScale.z);
            }
            else if (movement.Facing.x < 0f) // left
            {
                character.transform.localScale = new Vector3(-1f, character.transform.localScale.y, character.transform.localScale.z);
            }
        });
    }
}
