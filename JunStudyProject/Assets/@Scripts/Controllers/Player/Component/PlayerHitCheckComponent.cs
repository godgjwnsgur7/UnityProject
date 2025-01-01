using UnityEngine;

public interface IDamageable
{

    void OnDamaged();
}

public class PlayerHitCheckComponent : PlayerChildComponent, IDamageable
{
    protected override void ConnectEvent(bool isConnect)
    {

    }

    public void OnDamaged()
    {

    }
}
