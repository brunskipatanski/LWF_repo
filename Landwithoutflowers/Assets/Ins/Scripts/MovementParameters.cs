using UnityEngine;

[CreateAssetMenu(fileName = "MovementParameters", menuName = "ScriptableObjects/MovementParameters", order = 1)]
public class MovementParameters : ScriptableObject
{
    [Header("Movement Settings")]
    public float moveSpeed = 1f;        // Movement speed of the player
    public float jumpForce = 1000f;       // Force applied when jumping
}
