using UnityEngine;

public class MovementParameters : MonoBehaviour
{
    [Header("Movement Settings")]
    public float maxSpeed = 5f;            // Maximum movement speed of the player
    public float jumpForce = 10f;          // Force applied when jumping
    public float acceleration = 10f;       // Acceleration of the player
    public float deceleration = 10f;       // Deceleration of the player
    public float turningAcceleration = 5f; // Acceleration when turning while moving

    [Header("Double Jump Settings")]
    public bool canDoubleJump = true;      // Determines if the player can double jump
    public float doubleJumpForce = 7f;     // Force applied during double jump

    // Add more parameters as needed
}
