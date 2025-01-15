using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovementComponent : PlayerChildComponent
{
    [SerializeField, ReadOnly] PlayerGroundCheckComponent groundCheckComponent;
    [SerializeField, ReadOnly] Rigidbody2D rigidBody;

    [SerializeField, ReadOnly] Vector2 MoveVec = Vector2.zero;

    [SerializeField] float moveSpeed = 5.0f;

    protected override void Reset()
    {
        base.Reset();

        groundCheckComponent = GetComponent<PlayerGroundCheckComponent>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    protected override void ConnectEvent(bool isConnect)
    {
        controller.OnMove -= OnMove;
        controller.OnMoveX -= OnMoveX;

        if (isConnect)
        {
            controller.OnMove += OnMove;
            controller.OnMoveX += OnMoveX;
        }
    }

    private void OnMove(Vector2 moveVec)
    {
        rigidBody.linearVelocity = moveVec;
    }

    private void OnMoveX(float moveX)
    {
        rigidBody.linearVelocityX = moveX * moveSpeed;
    }
}
