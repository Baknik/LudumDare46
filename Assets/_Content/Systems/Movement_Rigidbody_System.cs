using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

//[UpdateBefore(typeof(UnityEngine.PlayerLoop.FixedUpdate))]
public class Movement_Rigidbody_System : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, Movement movement, Rigidbody rigidbody) =>
        {
            Vector3 newVelocity = rigidbody.velocity;
            if (movement.Direction.magnitude > 0)
            {
                newVelocity = new Vector2(
                    movement.Direction.x * movement.WalkingSpeed.Value,
                    movement.Direction.y * movement.WalkingSpeed.Value * movement.VerticalMovementSpeedRatio.Value);
                //rigidbody.AddForce(oneDirectional * movement.Speed.Value * Time.DeltaTime, ForceMode.Force);
            }
            else
            {
                newVelocity = Vector3.zero;
            }
            
            if (newVelocity != rigidbody.velocity)
            {
                rigidbody.velocity = newVelocity;
            }
            movement.Velocity = newVelocity;
        });
    }
}
