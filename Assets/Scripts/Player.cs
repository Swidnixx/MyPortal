using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;

    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(inputX, 0, inputY) * Time.deltaTime * speed;
        transform.Translate(move);
    }
}
