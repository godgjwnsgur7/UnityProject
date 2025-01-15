
using UnityEngine;

/// <summary>
/// 스테이트 이름과 같아야 함
/// </summary>
public enum EPlayerState
{
    Idle,
    Move,
    Jump,
    Fall,
    Roll,
    Climb,
    Dead,

    // Weapon에 따른 모션
    // Bow - 공격 1
    // Spear - 공격 1,2 / 던지기
    // Sword - 공격 1,2,3
    ThrowAttack,
    Attack1,
    Attack2,
    Attack3,
}

public static class AnimatorHelper
{
    public static void Play(this Animator animator, EPlayerState characterState)
    {
        animator.Play(characterState.ToString());
    }

    public static void Play(this Animator animator, EPlayerState characterState, float normalizedTime)
    {
        animator.Play(characterState.ToString(), 0, normalizedTime);
    }

    public static bool IsState(this Animator animator, EPlayerState characterState)
    {
        return IsState(animator.GetCurrentAnimatorStateInfo(0), characterState);
    }

    public static bool IsState(this AnimatorStateInfo stateInfo, EPlayerState characterState)
    {
        return stateInfo.IsName(characterState.ToString());
    }

    public static bool IsEndState(this AnimatorStateInfo stateInfo)
    {
        return stateInfo.normalizedTime >= 1.0f;
    }

    public static void InitializePlayer(this Animator ownerAnimator)
    {
        var controller = ownerAnimator.GetComponent<PlayerController>();
        if (controller == null)
        {
            Debug.LogError("Contoller is Null!!");
            return;
        }

        var states = ownerAnimator.GetBehaviours<PlayerControllerState>();
        foreach (var state in states)
            state.InitializePlayer(controller);
    }
}

public class PlayerControllerState : StateMachineBehaviour
{
    protected PlayerController controller = null;

    public void InitializePlayer(PlayerController controller)
    {
        this.controller = controller;
    }

    protected virtual bool IsEndState(AnimatorStateInfo stateInfo)
    {
        return stateInfo.normalizedTime >= 0.99f;
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, animatorStateInfo, layerIndex);
    }

    public sealed override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, animatorStateInfo, layerIndex);
        CheckNextState(animator, animatorStateInfo);
    }

    public override void OnStateExit(UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        base.OnStateExit(animator, animatorStateInfo, layerIndex);
    }

    public sealed override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        base.OnStateMachineEnter(animator, stateMachinePathHash);
    }

    public sealed override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        base.OnStateMachineExit(animator, stateMachinePathHash);
    }

    protected virtual void CheckNextState(Animator animator, AnimatorStateInfo animatorStateInfo)
    {
        
        // Move
        if(controller.CheckMove())
        {
            animator.Play(EPlayerState.Move);
        }
        else if(animatorStateInfo.IsState(EPlayerState.Idle) == false)
        {
            animator.Play(EPlayerState.Idle);
        }
    }
}
