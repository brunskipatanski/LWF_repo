using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private MovementParameters movementParams; // Reference to the movement parameters MonoBehaviour

    public PlayerControls controls; // Reference to the PlayerControls script

    private Rigidbody2D rb;
    private float currentVelocity = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovement();
        HandleJumping();
    }

    private void HandleMovement()
    {
        float moveInput = 0f;

        // Check if left or right movement keys are pressed
        if (controls.IsLeftPressed())
        {
            moveInput = -1f; // Move left
        }
        else if (controls.IsRightPressed())
        {
            moveInput = 1f; // Move right
        }

        // Apply acceleration or deceleration based on move input
        float targetVelocity = moveInput * movementParams.maxSpeed;
        float acceleration = moveInput > 0 ? movementParams.acceleration : movementParams.deceleration;

        // Apply turning acceleration if moving and turning in the opposite direction
        if (Mathf.Sign(rb.velocity.x) != Mathf.Sign(moveInput) && Mathf.Abs(rb.velocity.x) > 0)
        {
            acceleration = movementParams.turningAcceleration;
        }

        currentVelocity = Mathf.MoveTowards(currentVelocity, targetVelocity, acceleration * Time.deltaTime);

        // Update the player's velocity
        rb.velocity = new Vector2(currentVelocity, rb.velocity.y);
    }

    private void HandleJumping()
    {
        // Check if the jump key is pressed and the player is grounded
        if (controls.IsJumpPressed() && IsGrounded())
        {
            // Apply jump force
            rb.AddForce(Vector2.up * movementParams.jumpForce, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        // Perform a raycast downwards to check if there's ground beneath the player
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        return hit.collider != null;
    }
}
