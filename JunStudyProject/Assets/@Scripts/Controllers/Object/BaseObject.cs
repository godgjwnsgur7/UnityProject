using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public enum EObjectType
{
    Player,
    Monster,
    Npc,

}

[RequireComponent(typeof(SpriteRenderer))]
public class BaseObject : InitBase
{
    private SpriteRenderer spriteRenderer = null;

    public EObjectType ObjectType { get; protected set; }

    bool _lookLeft = false;
    public bool LookLeft
    {
        get { return _lookLeft; }
        set
        {
            _lookLeft = value;
            spriteRenderer.flipX = value;
        }
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        spriteRenderer ??= GetComponent<SpriteRenderer>();

        return true;
    }

    public virtual void SetInfo(int objectId) { }
}
