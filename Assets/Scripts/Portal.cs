using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Portal otherPortal;
    [SerializeField] MeshRenderer renderer;

    Camera camera;
    Transform playerCamera;

    private void Update()
    {
        Matrix4x4 m = transform.localToWorldMatrix *
            otherPortal.transform.worldToLocalMatrix *
            playerCamera.localToWorldMatrix;

        camera.transform.SetPositionAndRotation(m.GetPosition(), m.rotation);
    }

}
