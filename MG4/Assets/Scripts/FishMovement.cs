using UnityEngine;

public class FishMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3.0f;
    [SerializeField] private float _turnSpeed = 10.0f;

    // This method, CALLED EVERY FRAME, detects input from the player's keyboard
    //      and moves the fish accordingly.
    private void Update()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            movement.z = 1;
        }
        // STEP 1 -------------------------------------------------------------
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            movement.z = -1;
        }
        // STEP 1 -------------------------------------------------------------

        // STEP 2 -------------------------------------------------------------
        if (Input.GetKey(KeyCode.Q))
        {
            movement.y = 1;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            movement.y = -1;
        }
        // STEP 2 -------------------------------------------------------------

        transform.Translate(movement * _moveSpeed * Time.deltaTime);

        float rotation = Input.GetAxis("Horizontal") * _turnSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
    }
}