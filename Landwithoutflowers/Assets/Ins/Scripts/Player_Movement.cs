using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public MovementParameters movementParams; // Reference to the movement parameters ScriptableObject

    // Start is called before the first frame update
    void Start()
    {
        // Get reference to the MovementParameters ScriptableObject
        // This assumes you have assigned the MovementParameters asset in the Inspector
        if (movementParams == null)
        {
            Debug.LogError("MovementParameters not assigned in PlayerMovement script.");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Handle player movement
        HandleMovement();

        // Handle player jumping
        HandleJumping();
    }

    // Method to handle player movement
    private void HandleMovement()
    {
        // Move left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * movementParams.moveSpeed * Time.deltaTime);
        }
        // Move right
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * movementParams.moveSpeed * Time.deltaTime);
        }
    }

    // Method to handle player jumping
    private void HandleJumping()
    {
        // Check if the jump key is pressed and the player is grounded
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            // Apply jump force
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * movementParams.jumpForce, ForceMode2D.Impulse);
        }
    }

    // Method to check if the player is grounded
    private bool IsGrounded()
    {
        // Perform a raycast downwards to check if there's ground beneath the player
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        return hit.collider != null;
    }
}
