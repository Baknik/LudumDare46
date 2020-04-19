using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class CameraTarget_Cinemachine_System : ComponentSystem
{
    private EntityQuery virtualCameraComponentQuery;

    protected override void OnStartRunning()
    {
        this.virtualCameraComponentQuery = Entities.WithAll<CinemachineVirtualCamera>().ToEntityQuery();
    }

    protected override void OnUpdate()
    {
        if (this.virtualCameraComponentQuery.CalculateEntityCount() > 0)
        {
            CinemachineVirtualCamera virtualCamera = this.virtualCameraComponentQuery.ToComponentArray<CinemachineVirtualCamera>()[0];

            Entities.ForEach((Entity entity, CameraTarget cameraTarget, Transform transform) =>
            {
                virtualCamera.Follow = transform;
            });
        }
    }
}
