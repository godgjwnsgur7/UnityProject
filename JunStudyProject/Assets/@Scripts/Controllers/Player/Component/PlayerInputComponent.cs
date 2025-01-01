using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputComponent : PlayerChildComponent
{
    [SerializeField, ReadOnly] PlayerInput playerinput;

    protected override void Reset()
    {
        base.Reset();

        playerinput = GetComponent<PlayerInput>();
    }

    protected override void ConnectEvent(bool isConnect)
    {

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveVec = context.ReadValue<Vector2>();
        controller.MovePosition(moveVec);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        controller.TryInteract();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("1");
        controller.TryJump();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        controller.TryAttack();
    }
}
