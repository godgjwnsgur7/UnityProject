using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    bool IsInteractTarget { get; }
    void OnInteract();
}

public class PlayerInteractionComponent : PlayerChildComponent
{
    [SerializeField, ReadOnly] TriggerNotifyObject interactionTriggerNotify;

    [SerializeField, ReadOnly] List<IInteractable> interactableList = new List<IInteractable>();
    [SerializeField, ReadOnly] IInteractable interactionTarget = null;

    protected override void Reset()
    {
        base.Reset();

        interactionTriggerNotify = Util.FindChild<TriggerNotifyObject>(gameObject, "PlayerInteractionRange", true);

        if(interactionTriggerNotify == null)
        {
            GameObject go = new GameObject("PlayerInteractionRange");
            go.transform.parent = transform;
            interactionTriggerNotify = go.AddComponent<TriggerNotifyObject>();
            return;
        }
    }

    protected override void ConnectEvent(bool isConnect)
    {
        interactionTriggerNotify.OnTriggerEnter -= OnTriggerEnterCallback;
        interactionTriggerNotify.OnTriggerExit -= OnTriggerExitCallback;

        if (isConnect)
        {
            interactionTriggerNotify.OnTriggerEnter += OnTriggerEnterCallback;
            interactionTriggerNotify.OnTriggerExit += OnTriggerExitCallback;
        }
    }

    private void CheckInteractionTarget()
    {
        // 현재 상호작용 타겟이 변경됐는지 체크해서 상태를 갱신
    }

    private void OnTriggerEnterCallback(Collider2D collision)
    {
        if(collision.TryGetComponent(out IInteractable target))
        {
            interactableList.Add(target);
        }

        CheckInteractionTarget();
    }

    private void OnTriggerExitCallback(Collider2D collision)
    {
        if (interactableList.Count == 0)
            return;

        if (collision.TryGetComponent(out IInteractable target))
        {
            interactableList.Remove(target);
        }

        CheckInteractionTarget();
    }
}
