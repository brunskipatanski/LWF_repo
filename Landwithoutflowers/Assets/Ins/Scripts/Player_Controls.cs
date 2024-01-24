using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Variables for player's chosen keys
    public KeyCode playerControlLeft = KeyCode.A;
    public KeyCode playerControlRight = KeyCode.D;
    public KeyCode playerControlJump = KeyCode.Space;

    // Update is called once per frame
    void Update()
    {
        // Check if the left movement key is pressed
        if (Input.GetKey(playerControlLeft))
        {
            // Handle moving left (replace this with your actual movement code)
            Debug.Log("Moving Left");
        }

        // Check if the right movement key is pressed
        if (Input.GetKey(playerControlRight))
        {
            // Handle moving right (replace this with your actual movement code)
            Debug.Log("Moving Right");
        }

        // Check if the jump key is pressed
        if (Input.GetKeyDown(playerControlJump))
        {
            // Handle jumping (replace this with your actual jump code)
            Debug.Log("Jumping");
        }
    }
}
