using UnityEngine;

public abstract class PlayerChildComponent : MonoBehaviour
{
    [SerializeField, ReadOnly] protected PlayerController controller;

    protected virtual void Reset()
    {
        controller = GetComponent<PlayerController>();
    }

    protected void OnEnable()
    {
        ConnectEvent(true);
    }

    protected void OnDisable()
    {
        ConnectEvent(false);
    }

    protected abstract void ConnectEvent(bool isConnect);
}
