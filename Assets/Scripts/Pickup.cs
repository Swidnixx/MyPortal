using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public float speed = 100;

    private void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Pick();
        }
    }

    protected virtual void Pick()
    {
        Destroy(gameObject);
    }
}
