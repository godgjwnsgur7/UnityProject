using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputComponent : PlayerChildComponent
{
    [SerializeField, ReadOnly] PlayerInput playerInput;

    protected override void Reset()
    {
        base.Reset();

        playerInput = GetComponent<PlayerInput>();
        playerInput.defaultActionMap = Define.EPlayerInputMapType.Player.ToString();
    }

    protected override void ConnectEvent(bool isConnect)
    {

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveVec = context.ReadValue<Vector2>();
        controller.MoveVelocityX(moveVec.x);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        controller.TryInteract();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // 임시로 여기에 세팅
        controller.TryJump(10f);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        controller.TryAttack();
    }
}
