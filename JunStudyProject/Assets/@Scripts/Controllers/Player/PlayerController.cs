using System;
using UnityEngine;
using static Define;

// 위치 변경 필요 (임시)
public enum EPlayerWeaponType
{
    None = 0,
    Sword = 1,
    Spear = 2,
    Bow = 3,
}

public class PlayerController : MonoBehaviour
{
    // PlayerChildComponent를 상속받은 클래스들과 매핑되어 있는 Func
    public event Func<bool> IsGrounded; // PlayerGroundCheckComponent

    public event Action<Vector2> OnMove;
    public event Action<float> OnJump;

    [field: SerializeField, ReadOnly]
    public bool IsControllableState { get; private set; }

    // 플레이어데이터 데이터 하드코딩 (임시)
    #region PlayerData
    
    #endregion

    private void Reset()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            child.gameObject.layer = (int)ELayer.Player;
            child.gameObject.tag = ELayer.Player.ToString();
        }
    }

    private void Start()
    {
        IsControllableState = true; // (임시)
    }

    public void MovePosition(Vector2 moveVec)
    {
        if (IsControllableState == false)
            return;

        OnMove?.Invoke(moveVec);
    }

    public void TryInteract()
    {
        if (IsControllableState == false)
            return;

        // 상호작용 대상이 있는지 확인하고 있다면 상호작용
    }

    public void TryJump()
    {
        if (IsControllableState == false)
            return;


    }
    
    public void TryAttack()
    {
        if (IsControllableState == false)
            return;

    }
}
