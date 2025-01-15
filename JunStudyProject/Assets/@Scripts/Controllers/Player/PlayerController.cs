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
    [SerializeField, ReadOnly] private Animator animator;

    // PlayerChildComponent를 상속받은 클래스들과 매핑되어 있는 Func
    public event Func<bool> IsGrounded; // PlayerGroundCheckComponent

    public event Action<float> OnJump;
    public event Action<Vector2> OnMove;
    public event Action<float> OnMoveX;

    [field: SerializeField, ReadOnly]
    public bool IsControllableState { get; private set; }

    protected Vector2 moveVec = Vector2.zero;

    // 플레이어데이터 데이터 하드코딩 (임시)
    #region PlayerData
    
    #endregion

    private void Reset()
    {
        animator = GetComponent<Animator>();

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

        animator.InitializePlayer();
    }

    public bool CheckMove()
    {
        if (IsGrounded() == false)
            return false;

        if (moveVec.x == 0)
            return false;

        return true;
    }

    public void MoveVelocityX(float moveX)
    {
        if (IsControllableState == false)
            return;

        moveVec.x = moveX;
        OnMoveX?.Invoke(moveX);
    }

    public void TryInteract()
    {
        if (IsControllableState == false)
            return;

        // 상호작용 대상이 있는지 확인하고 있다면 상호작용
    }

    public void TryJump(float jumpPower)
    {
        if (IsControllableState == false)
            return;

        OnJump?.Invoke(jumpPower);
    }
    
    public void TryAttack()
    {
        if (IsControllableState == false)
            return;

    }
}
