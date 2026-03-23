using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Portal otherPortal;
    [SerializeField] MeshRenderer renderer;

    public PortalTeleport teleport;

    Camera camera;
    Transform playerCamera;

    private void Start()
    {
        teleport.receiver = otherPortal.teleport.transform;
        camera = GetComponentInChildren<UnityEngine.Camera>();
        playerCamera = UnityEngine.Camera.main.transform;

        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 0);
        camera.targetTexture = rt;
        otherPortal.renderer.material.SetTexture("_MainTex", rt);
    }


    private void Update()
    {
        Matrix4x4 m = transform.localToWorldMatrix *
            otherPortal.transform.worldToLocalMatrix *
            playerCamera.localToWorldMatrix;

        camera.transform.SetPositionAndRotation(m.GetPosition(), m.rotation);
    }

}
