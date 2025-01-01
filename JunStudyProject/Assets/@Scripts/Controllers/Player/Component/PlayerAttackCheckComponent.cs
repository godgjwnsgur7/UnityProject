using UnityEngine;

public interface IAttackable
{
    void OnAttack();
}

public class PlayerAttackCheckComponent : PlayerChildComponent, IAttackable
{
    protected override void ConnectEvent(bool isConnect)
    {

    }

    public void OnAttack()
    {

    }
}
