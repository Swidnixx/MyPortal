using UnityEngine;

public class DoorMechanism : MonoBehaviour
{
    public Transform door;
    public Transform markerOpen, markerClosed;

    public bool open;
    public float speed = 1.0f;

    void Update()
    {
        if (open)
            door.position = Vector3.MoveTowards(door.position ,markerOpen.position, speed * Time.deltaTime);
        else 
            door.position = Vector3.MoveTowards(door.position, markerClosed.position, speed * Time.deltaTime);
    }
}
