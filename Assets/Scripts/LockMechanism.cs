using UnityEngine;

public class LockMechanism : MonoBehaviour
{
    public KeyType correctKey;
    public DoorMechanism[] doorToOpen;

    bool alreadyOpen;
    bool playerInRange;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Hidden");
    }

    private void Update()
    {
        if (alreadyOpen) return;

        if(playerInRange)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(GameManager.Instance.HasKey(correctKey))
                {
                    GameManager.Instance.UseKey(correctKey);
                    OpenDoor();
                }
            }
        }
    }

    public void OpenDoor()
    {
        alreadyOpen = true;
        animator.Play("Open");
        foreach (var door in doorToOpen)
        {
            door.open = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
