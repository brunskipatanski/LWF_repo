using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;        // Movement speed of the player
    public float jumpForce = 10f;       // Force applied when jumping

    private Rigidbody2D rb;             // Reference to the Rigidbody2D component
    private PlayerControls controls;    // Reference to the PlayerControls script

    // Start is called before the first frame update
    void Start()
    {
        // Get reference to the Rigidbody2D component attached to the player GameObject
        rb = GetComponent<Rigidbody2D>();

        // Get reference to the PlayerControls script
        controls = GetComponent<PlayerControls>();
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
        if (controls.IsLeftPressed())
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        // Move right
        else if (controls.IsRightPressed())
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        // Stop movement if no input
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }

    // Method to handle player jumping
    private void HandleJumping()
    {
        // Check if the jump key is pressed and the player is grounded
        if (controls.IsJumpPressed() && IsGrounded())
        {
            // Apply jump force
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
