using UnityEngine;

public abstract class BaseObjectFactory<T> where T : BaseObject
{
    public BaseObject SpawnObject(T type, Transform parent = null, Vector3 worldPos = default)
    {
        BaseObject spawnObj = this.Create(type);
        spawnObj.transform.parent = parent;
        spawnObj.transform.position = worldPos;
        return spawnObj;
    }

    protected abstract BaseObject Create(T type);
}

public class MonsterFactory : BaseObjectFactory<Monster>
{
    protected override BaseObject Create(Monster type)
    {
        Monster monster = null;

        // monster 제작 로직

        return monster as BaseObject;
    }
}
public class Monster : BaseObject
{

}