using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private MovementParameters movementParams; // Reference to the movement parameters MonoBehaviour
    public PlayerControls controls; // Reference to the PlayerControls script
    private Rigidbody2D rb;
    private bool clampEnabled = true; // Flag to track if clamping is enabled

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
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
        float acceleration = moveInput * movementParams.acceleration;

        // Apply turning acceleration if moving and turning in the opposite direction
        if (Mathf.Sign(rb.velocity.x) != Mathf.Sign(moveInput) && Mathf.Abs(rb.velocity.x) > 0)
        {
            acceleration = moveInput * movementParams.turningAcceleration;
        }

        // Apply velocity directly
        rb.velocity += new Vector2(acceleration * Time.deltaTime, 0f);

        // Apply deceleration if not moving
        if (Mathf.Approximately(moveInput, 0f))
        {
            float deceleration = Mathf.Sign(rb.velocity.x) * movementParams.deceleration;
            rb.velocity -= new Vector2(deceleration * Time.deltaTime, 0f);
        }

        // Clamp velocity to max speed if enabled
        if (clampEnabled)
        {
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -movementParams.maxSpeed, movementParams.maxSpeed), rb.velocity.y);
        }
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

    private IEnumerator DisableClampTemporarily(float duration)
    {
        clampEnabled = false;
        yield return new WaitForSeconds(duration);
        clampEnabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsGrounded())
        {
            StartCoroutine(DisableClampTemporarily(0.1f)); // Disable clamp for 0.1 seconds when colliding with the ground
            Debug.Log("ground");
        }
    }
}
