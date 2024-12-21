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
