using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Variables for player's chosen keys
    public KeyCode playerControlLeft = KeyCode.F;
    public KeyCode playerControlRight = KeyCode.H;
    public KeyCode playerControlJump = KeyCode.T;

    // Check if the left movement key is pressed
    public bool IsLeftPressed()
    {
        return Input.GetKey(playerControlLeft);
    }

    // Check if the right movement key is pressed
    public bool IsRightPressed()
    {
        return Input.GetKey(playerControlRight);
    }

    // Check if the jump key is pressed
    public bool IsJumpPressed()
    {
        return Input.GetKeyDown(playerControlJump);
    }
}
