using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public PlayerAnimator animator;
    [Header("Controls")]
    public string forward;
    public string backward;
    public string right;
    public string left;
    public string jump;
    public string slowWalk;
    public string crouch;
    public string dash;

    [Header("Directional Keys")]
    public Vector2 moveInputDir;
    private int moveInputDirX = 0;
    private int moveInputDirZ = 0;

    public bool isPlayer;

    public bool pressJumpFromTrigger;
    public bool pressSlideFromTrigger;

    public Vector2 InputDir()
    {
        moveInputDirX = 0;
        moveInputDirZ = 0;
        if (isPlayer) {
            moveInputDirZ += 1;
        } else {
            if (Keyboard.current.wKey.isPressed) { moveInputDirZ += 1; }
        }
        
        if (Keyboard.current.rKey.isPressed) { moveInputDirZ -= 1; }
        moveInputDirZ = Mathf.Clamp(moveInputDirZ, -1, 1);

        if (Keyboard.current.dKey.isPressed) { moveInputDirX += 1; }
        if (Keyboard.current.aKey.isPressed) { moveInputDirX -= 1; }
        moveInputDirX = Mathf.Clamp(moveInputDirX, -1, 1);

        moveInputDir = new Vector2(moveInputDirX, moveInputDirZ);
        moveInputDir.Normalize();
        return moveInputDir;
    }
    public bool PressedJump()
    {
        if (Keyboard.current.spaceKey.isPressed) { return true; }
        return false;
    }
    public bool PressedWalk()
    {
        if (Keyboard.current.leftShiftKey.isPressed) { return true; }
        return false;
    }
    public bool PressedCrouch()
    {
        if (Keyboard.current.leftCtrlKey.isPressed) { return true; }
        return false;
    }
    public bool HoldDash()
    {
        if (Keyboard.current.tabKey.isPressed) { return true; }
        return false;
    }
    public bool ReleasedDash()
    {
        if (Keyboard.current.tabKey.isPressed) { return true; }
        return false;
    }
}
