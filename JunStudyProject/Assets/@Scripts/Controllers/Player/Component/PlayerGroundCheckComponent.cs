using UnityEngine;

public class PlayerGroundCheckComponent : PlayerChildComponent
{
    [SerializeField, ReadOnly] TriggerNotifyObject groundCheckNotify;
    [SerializeField, ReadOnly] int groundCount = 0;

    public float VelocityY { get; private set; }

    protected override void Reset()
    {
        base.Reset();

        groundCheckNotify = Util.FindChild<TriggerNotifyObject>(gameObject, "PlayerFoot", true);

        if (groundCheckNotify == null)
        {
            GameObject go = new GameObject("PlayerFoot");
            go.transform.parent = transform;
            groundCheckNotify = go.AddComponent<TriggerNotifyObject>();
            return;
        }
    }

    protected override void ConnectEvent(bool isConnect)
    {
        groundCheckNotify.OnTriggerEnter -= OnGroundEnter;
        groundCheckNotify.OnTriggerExit -= OnGroundExit;
        controller.IsGrounded -= IsGrounded;

        if (isConnect)
        {
            groundCheckNotify.OnTriggerEnter += OnGroundEnter;
            groundCheckNotify.OnTriggerExit += OnGroundExit;
            controller.IsGrounded += IsGrounded;
        }
    }

    private bool IsGrounded()
    {
        return groundCount > 0;
    }

    private void OnGroundEnter(Collider2D collision)
    {
        if (collision.gameObject.layer == (int)Define.ELayer.Ground)
            groundCount++;
    }

    private void OnGroundExit(Collider2D collision)
    {
        if (collision.gameObject.layer == (int)Define.ELayer.Ground)
            groundCount--;
    }
}
