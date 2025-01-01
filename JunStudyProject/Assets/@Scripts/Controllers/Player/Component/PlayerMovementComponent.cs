using UnityEngine;

public class PlayerMovementComponent : PlayerChildComponent
{
    [SerializeField, ReadOnly] Rigidbody2D rigid;

    protected override void Reset()
    {
        base.Reset();

        rigid = GetComponent<Rigidbody2D>();
    }

    protected override void ConnectEvent(bool isConnect)
    {
        controller.OnMove -= OnMove;

        if(isConnect)
        {
            controller.OnMove += OnMove;
        }
    }

    private void OnMove(Vector2 moveVec)
    {
        // 이동이동
    }
}
