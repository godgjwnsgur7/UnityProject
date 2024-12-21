using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public enum EObjectType
{
    Test,
}

public class BaseObject : InitBase
{
    public EObjectType ObjectType { get; protected set; }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        return true;
    }

    public virtual void SetInfo(int objectId) { }
}
