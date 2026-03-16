using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform receiver;
    Transform player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player = other.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
        }
    }

    private void FixedUpdate()
    {
        if(player != null)
        {
            Vector3 portalForward = transform.up;
            Vector3 portalToPlayer = player.transform.position - transform.position;
            float dot = Vector3.Dot(portalForward, portalToPlayer);

            if(dot < 0)
            {
                Vector3 playerForward = transform.parent.InverseTransformDirection(player.forward);
                playerForward = receiver.parent.TransformDirection(playerForward);
                player.forward = playerForward;

                portalToPlayer = transform.parent.InverseTransformDirection(portalToPlayer);
                portalToPlayer = receiver.parent.TransformDirection(portalToPlayer);

                player.position = receiver.position + portalToPlayer;
                player = null;
            }
        }
    }
}
