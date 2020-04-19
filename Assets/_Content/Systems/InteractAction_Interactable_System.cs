using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class InteractAction_Interactable_System : ComponentSystem
{
    private EntityQuery interactActionQuery;
    private EntityQuery playerQuery;

    protected override void OnStartRunning()
    {
        this.interactActionQuery = Entities.WithAll<InteractAction>().ToEntityQuery();
        this.playerQuery = Entities.WithAll<Character, PlayerControlled, Movement>().ToEntityQuery();
    }

    protected override void OnUpdate()
    {
        // Targeting
        if (this.playerQuery.CalculateEntityCount() > 0)
        {
            Movement playerMovement = this.playerQuery.ToComponentArray<Movement>()[0];

            Interactable currentInteractable = null;
            Entities.ForEach((Entity entity, Interactable interactable, WorldObject obj) =>
            {
                Vector3 closestColliderPoint = obj.BaseCollider.ClosestPoint(playerMovement.transform.position);
                Vector3 fromPlayerToColliderDirection = (closestColliderPoint - playerMovement.transform.position).normalized;
                if (Vector3.Dot(fromPlayerToColliderDirection, playerMovement.Facing) > 0.75f &&
                    Vector3.Distance(playerMovement.transform.position, closestColliderPoint) <= interactable.MaxInteractionDistance)
                {
                    if (currentInteractable == null)
                    {
                        interactable.Targeted = true;
                        currentInteractable = interactable;
                    }
                    else if (interactable.InteractionPriority > currentInteractable.InteractionPriority)
                    {
                        currentInteractable.Targeted = false;
                        interactable.Targeted = true;
                        currentInteractable = interactable;
                    }
                }
                else
                {
                    interactable.Targeted = false;
                }
            });
        }

        // Interact action
        if (this.interactActionQuery.CalculateEntityCount() > 0)
        {
            Entities.ForEach((Entity entity, Interactable interactable) =>
            {
                if (interactable.Targeted)
                {
                    interactable.InteractedWith = true;
                    interactable.Interacting = true;
                }
            });
        }
    }
}
