using UnityEngine;

public class Player : BaseObject
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        ObjectType = EObjectType.Player;
        gameObject.layer = (int)Define.ELayer.Player;

        return true;
    }

    public override void SetInfo(int objectId)
    {
        base.SetInfo(objectId);


    }


}
