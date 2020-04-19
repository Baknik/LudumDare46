using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Input_PlayerControlled_Movement_System : ComponentSystem
{
    private EntityQuery inputComponentQuery;

    protected override void OnStartRunning()
    {
        this.inputComponentQuery = Entities.WithAll<Input>().ToEntityQuery();
    }

    protected override void OnUpdate()
    {
        if (this.inputComponentQuery.CalculateEntityCount() > 0)
        {
            Input input = this.inputComponentQuery.ToComponentArray<Input>()[0];
            
            Entities.WithAll<PlayerControlled>().ForEach((Entity entity, Movement movement) =>
            {
                Vector2 fourDirectional = Vector2.zero;
                if (Mathf.Abs(input.MovementInput.x) > Mathf.Abs(input.MovementInput.y))
                {
                    fourDirectional = new Vector2(input.MovementInput.x, 0f);
                }
                else if (Mathf.Abs(input.MovementInput.y) > Mathf.Abs(input.MovementInput.x))
                {
                    fourDirectional = new Vector2(0f, input.MovementInput.y);
                }
                else
                {
                    if (Mathf.Abs(input.MovementInput.x - input.PreviousMovementInput.x) >=
                        Mathf.Abs(input.MovementInput.y - input.PreviousMovementInput.y))
                    {
                        fourDirectional = new Vector2(input.MovementInput.x, 0f);
                    }
                    else if (Mathf.Abs(input.MovementInput.y - input.PreviousMovementInput.y) >
                        Mathf.Abs(input.MovementInput.x - input.PreviousMovementInput.x))
                    {
                        fourDirectional = new Vector2(0f, input.MovementInput.y);
                    }
                }
                movement.Direction = fourDirectional.normalized;

                if (movement.Direction.magnitude > 0f)
                {
                    movement.Facing = movement.Direction;
                }
            });
        }
    }
}
