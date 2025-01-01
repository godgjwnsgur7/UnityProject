using System;
using UnityEngine;

public class TriggerNotifyObject : MonoBehaviour
{
    public event Action<Collider2D> OnTriggerEnter;
    public event Action<Collider2D> OnTriggerExit;

    Rigidbody2D rigid;
    Collider2D col;

    private void Reset()
    {
        rigid = Util.GetOrAddComponent<Rigidbody2D>(gameObject);
        col = GetComponent<Collider2D>();

        if(col == null)
        {
            Debug.LogError("TriggerNotifyObject에 Collider2D가 없습니다.");
            return;
        }

        rigid.bodyType = RigidbodyType2D.Kinematic;
        col.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == gameObject.layer)
            return;

        OnTriggerEnter?.Invoke(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == gameObject.layer)
            return;

        OnTriggerExit?.Invoke(collision);
    }
}
